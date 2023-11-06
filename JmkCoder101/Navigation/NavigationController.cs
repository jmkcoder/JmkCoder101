using Components.Component.ViewModels;
using JmkCoder101.Navigation.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace JmkCoder101.Navigation
{
    [Route("[Controller]")]
    public class NavigationController : Controller
    {
        public IActionResult Index()
        {
            var navbarItems = GetNavbarItems();
            return PartialView("~/Navigation/Views/Index.cshtml", navbarItems);
        }

        private IEnumerable<NavbarItem> GetNavbarItems()
        {
            // Use reflection to get the methods that should be displayed in the navbar
            var controllers = Assembly.GetAssembly(typeof(ComponentViewModel))?.GetTypes()?.Where(x => x.IsAssignableTo(typeof(Controller)))?.Select(x => new { x?.Name, x?.BaseType });
            var methods = controllers?
                .Where(x => x?.BaseType?.GetMethod("Example") != null)
                .Select(x => new { x.Name, DeclaringMethod = x.BaseType?.GetMethod("Example") }).ToList();

            // Create a list of NavbarItems from the methods
            var navbarItems = new List<NavbarItem>();

            if (methods is not null)
            {
                foreach (var method in methods)
                {
                    if (method is not null && method?.DeclaringMethod?.Name is not null)
                    {
                        var name = method?.Name?.Replace("Controller", "");

                        var navbarItem = new NavbarItem
                        {
                            Text = name,
                            Url = Url.Action(method?.DeclaringMethod.Name, name)
                        };
                        navbarItems.Add(navbarItem);
                    }
                }
            }

            return navbarItems.OrderBy(x => x.Text).ToList();
        }
    }
}
