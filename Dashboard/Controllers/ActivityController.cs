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
    public class ActivityController : Controller
    {
        private readonly Database _context;

        public static int recordsPerPage = 10;
        public static int count;
        public static int s_Page;


        public ActivityController(Database context)
        {
            _context = context;
        }

        // GET: Activity
        public async Task<IActionResult> Index(int id)
        {
            using(var db = new Database())
            {
                int page = id;
                s_Page = page;
                count = db.Activity.Count();

                if (id < 0)
                {
                    return RedirectToAction("Index", "Activity", new { id = 0 });
                }

                if (id >= Activity.GetLastPage())
                {
                    return RedirectToAction("Index", "Activity", new { id = Activity.GetLastPage() - 1 });
                }

                int startRecord = recordsPerPage * page;
                int endRecord = startRecord + recordsPerPage;

                int startRecordSorted = count - endRecord;
                int endRecordSorted = count - startRecord;

                var model = db.Activity.ToList();
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
            using (var db = new Database())
            {
                int page = id;
                s_Page = page;

                count = db.Activity
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

                var model = db.Activity
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
            using (var db = new Database())
            {
                int page = id;
                s_Page = page;

                count = db.Activity
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

                var model = db.Activity
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
            using (var db = new Database())
            {
                int page = id;
                s_Page = page;
                count = db.Activity
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

                var model = db.Activity
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

            var activityModel = await _context.Activity
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
        //public async Task<IActionResult> Create([Bind("Id,Date,Game,Finish,Mode")] ActivityModel activityModel)
        public async Task<IActionResult> Create(int id, DateTime DateStart, string GameName, DateTime DateFinish, string ModeName)
        {
            ActivityModel activityModel = new ActivityModel
            {
                Date = DateStart,
                Game = GameName,
                Finish = DateFinish,
                Mode = ModeName
            };

            Activity.AddNew(activityModel);

            return RedirectToAction("Index");
        }

        // GET: Activity/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityModel = await _context.Activity.FindAsync(id);
            if (activityModel == null)
            {
                return NotFound();
            }

            activityModel.Game = activityModel.Game.Trim();
            activityModel.Mode = activityModel.Mode.Trim();

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

            var activityModel = await _context.Activity
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
            var activityModel = await _context.Activity.FindAsync(id);
            _context.Activity.Remove(activityModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityModelExists(int id)
        {
            return _context.Activity.Any(e => e.Id == id);
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(DateTime SearchDate)
        {
            string dateFormatted = SearchDate.Day + "/" + SearchDate.Month + "/" + SearchDate.Year;
            TempData["Day"] = dateFormatted;

            return View();
        }

        [HttpGet]
        public IActionResult Game()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Game(int GameID)
        {
            if(GameID == 0)
            {
                TempData["None"] = "Please select a game";
                return View();
            }

            string Name = Games.GetGame(GameID);

            TempData["Id"] = GameID;
            TempData["Game"] = Name;

            return View();
        }

        public IActionResult Timeline()
        {
            return View();
        }
    }
}
