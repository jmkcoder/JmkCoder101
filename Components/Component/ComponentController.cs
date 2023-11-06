using Components.Component.Interface;
using Microsoft.AspNetCore.Mvc;

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
    }
}
