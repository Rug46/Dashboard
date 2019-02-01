using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dashboard.Data;
using Dashboard.Models;
using Dashboard.Helpers;

namespace Dashboard.Controllers
{
    public class PlaytimeController : Controller
    {
        private readonly PlaytimeContext _context;

        public static int recordsPerPage = 10;
        public static int count;
        public static int s_Page;


        public PlaytimeController(PlaytimeContext context)
        {
            _context = context;
        }

        // GET: Playtime
        public async Task<IActionResult> Index(int id)
        {
            using(var db = new PlaytimeContext())
            {
                int page = id;
                s_Page = page;
                count = db.PlaytimeRecords.Count();

                if (id < 0 || id > Playtime.GetLastPage())
                {
                    return RedirectToAction("Index", "Playtime", new { id = 0 });
                }

                int startRecord = recordsPerPage * page;
                var endRecord = startRecord + recordsPerPage;

                int startRecordSorted = count - endRecord;
                int endRecordSorted = count - startRecord;

                var model = db.PlaytimeRecords.ToList();
                model.Reverse();

                var playtimeModelSorted = model
                    .Where(ptm => ptm.Id >= startRecordSorted)
                    .Where(ptm => ptm.Id <= endRecordSorted)
                    .ToList();

                var records = new List<PlaytimeModel>();

                for (int i = startRecord; i < endRecord; i++)
                {
                    if(i < count)
                    {
                        records.Add(model.ElementAt(i));
                    }
                }

                ViewData["Page"] = id + 1;
                return View(records);
            }
        }

        public async Task<IActionResult> Today(int id)
        {
            using (var db = new PlaytimeContext())
            {
                int page = id;
                s_Page = page;

                count = db.PlaytimeRecords
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddHours(-24))
                    .Count();

                if (id < 0 || id > Playtime.GetLastPage())
                {
                    return RedirectToAction("Today", "Playtime", new { id = 0 });
                }

                int startRecord = recordsPerPage * page;
                var endRecord = startRecord + recordsPerPage;

                int startRecordSorted = count - endRecord;
                int endRecordSorted = count - startRecord;

                var model = db.PlaytimeRecords
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddHours(-24))
                    .ToList();

                model.Reverse();

                var playtimeModelSorted = model
                    .Where(ptm => ptm.Id >= startRecordSorted)
                    .Where(ptm => ptm.Id <= endRecordSorted)
                    .ToList();

                var records = new List<PlaytimeModel>();

                for (int i = startRecord; i < endRecord; i++)
                {
                    if (i < count)
                    {
                        records.Add(model.ElementAt(i));
                    }
                }

                ViewData["Page"] = id + 1;
                return View(records);
            }
        }

        public async Task<IActionResult> Week(int id)
        {
            using (var db = new PlaytimeContext())
            {
                int page = id;
                s_Page = page;

                count = db.PlaytimeRecords
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddDays(-7))
                    .Count();

                if (id < 0 || id > Playtime.GetLastPage())
                {
                    return RedirectToAction("Week", "Playtime", new { id = 0 });
                }

                int startRecord = recordsPerPage * page;
                var endRecord = startRecord + recordsPerPage;

                int startRecordSorted = count - endRecord;
                int endRecordSorted = count - startRecord;

                var model = db.PlaytimeRecords
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddDays(-7))
                    .ToList();

                model.Reverse();

                var playtimeModelSorted = model
                    .Where(ptm => ptm.Id >= startRecordSorted)
                    .Where(ptm => ptm.Id <= endRecordSorted)
                    .ToList();

                var records = new List<PlaytimeModel>();

                for (int i = startRecord; i < endRecord; i++)
                {
                    if (i < count)
                    {
                        records.Add(model.ElementAt(i));
                    }
                }

                ViewData["Page"] = id + 1;
                return View(records);
            }
        }

        public async Task<IActionResult> Month(int id)
        {
            using (var db = new PlaytimeContext())
            {
                int page = id;
                s_Page = page;
                count = db.PlaytimeRecords
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddDays(-28))
                    .Count();

                if (id < 0 || id > Playtime.GetLastPage())
                {
                    return RedirectToAction("Month", "Playtime", new { id = 0 });
                }

                int startRecord = recordsPerPage * page;
                var endRecord = startRecord + recordsPerPage;

                int startRecordSorted = count - endRecord;
                int endRecordSorted = count - startRecord;

                var model = db.PlaytimeRecords
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddDays(-28))
                    .ToList();

                model.Reverse();

                var playtimeModelSorted = model
                    .Where(ptm => ptm.Id >= startRecordSorted)
                    .Where(ptm => ptm.Id <= endRecordSorted)
                    .ToList();

                var records = new List<PlaytimeModel>();

                for (int i = startRecord; i < endRecord; i++)
                {
                    if (i < count)
                    {
                        records.Add(model.ElementAt(i));
                    }
                }

                ViewData["Page"] = id + 1;
                return View(records);
            }
        }

        // GET: Playtime/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playtimeModel = await _context.PlaytimeRecords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playtimeModel == null)
            {
                return NotFound();
            }

            return View(playtimeModel);
        }

        // GET: Playtime/Create
        //public async Task<IActionResult> Create()
        //{
        //    return View(await _context.PlaytimeRecords.ToListAsync());
        //}

        public IActionResult Create()
        {
            return View();
        }

        // POST: Playtime/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Game,Finish,Mode")] PlaytimeModel playtimeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playtimeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playtimeModel);
        }

        // GET: Playtime/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playtimeModel = await _context.PlaytimeRecords.FindAsync(id);
            if (playtimeModel == null)
            {
                return NotFound();
            }
            return View(playtimeModel);
        }

        // POST: Playtime/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Game,Finish,Mode")] PlaytimeModel playtimeModel)
        {
            if (id != playtimeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playtimeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaytimeModelExists(playtimeModel.Id))
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
            return View(playtimeModel);
        }

        // GET: Playtime/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playtimeModel = await _context.PlaytimeRecords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playtimeModel == null)
            {
                return NotFound();
            }

            return View(playtimeModel);
        }

        // POST: Playtime/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playtimeModel = await _context.PlaytimeRecords.FindAsync(id);
            _context.PlaytimeRecords.Remove(playtimeModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaytimeModelExists(int id)
        {
            return _context.PlaytimeRecords.Any(e => e.Id == id);
        }
    }
}
