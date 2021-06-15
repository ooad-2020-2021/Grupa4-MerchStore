using Merch_store.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TEST.Data;
using TEST.Models;

namespace TEST.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        [Authorize]
        public IActionResult Index()
        {
            String Id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Id = "'" + Id + "'";
            var temp = new GlavniViewModel();
            temp.artikli = _context.PrikazArtikala.FromSqlRaw("SELECT * FROM NarudzbaDizajnera n WHERE n.korisnikID = " + Id).ToList();
            temp.obavijesti = _context.Obavijest.FromSqlRaw("SELECT * FROM Obavijest o WHERE" +
                " (o.korisnikID = " + Id + " AND o.tip != 3) OR o.tip = 2").ToList(); temp.obavijesti.Reverse();
            temp.obavijestiNarucivanja = _context.Obavijest.FromSqlRaw("SELECT * FROM Obavijest o WHERE" +
                " o.korisnikID = " + Id + " AND o.tip = 3").ToList();
            return View(temp);
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult Pretraga(string? Id)
        {
            Id = "'" + Id + "'";
            var temp = new GlavniViewModel();
            temp.artikli = _context.PrikazArtikala.FromSqlRaw("SELECT * FROM NarudzbaDizajnera n WHERE n.korisnikID = " + Id).ToList();
            return View(temp);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
