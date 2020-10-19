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
    public class FrecuenciaNotificacionesController : Controller
    {
        private readonly CartedaDBContext _context;

        public FrecuenciaNotificacionesController(CartedaDBContext context)
        {
            _context = context;
        }

        // GET: FrecuenciaNotificaciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.FrecuenciaNotificaciones.ToListAsync());
        }

        // GET: FrecuenciaNotificaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frecuenciaNotificaciones = await _context.FrecuenciaNotificaciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (frecuenciaNotificaciones == null)
            {
                return NotFound();
            }

            return View(frecuenciaNotificaciones);
        }

        // GET: FrecuenciaNotificaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FrecuenciaNotificaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreCampaña,DiasPrevios,NumeroEnvios,HoraEnvio,CadaMinuto,CadaHora")] FrecuenciaNotificaciones frecuenciaNotificaciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(frecuenciaNotificaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(frecuenciaNotificaciones);
        }

        // GET: FrecuenciaNotificaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frecuenciaNotificaciones = await _context.FrecuenciaNotificaciones.FindAsync(id);
            if (frecuenciaNotificaciones == null)
            {
                return NotFound();
            }
            return View(frecuenciaNotificaciones);
        }

        // POST: FrecuenciaNotificaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreCampaña,DiasPrevios,NumeroEnvios,HoraEnvio,CadaMinuto,CadaHora")] FrecuenciaNotificaciones frecuenciaNotificaciones)
        {
            if (id != frecuenciaNotificaciones.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(frecuenciaNotificaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FrecuenciaNotificacionesExists(frecuenciaNotificaciones.Id))
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
            return View(frecuenciaNotificaciones);
        }

        // GET: FrecuenciaNotificaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frecuenciaNotificaciones = await _context.FrecuenciaNotificaciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (frecuenciaNotificaciones == null)
            {
                return NotFound();
            }

            return View(frecuenciaNotificaciones);
        }

        // POST: FrecuenciaNotificaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var frecuenciaNotificaciones = await _context.FrecuenciaNotificaciones.FindAsync(id);
            _context.FrecuenciaNotificaciones.Remove(frecuenciaNotificaciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FrecuenciaNotificacionesExists(int id)
        {
            return _context.FrecuenciaNotificaciones.Any(e => e.Id == id);
        }
    }
}
