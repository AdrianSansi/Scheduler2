
using System.Data.Entity;


namespace Scheduler2
{
    public class SchedulerDb : DbContext
    {
        public virtual DbSet<Settings>? Settings { get; set; }
              
       
    }
}
