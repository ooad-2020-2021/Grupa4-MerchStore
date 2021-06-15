using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Merch_store.Models;
using TEST.Data;
using TEST.Models;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace TEST.Controllers
{
    public class NarucivanjeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NarucivanjeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = ("Korisnik"))]
        // GET: Narucivanje
        public async Task<IActionResult> Index()
        {
            var temp = new NarucivanjeModel();
            temp.garderoba = _context.Garderoba.ToList();
            temp.dostupneBojeString = new List<List<String>>();
            temp.dostupneVelicineString = new List<List<String>>();
            foreach (var item in temp.garderoba)
            {
                List<String> IDBoja = item.DostupneBoje.Split(',').ToList();
                for(int i = 0; i < IDBoja.Count(); i++)
                {
                    Boja boja = await _context.Boja.FirstOrDefaultAsync(m => m.Id.Equals(IDBoja[i]));
                    IDBoja[i] = boja.opis;
                }
                temp.dostupneBojeString.Add(IDBoja);
            }

            foreach (var item in temp.garderoba)
            {
                List<String> IDVelicina = item.DostupneVelicine.Split(',').ToList();
                for (int i = 0; i < IDVelicina.Count(); i++)
                {
                    Velicina velicina = await _context.Velicina.FirstOrDefaultAsync(m => m.Id.Equals(IDVelicina[i]));
                    IDVelicina[i] = velicina.opis;
                }
                temp.dostupneVelicineString.Add(IDVelicina);
            }
            return View(temp);
        }

        public async Task<IActionResult> NaruciGarderobu(Microsoft.AspNetCore.Http.IFormCollection kolekcija)
        {
            NarudzbaDizajnera narudzba = new NarudzbaDizajnera();
            narudzba.ID = _context.PrikazArtikala.OrderByDescending(u => u.ID).FirstOrDefault().ID + 1;
            narudzba.korisnikID = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            foreach (var item in kolekcija)
            {
                if(item.Key.StartsWith("id"))
                {
                    Garderoba garderoba = await _context.Garderoba.FindAsync(Int32.Parse(item.Value));
                    narudzba.NazivGarderobe = garderoba.Naziv;
                    garderoba.Kolicina -= Int32.Parse(kolekcija["kolicina"]);
                    _context.Garderoba.Update(garderoba);
                }
            }
            
            narudzba.Boja = kolekcija["boje"];
            narudzba.Velicina = kolekcija["velicine"];
            narudzba.Cijena = double.Parse(kolekcija["cijena"]);
            narudzba.Kolicina = Int32.Parse(kolekcija["kolicina"]);
            narudzba.StatusNarudzbe = 0;

            _context.PrikazArtikala.Add(narudzba);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
