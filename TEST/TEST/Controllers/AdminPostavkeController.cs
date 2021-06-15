using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Merch_store.Models;
using TEST.Data;
using Microsoft.AspNetCore.Identity;
using TEST.Models;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using static System.Net.WebRequestMethods;

namespace TEST.Controllers
{
    public class AdminPostavkeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminPostavkeController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: AdminPostavke
        [Authorize(Roles = ("Administrator"))]
        public async Task<IActionResult> Index()
        {
            var temp = new AdminPostavkeModel();
            temp.korisnici = _context.Users.AsNoTracking().ToList();
            temp.nepotrvrdjeneNarudzbe = _context.PrikazArtikala.FromSqlRaw("SELECT * FROM NarudzbaDizajnera n WHERE n.StatusNarudzbe = 0").ToList();

            return View(temp);
        }

        // GET: AdminPostavke/Delete/5
        [Authorize(Roles = ("Administrator"))]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korisnik = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (korisnik == null)
            {
                return NotFound();
            }

            return View(korisnik);
        }

        // POST: AdminPostavke/Delete/5
        [Authorize(Roles = ("Administrator"))]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string? id)
        {
            var korisnik = await _context.Users.FindAsync(id);
            _context.Users.Remove(korisnik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = ("Administrator"))]
        [HttpPost, ActionName("Potvrdi")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PotvrdiNarudzbu(int? id)
        {
            Debug.WriteLine(id.ToString() + "why");
            NarudzbaDizajnera narudzba = await _context.PrikazArtikala.FindAsync(id);
            narudzba.StatusNarudzbe = 1;
            _context.Update(narudzba);

            Obavijest temp = _context.Obavijest.FromSqlRaw("SELECT * FROM Obavijest o " +
                "WHERE o.ID = (SELECT Max(ot.ID) FROM Obavijest ot)").ToList().ElementAt(0);
            Obavijest obavijest = new Obavijest();
            obavijest.ID = temp.ID + 1;
            obavijest.korisnikID = narudzba.korisnikID;
            obavijest.sadrzaj = "Vasa narudzba " + "'" + narudzba.NazivGarderobe + "' je potvrdjena";
            obavijest.tip = 1;
            _context.Obavijest.Add(obavijest);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = ("Administrator"))]
        [HttpPost, ActionName("Odbij")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OdbijNarudzbu(int? id)
        {
            Debug.WriteLine(id.ToString() + "why");
            NarudzbaDizajnera narudzba = await _context.PrikazArtikala.FindAsync(id);
            narudzba.StatusNarudzbe = 2;
            _context.Update(narudzba);

            Obavijest temp = _context.Obavijest.FromSqlRaw("SELECT * FROM Obavijest o " +
                "WHERE o.ID = (SELECT Max(ot.ID) FROM Obavijest ot)").ToList().ElementAt(0);
            Obavijest obavijest = new Obavijest();
            obavijest.ID = temp.ID + 1;
            obavijest.korisnikID = narudzba.korisnikID;
            obavijest.sadrzaj = "Vasa narudzba " + "'" + narudzba.NazivGarderobe + "' je odbijena";
            obavijest.tip = 1;
            _context.Obavijest.Add(obavijest);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DodavanjeGarderobe(Microsoft.AspNetCore.Http.IFormCollection kolekcija)
        {
            var temp = new AdminPostavkeModel();
            try
            {
                temp.brojBoja = Int32.Parse(kolekcija["brojboja"]);
            }
            catch
            {
                temp.brojBoja = 1;
            }
            try
            {
                temp.brojVelicina = Int32.Parse(kolekcija["brojvel"]);
            }
            catch
            {
                temp.brojVelicina = 1;
            }
            return View(temp);
        }

        public async Task<IActionResult> OsvjeziDodavanje(Microsoft.AspNetCore.Http.IFormCollection kolekcija)
        {
            Garderoba garderoba = new Garderoba();
            garderoba.Naziv = kolekcija["naziv"];
            garderoba.Kolicina = Int32.Parse(kolekcija["kolicina"]);
            garderoba.Cijena = double.Parse(kolekcija["cijena"]);
            garderoba.ID = _context.Garderoba.FromSqlRaw("SELECT * FROM Garderoba o " +
                "WHERE o.ID = (SELECT Max(ot.ID) FROM Garderoba ot)").ToList().ElementAt(0).ID + 1;
            foreach(var item in kolekcija)
            {
                if(item.Key.ElementAt(0) == 'a')
                {
                    var temp = _context.Boja.FromSqlRaw("SELECT * FROM Boja b WHERE b.opis = '" + item.Value + "'").ToList();
                    if(temp.Count() == 0)
                    {
                        var novaBoja = new Boja();
                        novaBoja.opis = item.Value;
                        novaBoja.Id = (Int32.Parse(_context.Boja.OrderByDescending(u => u.Id).FirstOrDefault().Id) + 1).ToString();
                        _context.Boja.Add(novaBoja);
                        garderoba.DostupneBoje += novaBoja.Id + ",";
                    }
                    else
                    {
                        garderoba.DostupneBoje += temp.ElementAt(0).Id + ",";
                    }
                }
            }
            foreach (var item in kolekcija)
            {
                if (item.Key.ElementAt(0) == 'b')
                {
                    var temp = _context.Velicina.FromSqlRaw("SELECT * FROM Velicina v WHERE v.opis = '" + item.Value + "'").ToList();
                    if (temp.Count() == 0)
                    {
                        var novaVelicina = new Velicina();
                        novaVelicina.opis = item.Value;
                        novaVelicina.Id = (Int32.Parse(_context.Velicina.OrderByDescending(u => u.Id).FirstOrDefault().Id) + 1).ToString();
                        _context.Velicina.Add(novaVelicina);
                        garderoba.DostupneVelicine += novaVelicina.Id + ",";
                    }
                    else
                    {
                        garderoba.DostupneVelicine += temp.ElementAt(0).Id + ",";
                    }
                }
            }
            garderoba.DostupneBoje = garderoba.DostupneBoje.Remove(garderoba.DostupneBoje.Length - 1);
            garderoba.DostupneVelicine = garderoba.DostupneVelicine.Remove(garderoba.DostupneVelicine.Length - 1);
            _context.Garderoba.Add(garderoba);

            Obavijest obavijest = new Obavijest();
            obavijest.ID = _context.Obavijest.OrderByDescending(u => u.ID).FirstOrDefault().ID + 1;
            obavijest.korisnikID = 1;
            obavijest.tip = 2;
            obavijest.sadrzaj = "Dodata je nova garderoba za dizajniranje: '" + garderoba.Naziv + "'";
            _context.Obavijest.Add(obavijest);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(DodavanjeGarderobe));
        }

    }
}
