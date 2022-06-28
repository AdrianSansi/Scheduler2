using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler2
{
    public static class DBManager
    {
        public static void StoreSettings(Settings settings)
        {
            using var scheduleDataBase = new SchedulerDb();
            scheduleDataBase.Settings.Add(settings);
            scheduleDataBase.SaveChanges();
        }

        public static void DeleteSettings(int key)
        {
            using var scheduleDataBase = new SchedulerDb();
            Settings element;
            element = scheduleDataBase.Settings.Where(d => d.Id == key).First();
            scheduleDataBase.Settings.Remove(element);

            scheduleDataBase.SaveChanges();      
        }

        public static void UpdateSettings()
        {
            using var scheduleDataBase = new SchedulerDb();
            scheduleDataBase.SaveChanges();
        }

        public static List<int> OutDateSchedules()
        {
            using var scheduleDataBase = new SchedulerDb();
            var outdates = from b in scheduleDataBase.Settings where b.CurrentDate > b.TimeDate select b;
            
            List<int> outdatesKeys = new List<int>();
           
            foreach (var outdate in outdates)
            {
                outdatesKeys.Add(outdate.Id);
            }
            return outdatesKeys;
        }
    }
}
