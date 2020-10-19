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
    public class CreditoClientesController : Controller
    {
        private readonly CartedaDBContext _context;

        public CreditoClientesController(CartedaDBContext context)
        {
            _context = context;
        }

        // GET: CreditoCliente
        public async Task<IActionResult> Index()
        {
            return View(await _context.CreditoCliente.ToListAsync());
        }

        // GET: CreditoCliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CreditoCliente = await _context.CreditoCliente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (CreditoCliente == null)
            {
                return NotFound();
            }

            return View(CreditoCliente);
        }

        // GET: CreditoCliente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CreditoCliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreCliente,CreditoAnterior,CreditoNuevo,FechaRegistro,ClienteNuevo,StatusCreditoNuevo,NumeroCelular,NumeroEnvios")] CreditoCliente CreditoCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(CreditoCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(CreditoCliente);
        }

        // GET: CreditoCliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CreditoCliente = await _context.CreditoCliente.FindAsync(id);
            if (CreditoCliente == null)
            {
                return NotFound();
            }
            return View(CreditoCliente);
        }

        // POST: CreditoCliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreCliente,CreditoAnterior,CreditoNuevo,FechaRegistro,ClienteNuevo,StatusCreditoNuevo,NumeroCelular,NumeroEnvios")] CreditoCliente creditoCliente)
        {
            if (id != creditoCliente.Id)
            {
                return base.NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(creditoCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreditoClienteExists(creditoCliente.Id))
                    {
                        return base.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(creditoCliente);
        }

        // GET: CreditoCliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CreditoCliente = await _context.CreditoCliente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (CreditoCliente == null)
            {
                return NotFound();
            }

            return View(CreditoCliente);
        }

        // POST: CreditoCliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var CreditoCliente = await _context.CreditoCliente.FindAsync(id);
            _context.CreditoCliente.Remove(CreditoCliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreditoClienteExists(int id)
        {
            return _context.CreditoCliente.Any(e => e.Id == id);
        }
    }
}
