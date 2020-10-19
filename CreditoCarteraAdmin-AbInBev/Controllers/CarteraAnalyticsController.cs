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
    public class CarteraAnalyticsController : Controller
    {
        private readonly CartedaDBContext _context;

        public CarteraAnalyticsController(CartedaDBContext context)
        {
            _context = context;
        }

        // GET: CarteraAnalytics
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarteraAnalytics.ToListAsync());
        }

        // GET: CarteraAnalytics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carteraAnalytics = await _context.CarteraAnalytics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carteraAnalytics == null)
            {
                return NotFound();
            }

            return View(carteraAnalytics);
        }

        // GET: CarteraAnalytics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarteraAnalytics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreCliente,Pais,NumeroCelular,ValorCartera,FechaVencimiento,Habilitado,SmsEnviados,LlamadasHechas")] CarteraAnalytics carteraAnalytics)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carteraAnalytics);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carteraAnalytics);
        }

        // GET: CarteraAnalytics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carteraAnalytics = await _context.CarteraAnalytics.FindAsync(id);
            if (carteraAnalytics == null)
            {
                return NotFound();
            }
            return View(carteraAnalytics);
        }

        // POST: CarteraAnalytics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreCliente,Pais,NumeroCelular,ValorCartera,FechaVencimiento,Habilitado,SmsEnviados,LlamadasHechas")] CarteraAnalytics carteraAnalytics)
        {
            if (id != carteraAnalytics.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carteraAnalytics);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarteraAnalyticsExists(carteraAnalytics.Id))
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
            return View(carteraAnalytics);
        }

        // GET: CarteraAnalytics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carteraAnalytics = await _context.CarteraAnalytics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carteraAnalytics == null)
            {
                return NotFound();
            }

            return View(carteraAnalytics);
        }

        // POST: CarteraAnalytics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carteraAnalytics = await _context.CarteraAnalytics.FindAsync(id);
            _context.CarteraAnalytics.Remove(carteraAnalytics);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarteraAnalyticsExists(int id)
        {
            return _context.CarteraAnalytics.Any(e => e.Id == id);
        }
    }
}
