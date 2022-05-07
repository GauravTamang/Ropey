#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ropey.Data;
using Ropey.Models;

namespace Ropey.Controllers
{
    public class DvdtitlesController : Controller
    {
        private readonly RopeyContext _context;

        public DvdtitlesController(RopeyContext context)
        {
            _context = context;
        }

        // GET: Dvdtitles
        public async Task<IActionResult> Index(string SearchText)
        {


            var b = _context.Actors;
            List<Actor> actors;
            actors = b.Where(a => a.ActorSurName.Contains(SearchText)).ToList();
            if (SearchText != "" && SearchText != null)
            {

                return View(await _context.Dvdtitles.Where(d => d.Dvdtitle1.Contains(SearchText)).ToListAsync());
            }
            else {

                return View(await _context.Dvdtitles.ToListAsync());


            }
            
        }

        // GET: Dvdtitles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dvdtitle = await _context.Dvdtitles
                .Include(d => d.CategoryNumberNavigation)
                .Include(d => d.ProducerNumberNavigation)
                .Include(d => d.StudioNumberNavigation)
                .FirstOrDefaultAsync(m => m.Dvdnumber == id);
            if (dvdtitle == null)
            {
                return NotFound();
            }

            return View(dvdtitle);
        }

        // GET: Dvdtitles/Create
        public IActionResult Create()
        {
            ViewData["CategoryNumber"] = new SelectList(_context.Dvdcategories, "CategoryNumber", "CategoryNumber");
            ViewData["ProducerNumber"] = new SelectList(_context.Producers, "ProducerNumber", "ProducerNumber");
            ViewData["StudioNumber"] = new SelectList(_context.Studios, "StudioNumber", "StudioNumber");
            return View();
        }

        // POST: Dvdtitles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Dvdnumber,CategoryNumber,StudioNumber,ProducerNumber,Dvdtitle1,DateReleased,StandardCharge,PenaltyCharge")] Dvdtitle dvdtitle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dvdtitle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryNumber"] = new SelectList(_context.Dvdcategories, "CategoryNumber", "CategoryNumber", dvdtitle.CategoryNumber);
            ViewData["ProducerNumber"] = new SelectList(_context.Producers, "ProducerNumber", "ProducerNumber", dvdtitle.ProducerNumber);
            ViewData["StudioNumber"] = new SelectList(_context.Studios, "StudioNumber", "StudioNumber", dvdtitle.StudioNumber);
            return View(dvdtitle);
        }

        // GET: Dvdtitles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dvdtitle = await _context.Dvdtitles.FindAsync(id);
            if (dvdtitle == null)
            {
                return NotFound();
            }
            ViewData["CategoryNumber"] = new SelectList(_context.Dvdcategories, "CategoryNumber", "CategoryNumber", dvdtitle.CategoryNumber);
            ViewData["ProducerNumber"] = new SelectList(_context.Producers, "ProducerNumber", "ProducerNumber", dvdtitle.ProducerNumber);
            ViewData["StudioNumber"] = new SelectList(_context.Studios, "StudioNumber", "StudioNumber", dvdtitle.StudioNumber);
            return View(dvdtitle);
        }

        // POST: Dvdtitles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Dvdnumber,CategoryNumber,StudioNumber,ProducerNumber,Dvdtitle1,DateReleased,StandardCharge,PenaltyCharge")] Dvdtitle dvdtitle)
        {
            if (id != dvdtitle.Dvdnumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dvdtitle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DvdtitleExists(dvdtitle.Dvdnumber))
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
            ViewData["CategoryNumber"] = new SelectList(_context.Dvdcategories, "CategoryNumber", "CategoryNumber", dvdtitle.CategoryNumber);
            ViewData["ProducerNumber"] = new SelectList(_context.Producers, "ProducerNumber", "ProducerNumber", dvdtitle.ProducerNumber);
            ViewData["StudioNumber"] = new SelectList(_context.Studios, "StudioNumber", "StudioNumber", dvdtitle.StudioNumber);
            return View(dvdtitle);
        }

        // GET: Dvdtitles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dvdtitle = await _context.Dvdtitles
                .Include(d => d.CategoryNumberNavigation)
                .Include(d => d.ProducerNumberNavigation)
                .Include(d => d.StudioNumberNavigation)
                .FirstOrDefaultAsync(m => m.Dvdnumber == id);
            if (dvdtitle == null)
            {
                return NotFound();
            }

            return View(dvdtitle);
        }

        // POST: Dvdtitles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dvdtitle = await _context.Dvdtitles.FindAsync(id);
            _context.Dvdtitles.Remove(dvdtitle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DvdtitleExists(int id)
        {
            return _context.Dvdtitles.Any(e => e.Dvdnumber == id);
        }
    }
}
