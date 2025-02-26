using Microsoft.AspNetCore.Mvc;
using PhoneManagement.Services;
using PhoneManagement.Models;

namespace PhoneManagement.Controllers
{
    public class PhoneController : Controller
    {
        private readonly TwilioService _twilioService;

        public PhoneController(TwilioService twilioService)
        {
            _twilioService = twilioService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendSms(PhoneModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _twilioService.SendSms(model.PhoneNumber, "Hello World");
                ViewBag.Message = "SMS sent successfully! Message SID: " + result;
            }
            else
            {
                ViewBag.Message = "Invalid phone number!";
            }
            return View("Index");
        }
    }
}