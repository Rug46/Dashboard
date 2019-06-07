using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Data;
using Dashboard.Models;

namespace Dashboard.Helpers
{
    public class Wishlist
    {
        public static List<WishlistModel> GetUserWishlist(int userid)
        {
            using (var db = new Database())
            {
                var records = db.Wishlist
                    .Where(w => w.UserId == userid)
                    .OrderBy(w => w.GameName)
                    .ToList();

                return records;
            }
        }

        public static List<WishlistModel> GetUserWishlistUnarchived(int userid)
        {
            var records = GetUserWishlist(userid)
                .Where(w => w.Archived == 0)
                .ToList();

            return records;
        }

        public static void AddWishlist(int userid, string gameName, string consoleName)
        {
            using (var db = new Database())
            {
                var record = new WishlistModel
                {
                    GameName = gameName,
                    ConsoleName = consoleName,
                    UserId = userid
                };

                db.Wishlist.Add(record);
                db.SaveChanges();
            }
        }

        public static void RemoveWishlist(int id, int userid)
        {
            using (var db = new Database())
            {
                var records = db.Wishlist
                    .Where(wm => wm.Id == id)
                    .ToList();

                if (records.Count != 1)
                {
                    return;
                }

                if (records.ElementAt(0).UserId != userid)
                {
                    return;
                }

                db.Remove(records.ElementAt(0));
                db.SaveChanges();
            }
        }

        public static void ArchiveWishlist(int id, int parentid)
        {
            using (var db = new Database())
            {
                var records = db.Wishlist
                    .Where(wm => wm.Id == id)
                    .ToList();

                if (records.Count != 1)
                {
                    return;
                }

                if (!Account.IsChildOf(parentid, records.ElementAt(0).UserId))
                {
                    return;
                }

                records.ElementAt(0).Archived = 1;
                db.SaveChanges();
            }
        }
    }
}
