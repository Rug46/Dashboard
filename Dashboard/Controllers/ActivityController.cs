﻿using System;
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
    public class ActivityController : Controller
    {
        private readonly ActivityContext _context;

        public static int recordsPerPage = 10;
        public static int count;
        public static int s_Page;


        public ActivityController(ActivityContext context)
        {
            _context = context;
        }

        // GET: Activity
        public async Task<IActionResult> Index(int id)
        {
            using(var db = new ActivityContext())
            {
                int page = id;
                s_Page = page;
                count = db.ActivityRecords.Count();

                if (id < 0 || id > Activity.GetLastPage())
                {
                    return RedirectToAction("Index", "Activity", new { id = 0 });
                }

                int startRecord = recordsPerPage * page;
                int endRecord = startRecord + recordsPerPage;

                int startRecordSorted = count - endRecord;
                int endRecordSorted = count - startRecord;

                var model = db.ActivityRecords.ToList();
                model.Reverse();

                var records = new List<ActivityModel>();

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
            using (var db = new ActivityContext())
            {
                int page = id;
                s_Page = page;

                count = db.ActivityRecords
                    .Where(ptm => ptm.Date.Date >= DateTime.Now.AddHours(-24))
                    .Count();

                if (id < 0 || id > Activity.GetLastPage())
                {
                    return RedirectToAction("Today", "Activity", new { id = 0 });
                }

                int startRecord = recordsPerPage * page;
                int endRecord = startRecord + recordsPerPage;

                int startRecordSorted = count - endRecord;
                int endRecordSorted = count - startRecord;

                var model = db.ActivityRecords
                    .Where(am => am.Date.Date >= DateTime.Now.AddHours(-24))
                    .ToList();

                model.Reverse();

                var activityModelSorted = model
                    .Where(am => am.Id >= startRecordSorted)
                    .Where(am => am.Id <= endRecordSorted)
                    .ToList();

                var records = new List<ActivityModel>();

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
            using (var db = new ActivityContext())
            {
                int page = id;
                s_Page = page;

                count = db.ActivityRecords
                    .Where(am => am.Date.Date >= DateTime.Now.AddDays(-7))
                    .Count();

                if (id < 0 || id > Activity.GetLastPage())
                {
                    return RedirectToAction("Week", "Activity", new { id = 0 });
                }

                int startRecord = recordsPerPage * page;
                int endRecord = startRecord + recordsPerPage;

                int startRecordSorted = count - endRecord;
                int endRecordSorted = count - startRecord;

                var model = db.ActivityRecords
                    .Where(am => am.Date.Date >= DateTime.Now.AddDays(-7))
                    .ToList();

                model.Reverse();

                var records = new List<ActivityModel>();

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
            using (var db = new ActivityContext())
            {
                int page = id;
                s_Page = page;
                count = db.ActivityRecords
                    .Where(am => am.Date.Date >= DateTime.Now.AddDays(-28))
                    .Count();

                if (id < 0 || id > Activity.GetLastPage())
                {
                    return RedirectToAction("Month", "Activity", new { id = 0 });
                }

                int startRecord = recordsPerPage * page;
                int endRecord = startRecord + recordsPerPage;

                int startRecordSorted = count - endRecord;
                int endRecordSorted = count - startRecord;

                var model = db.ActivityRecords
                    .Where(am => am.Date.Date >= DateTime.Now.AddDays(-28))
                    .ToList();

                model.Reverse();

                var records = new List<ActivityModel>();

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

        // GET: Activity/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityModel = await _context.ActivityRecords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activityModel == null)
            {
                return NotFound();
            }

            return View(activityModel);
        }

        // GET: Activity/Create
        //public async Task<IActionResult> Create()
        //{
        //    return View(await _context.ActivityRecords.ToListAsync());
        //}

        public IActionResult Create()
        {
            return View();
        }

        // POST: Activity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Game,Finish,Mode")] ActivityModel activityModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activityModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activityModel);
        }

        // GET: Activity/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityModel = await _context.ActivityRecords.FindAsync(id);
            if (activityModel == null)
            {
                return NotFound();
            }
            return View(activityModel);
        }

        // POST: Activity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Game,Finish,Mode")] ActivityModel activityModel)
        {
            if (id != activityModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activityModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityModelExists(activityModel.Id))
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
            return View(activityModel);
        }

        // GET: Activity/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityModel = await _context.ActivityRecords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activityModel == null)
            {
                return NotFound();
            }

            return View(activityModel);
        }

        // POST: Activity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activityModel = await _context.ActivityRecords.FindAsync(id);
            _context.ActivityRecords.Remove(activityModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityModelExists(int id)
        {
            return _context.ActivityRecords.Any(e => e.Id == id);
        }
    }
}