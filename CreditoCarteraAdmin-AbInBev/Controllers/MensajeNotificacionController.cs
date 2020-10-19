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
    public class MensajeNotificacionController : Controller
    {
        private readonly CartedaDBContext _context;

        public MensajeNotificacionController(CartedaDBContext context)
        {
            _context = context;
        }

        // GET: MensajeNotificacions
        public async Task<IActionResult> Index()
        {
            return View(await _context.MensajeNotificacion.ToListAsync());
        }

        // GET: MensajeNotificacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensajeNotificacion = await _context.MensajeNotificacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mensajeNotificacion == null)
            {
                return NotFound();
            }

            return View(mensajeNotificacion);
        }

        // GET: MensajeNotificacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MensajeNotificacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,Mensaje,DiasPrevios")] MensajeNotificacion mensajeNotificacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mensajeNotificacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mensajeNotificacion);
        }

        // GET: MensajeNotificacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensajeNotificacion = await _context.MensajeNotificacion.FindAsync(id);
            if (mensajeNotificacion == null)
            {
                return NotFound();
            }
            return View(mensajeNotificacion);
        }

        // POST: MensajeNotificacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo,Mensaje,DiasPrevios")] MensajeNotificacion mensajeNotificacion)
        {
            if (id != mensajeNotificacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mensajeNotificacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MensajeNotificacionExists(mensajeNotificacion.Id))
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
            return View(mensajeNotificacion);
        }

        // GET: MensajeNotificacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensajeNotificacion = await _context.MensajeNotificacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mensajeNotificacion == null)
            {
                return NotFound();
            }

            return View(mensajeNotificacion);
        }

        // POST: MensajeNotificacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mensajeNotificacion = await _context.MensajeNotificacion.FindAsync(id);
            _context.MensajeNotificacion.Remove(mensajeNotificacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MensajeNotificacionExists(int id)
        {
            return _context.MensajeNotificacion.Any(e => e.Id == id);
        }
    }
}
