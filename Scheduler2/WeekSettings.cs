using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler2
{
    public class WeekSettings
    {
        public bool monday { get; set; } = false;
        public bool tuesday { get; set; } = false; 
        public bool wednesday { get; set; } = false;
        public bool thursday { get; set; } = false; 
        public bool friday { get; set; } = false; 
        public bool saturday { get; set; } = false;
        public bool sunday { get; set; } = false;

        List<int> weekDays = new List<int>();

        public WeekSettings()
        {

        }
    }
}
