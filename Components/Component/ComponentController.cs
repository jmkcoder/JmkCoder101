using Components.Common;
using Components.Component.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Components.Component
{
    public abstract class ComponentController<T> : Controller where T : IComponentViewModel, new()
    {
        [HttpGet]
        public ActionResult Example()
        {
            var model = new T().Example();

            return View("~/Component/Views/Index.cshtml", model);
        }

        [HttpPost]
        public PartialViewResult? Demo(IDictionary<string, string?> formValues)
        {
            var dictionary = formValues?.ToDictionary(x => x.Key, x => x.Value as object);

            var viewPath = dictionary?["ViewPath"] as string;

            dictionary?.Remove("ViewPath");

            if (formValues != null && dictionary != null)
            {
                var model = SerializeFormValues(formValues, dictionary);
                return PartialView(viewPath, model);
            }

            return null;
        }

        private T SerializeFormValues(IDictionary<string, string?> formValues, IDictionary<string, object?> dictionary)
        {
            foreach (var item in formValues)
            {
                dictionary[item.Key] = ComponentUtilities.ConvertToObject(item, typeof(T));
            }

            var json = JsonSerializer.Serialize(dictionary);
            return JsonSerializer.Deserialize<T>(json) ?? new T();
        }
    }
}
