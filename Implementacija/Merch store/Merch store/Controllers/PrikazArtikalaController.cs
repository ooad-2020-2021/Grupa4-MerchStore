using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Merch_store.Data;
using Merch_store.Models;

namespace Merch_store.Controllers
{
    public class PrikazArtikalaController : Controller
    {
        private readonly DataContext _context;

        public PrikazArtikalaController(DataContext context)
        {
            _context = context;
        }

        // GET: PrikazArtikala
        public async Task<IActionResult> Index()
        {

            // return View(await _context.NarudzbaDizajnera_1.ToListAsync());
            return View(await _context.PrikazArtikala.FromSqlRaw("SELECT * FROM PrikazArtikala").ToListAsync());
        }

        // GET: PrikazArtikala/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var narudzbaDizajnera = await _context.PrikazArtikala
                .FirstOrDefaultAsync(m => m.ID == id);
            if (narudzbaDizajnera == null)
            {
                return NotFound();
            }

            return View(narudzbaDizajnera);
        }

        // GET: PrikazArtikala/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PrikazArtikala/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NazivGarderobe,Boja,Velicina,Kolicina,Cijena,DatumNarudzbe,PreostaloVrijeme")] NarudzbaDizajnera narudzbaDizajnera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(narudzbaDizajnera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(narudzbaDizajnera);
        }

        // GET: PrikazArtikala/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var narudzbaDizajnera = await _context.PrikazArtikala.FindAsync(id);
            if (narudzbaDizajnera == null)
            {
                return NotFound();
            }
            return View(narudzbaDizajnera);
        }

        // POST: PrikazArtikala/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NazivGarderobe,Boja,Velicina,Kolicina,Cijena,DatumNarudzbe,PreostaloVrijeme")] NarudzbaDizajnera narudzbaDizajnera)
        {
            if (id != narudzbaDizajnera.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(narudzbaDizajnera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NarudzbaDizajneraExists(narudzbaDizajnera.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(narudzbaDizajnera);
        }

        // GET: PrikazArtikala/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var narudzbaDizajnera = await _context.PrikazArtikala
                .FirstOrDefaultAsync(m => m.ID == id);
            if (narudzbaDizajnera == null)
            {
                return NotFound();
            }

            return View(narudzbaDizajnera);
        }

        // POST: PrikazArtikala/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var narudzbaDizajnera = await _context.PrikazArtikala.FindAsync(id);
            _context.PrikazArtikala.Remove(narudzbaDizajnera);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NarudzbaDizajneraExists(int id)
        {
            return _context.PrikazArtikala.Any(e => e.ID == id);
        }
    }
}
