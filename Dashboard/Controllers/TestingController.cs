using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Dashboard.Models;

namespace Dashboard.Controllers
{
    public class TestingController : Controller
    {
        private List<TestingModel> TestingList = new List<TestingModel>
            {
                new TestingModel() { TestId = 1, TestName = "First Test", TestAge = 5 },
                new TestingModel() { TestId = 2, TestName = "Second Test", TestAge = 3 },
                new TestingModel() { TestId = 3, TestName = "Final Test", TestAge = 2 }
            };

        public ActionResult Index()
        {
            return View(TestingList);
        }

        public string Details(int id)
        {
            return TestingList[id - 1].TestId.ToString() + ", " + TestingList[id - 1].TestName.ToString() + ", " + TestingList[id - 1].TestAge.ToString();
        }
    }
}