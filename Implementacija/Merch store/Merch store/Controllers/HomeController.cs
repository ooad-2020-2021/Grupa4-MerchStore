using Merch_store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Merch_store.Data;
using Microsoft.EntityFrameworkCore;



namespace Merch_store.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var temp = new GlavniViewModel();
            temp.artikli = _context.PrikazArtikala.FromSqlRaw("SELECT * FROM NarudzbaDizajnera n WHERE n.korisnikID = 1").ToList();
            temp.obavijesti = _context.Obavijest.FromSqlRaw("SELECT * FROM Obavijest o WHERE" +
                " (o.korisnikID = 1 AND o.tip != 3) OR o.tip = 2").ToList();
            temp.obavijestiNarucivanja = _context.Obavijest.FromSqlRaw("SELECT * FROM Obavijest o WHERE" +
                " o.korisnikID = 1 AND o.tip = 3").ToList();
            return View(temp);
        }

        public IActionResult Privacy()
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
