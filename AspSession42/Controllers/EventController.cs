﻿using AspSession42.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspSession42.Controllers
{
    [ApiController]
    public class EventController : ControllerBase
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
            var ev = from e in db.Events
                     select new
                     {
                         e.IdEvent,
                         e.EventName,
                         e.TypeOfEvent,
                         e.EventStatus,
                         e.EventDescription,
                         e.DateOfEvent,
                         EventManagers = db.Employees.FirstOrDefault(p => p.IdEmployee.ToString() == e.EventManagers)!.IdEmployee,
                         e.TypeOfClass
                     };
            return ev.AsQueryable();

        }

    }
}
