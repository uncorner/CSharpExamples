using Microsoft.AspNetCore.Mvc;
using SampleWebSite.Models;

namespace SampleWebSite.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Check()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Check(Contact contact)
        {
            if (ModelState.IsValid)
            {
                return View("ShowInputData", contact);
            }

            return View();
        }

        [HttpPost]
        public IActionResult ShowInputData(Contact contact)
        {
            return View();
        }

    }
}
