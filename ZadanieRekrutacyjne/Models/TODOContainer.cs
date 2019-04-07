using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZadanieRekrutacyjne.Models
{
    public class TODOContainer
    {
        public virtual ApplicationUser User { get; set; }

        public int ID { get; set; }

        public string Title { get; set; }
        public string Group { get; set; }
        public string Tag { get; set; }
        public DateTime RemindDate { get; set; }

        public bool IsDone { get; set; }
    }
}