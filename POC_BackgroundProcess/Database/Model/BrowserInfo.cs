using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_BackGroundProcess.Database.Model
{
    public class BrowserInfo
    {
        [Key]
        public int Id { get; set; }
        public string? BrowserName { get; set; }
        public string? Url { get; set; }
    }
}
