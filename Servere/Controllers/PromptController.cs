using Microsoft.AspNetCore.Mvc;

namespace Servere.Controllers
{
    public class PromptController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
