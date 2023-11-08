using Components.Component.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Text.Json;
using System.Web;

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
                var propertyType = typeof(T).GetProperties().FirstOrDefault(x => x.Name == item.Key)?.PropertyType;

                if (propertyType != null && propertyType.IsEnum)
                {
                    var values = Enum.GetValues(propertyType);

                    for (var i = 0; i < values.Length; i++)
                    {
                        if (i.ToString() == item.Value)
                        {
#pragma warning disable CS8604 // Possible null reference argument.
                            dictionary[item.Key] = values.GetValue(i) != null ? Enum.Parse(propertyType, values.GetValue(i)?.ToString()) : null;
#pragma warning restore CS8604 // Possible null reference argument.
                        }
                    };
                }
                else if (propertyType != null && Nullable.GetUnderlyingType(propertyType) == typeof(int) || propertyType == typeof(int))
                {
                    dictionary[item.Key] = item.Value != null ? int.Parse(item.Value) : 0;
                }
                else if (propertyType != null && Nullable.GetUnderlyingType(propertyType) == typeof(bool) || propertyType == typeof(bool))
                {
                    dictionary[item.Key] = item.Value != null ? bool.Parse(item.Value) : 0;
                }
                else if (propertyType != null && Nullable.GetUnderlyingType(propertyType) == typeof(string) || propertyType == typeof(string))
                {
                    dictionary[item.Key] = string.IsNullOrEmpty(item.Value) ? " " : item.Value;
                }
            }

            var json = JsonSerializer.Serialize(dictionary);
            return JsonSerializer.Deserialize<T>(json) ?? new T();
        }
    }
}
