using AspSession42.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspSession42.Controllers
{
    [ApiController]
    [Authorize]
    public class EventController : Controller
    {
        private RoadOfRussiaContext db;
        public EventController(RoadOfRussiaContext db)
        {
            this.db = db;
        }
        [HttpGet]
        [Route("Events")]
        public IQueryable GetEvents()
        {
            var events = from e in db.Events
                         select new
                         {
                             EventName = e.EventName,
                             EventDate = e.DateOfEvent.ToString("dd.MM.yyyy"),
                             Author = db.Employees.FirstOrDefault(p => p.IdEmployee.ToString() == e.EventManagers)!.Surname +
                             " " + db.Employees.FirstOrDefault(p => p.IdEmployee.ToString() == e.EventManagers)!.FirstName.Substring(0, 1) + ". "
                             + db.Employees.FirstOrDefault(p => p.IdEmployee.ToString() == e.EventManagers)!.SecondName!.Substring(0, 1) + ".",
                             Description = e.EventDescription
                         };
            return events.AsQueryable();

        }

    }
}
