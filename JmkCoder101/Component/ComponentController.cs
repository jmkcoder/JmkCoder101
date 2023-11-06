using JmkCoder101.Component.Interface;
using Microsoft.AspNetCore.Mvc;

namespace JmkCoder101.Component
{
    public abstract class ComponentController<T> : Controller where T : IComponentViewModel, new()
    {
        [HttpGet]
        public IActionResult Example()
        {
            var model = new T().Example();

            return View("~/Component/Views/Index.cshtml", model);
        }
    }
}
