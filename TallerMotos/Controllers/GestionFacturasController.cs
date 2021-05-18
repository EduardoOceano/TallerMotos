using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerMotos.Models;

namespace TallerMotos.Controllers
{
    public class GestionFacturasController : Controller
    {
        private readonly Contexto _context;
        public GestionFacturasController(Contexto context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Talleres = new SelectList(_context.Talleres, "id", "id");
            return View();
        }
    }
}
