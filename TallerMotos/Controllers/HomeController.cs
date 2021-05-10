using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TallerMotos.Models;

namespace TallerMotos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            int? valor = HttpContext.Session.GetInt32("valor");

            if (valor == null || valor == 0)
            {
                return RedirectToAction("Index", "Usuarios");
            }
            return View();
        }

        public IActionResult HacerLoginInvitado()
        {
            HttpContext.Session.SetInt32("valor", 2);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult HacerLogiStaff()
        {
            HttpContext.Session.SetInt32("valor", 1);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult MotosHm()
        {
            return View();
        }
        public IActionResult PiezasHm()
        {
            return View();
        }
        public IActionResult ComplementosHm()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
