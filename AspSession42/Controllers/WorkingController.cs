using AspSession42.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspSession42.Controllers
{
    [ApiController]
    public class WorkingController : ControllerBase
    {
        private RoadOfRussiaContext db;
        public WorkingController(RoadOfRussiaContext db)
        {
            this.db = db;
        }
        [HttpGet]
        [Route("WorkingDays")]
        public IQueryable GetWorkingDays()
        {
            var days = from d in db.WorkingCalendars
                       select new
                       {
                           d.Id,
                           d.ExceptionDate,
                           d.IsWorkingDay
                       };
            return days.AsQueryable();
        }
    }
}
