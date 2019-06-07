using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Models
{
    public class SettingModel
    {
        [Key]
        public int SettingId { get; set; }
        public string SettingName { get; set; }
        public string SettingDefault { get; set; }
    }
}
