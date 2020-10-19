using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CreditoCarteraAdmin_AbInBev.Models;
using Microsoft.AspNetCore.Authorization;

namespace CreditoCarteraAdmin_AbInBev.Controllers
{
    [Authorize]
    public class LlamadaNotificacionController : Controller
    {
        private readonly CartedaDBContext _context;

        public LlamadaNotificacionController(CartedaDBContext context)
        {
            _context = context;
        }

        // GET: LlamadaNotificacion
        public async Task<IActionResult> Index()
        {
            return View(await _context.LlamadaNotificacion.ToListAsync());
        }

        // GET: LlamadaNotificacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var LlamadaNotificacion = await _context.LlamadaNotificacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (LlamadaNotificacion == null)
            {
                return NotFound();
            }

            return View(LlamadaNotificacion);
        }

        // GET: LlamadaNotificacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LlamadaNotificacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BlobStorageURL,DiasPrevios")] LlamadaNotificacion LlamadaNotificacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(LlamadaNotificacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(LlamadaNotificacion);
        }

        // GET: LlamadaNotificacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var LlamadaNotificacion = await _context.LlamadaNotificacion.FindAsync(id);
            if (LlamadaNotificacion == null)
            {
                return NotFound();
            }
            return View(LlamadaNotificacion);
        }

        // POST: LlamadaNotificacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BlobStorageURL,DiasPrevios")] LlamadaNotificacion LlamadaNotificacion)
        {
            if (id != LlamadaNotificacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(LlamadaNotificacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LlamadaNotificacionExists(LlamadaNotificacion.Id))
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
            return View(LlamadaNotificacion);
        }

        // GET: LlamadaNotificacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var LlamadaNotificacion = await _context.LlamadaNotificacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (LlamadaNotificacion == null)
            {
                return NotFound();
            }

            return View(LlamadaNotificacion);
        }

        // POST: LlamadaNotificacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var llamadaNotificacion = await _context.LlamadaNotificacion.FindAsync(id);
            _context.LlamadaNotificacion.Remove(llamadaNotificacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LlamadaNotificacionExists(int id)
        {
            return _context.LlamadaNotificacion.Any(e => e.Id == id);
        }
    }
}
