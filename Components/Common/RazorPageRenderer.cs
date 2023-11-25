using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;

namespace Components.Common
{
    public class RazorPageRenderer
    {
        public static RazorPageRenderer? Instance { get; private set; }

        private readonly IServiceProvider _serviceProvider;

        public RazorPageRenderer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            Instance = this;
        }

        public async Task<string> RenderPageAsync<TModel>(string viewPath, TModel model)
        {
            var serviceScope = _serviceProvider.CreateScope();
            var httpContext = new DefaultHttpContext { RequestServices = serviceScope.ServiceProvider };

            var actionContext = new ActionContext(httpContext, new RouteData(), new PageActionDescriptor());

            var view = FindView(actionContext, viewPath);
            if (view == null)
            {
                throw new InvalidOperationException($"Unable to find view at {viewPath}");
            }

            var viewData = new ViewDataDictionary<TModel>(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            {
                Model = model
            };

            using (var sw = new StringWriter())
            {
                var viewContext = new ViewContext(
                    actionContext,
                    view,
                    viewData,
                    new TempDataDictionary(actionContext.HttpContext, _serviceProvider.GetRequiredService<ITempDataProvider>()),
                    sw,
                    new HtmlHelperOptions()
                );

                await view.RenderAsync(viewContext);
                return sw.ToString();
            }
        }

        private IView FindView(ActionContext actionContext, string viewPath)
        {
            var viewEngine = _serviceProvider.GetRequiredService<IRazorViewEngine>();
            var viewResult = viewEngine.GetView(executingFilePath: null, viewPath: viewPath, isMainPage: true);

            if (viewResult.Success)
            {
                return viewResult.View;
            }

            var getViewResult = viewEngine.FindView(actionContext, viewPath, isMainPage: true);
            if (getViewResult.Success)
            {
                return getViewResult.View;
            }

            var searchedLocations = getViewResult.SearchedLocations.Concat(viewResult.SearchedLocations);
            var errorMessage = string.Join(Environment.NewLine, new[] { $"Unable to find view '{viewPath}'. The following locations were searched:" }.Concat(searchedLocations));
            throw new InvalidOperationException(errorMessage);
        }
    }
}
