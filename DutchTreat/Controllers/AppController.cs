using DutchTreat.Data;
using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService mailService;
        private readonly IDutchRepository dutchRepository;

        public AppController(IMailService mailService, IDutchRepository dutchRepository)
        {
            this.mailService = mailService;
            this.dutchRepository = dutchRepository;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contacts";

            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                mailService.SendMail("kshaffer@alcoholmonitoring.com", model.Subject, $"From: {model.Name} -- {model.Email}, Message: {model.Message}");

                ViewBag.MessageSent = "Message sent";

                ModelState.Clear();
            }
            else
            {

            }

            return View();
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            ViewBag.Title = "About";

            return View();
        }

        public IActionResult Shop()
        {
            var results = dutchRepository.GetAllProducts();

            return View(results);
        }
    }
}
