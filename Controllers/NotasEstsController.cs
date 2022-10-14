using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SISTEMADENOTAS.Models;

namespace SISTEMADENOTAS.Controllers
{
    public class NotasEstsController : Controller
    {
        private readonly MvcCrudContext _context;

        public NotasEstsController(MvcCrudContext context)
        {
            _context = context;
        }

        // GET: NotasEsts
        public async Task<IActionResult> Index()
        {
              return View(await _context.NotasEsts.ToListAsync());
        }

        // GET: NotasEsts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NotasEsts == null)
            {
                return NotFound();
            }

            var notasEst = await _context.NotasEsts
                .FirstOrDefaultAsync(m => m.IdNotasE == id);
            if (notasEst == null)
            {
                return NotFound();
            }

            return View(notasEst);
        }

        // GET: NotasEsts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NotasEsts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNotasE,Nombre,Apellido,Ipn,Iipn,Siste,Proyect,Nf")] NotasEst notasEst)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notasEst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notasEst);
        }

        // GET: NotasEsts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NotasEsts == null)
            {
                return NotFound();
            }

            var notasEst = await _context.NotasEsts.FindAsync(id);
            if (notasEst == null)
            {
                return NotFound();
            }
            return View(notasEst);
        }

        // POST: NotasEsts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNotasE,Nombre,Apellido,Ipn,Iipn,Siste,Proyect,Nf")] NotasEst notasEst)
        {
            if (id != notasEst.IdNotasE)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notasEst);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotasEstExists(notasEst.IdNotasE))
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
            return View(notasEst);
        }

        // GET: NotasEsts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NotasEsts == null)
            {
                return NotFound();
            }

            var notasEst = await _context.NotasEsts
                .FirstOrDefaultAsync(m => m.IdNotasE == id);
            if (notasEst == null)
            {
                return NotFound();
            }

            return View(notasEst);
        }

        // POST: NotasEsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NotasEsts == null)
            {
                return Problem("Entity set 'MvcCrudContext.NotasEsts'  is null.");
            }
            var notasEst = await _context.NotasEsts.FindAsync(id);
            if (notasEst != null)
            {
                _context.NotasEsts.Remove(notasEst);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotasEstExists(int id)
        {
          return _context.NotasEsts.Any(e => e.IdNotasE == id);
        }
    }
}
