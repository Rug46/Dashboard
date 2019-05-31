using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Models
{
    public class UserSettingModel
    {
        [Key]
        public int UserSettingId { get; set; }
        public int SettingId { get; set; }
        public int UserId { get; set; }
        public string Value { get; set; }
    }
}
