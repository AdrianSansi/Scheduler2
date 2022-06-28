using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler2
{
    public class WeekSettings
    {
        
        public bool Monday { get; set; } = false;
        public bool Tuesday { get; set; } = false; 
        public bool Wednesday { get; set; } = false;
        public bool Thursday { get; set; } = false; 
        public bool Friday { get; set; } = false; 
        public bool Saturday { get; set; } = false;
        public bool Sunday { get; set; } = false;
        public List<int> WeekDays { get; set; } = new List<int>();

    }
}
