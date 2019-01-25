using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Controllers;

namespace Dashboard.Data
{
    public class Playtime
    {
        public static int GetLastPage()
        {
            var recordsPerPage = PlaytimeController.recordsPerPage;
            var count = PlaytimeController.count;

            var LastPage = (decimal) count / recordsPerPage;
            var LastPageRounded = Math.Ceiling(LastPage);

            return (int) LastPageRounded;
        }

        public static int GetCurrentPage()
        {
            return PlaytimeController.s_Page + 1;
        }
    }
}
