using Microsoft.AspNetCore.Mvc;

namespace SampleWebSite.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
