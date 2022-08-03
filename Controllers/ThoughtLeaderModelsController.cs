using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Octavius_Business_Rules.Data;
using Octavius_Business_Rules.Models;

namespace Octavius_Business_Rules.Controllers
{
    public class ThoughtLeaderModelsController : Controller
    {
        private readonly Octavius_Business_Rules_Context _context;

        public ThoughtLeaderModelsController(Octavius_Business_Rules_Context context)
        {
            _context = context;
        }

        // GET: ThoughtLeaderModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ThoughtLeaderModel.ToListAsync());
        }

        // GET: ThoughtLeaderModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thoughtLeaderModel = await _context.ThoughtLeaderModel
                .FirstOrDefaultAsync(m => m.ThoughtLeaderID == id);
            if (thoughtLeaderModel == null)
            {
                return NotFound();
            }

            return View(thoughtLeaderModel);
        }

        // GET: ThoughtLeaderModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ThoughtLeaderModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ThoughtLeaderID,FirstName,LastName,Initial,ProjectID,IsCommercial,IsMedical")] ThoughtLeaderModel thoughtLeaderModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thoughtLeaderModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thoughtLeaderModel);
        }

        // GET: ThoughtLeaderModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thoughtLeaderModel = await _context.ThoughtLeaderModel.FindAsync(id);
            if (thoughtLeaderModel == null)
            {
                return NotFound();
            }
            return View(thoughtLeaderModel);
        }

        // POST: ThoughtLeaderModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ThoughtLeaderID,FirstName,LastName,Initial,ProjectID,IsCommercial,IsMedical")] ThoughtLeaderModel thoughtLeaderModel)
        {
            if (id != thoughtLeaderModel.ThoughtLeaderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thoughtLeaderModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThoughtLeaderModelExists(thoughtLeaderModel.ThoughtLeaderID))
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
            return View(thoughtLeaderModel);
        }

        // GET: ThoughtLeaderModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thoughtLeaderModel = await _context.ThoughtLeaderModel
                .FirstOrDefaultAsync(m => m.ThoughtLeaderID == id);
            if (thoughtLeaderModel == null)
            {
                return NotFound();
            }

            return View(thoughtLeaderModel);
        }

        // POST: ThoughtLeaderModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thoughtLeaderModel = await _context.ThoughtLeaderModel.FindAsync(id);
            _context.ThoughtLeaderModel.Remove(thoughtLeaderModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThoughtLeaderModelExists(int id)
        {
            return _context.ThoughtLeaderModel.Any(e => e.ThoughtLeaderID == id);
        }
    }
}
