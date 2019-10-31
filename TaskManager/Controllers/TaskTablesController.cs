using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class TaskTablesController : ApiController
    {
        private TaskManagerEntities db = new TaskManagerEntities();

        // GET: api/GetTaskTables
        [Route("api/GetTaskTables")]
        public IQueryable<TaskTable> GetTaskTables()
        {
            return db.TaskTables;
        }

        // GET: api/TaskTables/5
        [ResponseType(typeof(TaskTable))]
        [Route("api/GetTaskTable")]
        public IHttpActionResult GetTaskTable(int id)
        {
            TaskTable taskTable = db.TaskTables.Find(id);
            if (taskTable == null)
            {
                return NotFound();
            }

            return Ok(taskTable);
        }

        // PUT: api/TaskTables/5
        [ResponseType(typeof(void))]
        [Route("api/UpdateTaskTable")]
        public IHttpActionResult UpdateTaskTable(int id, TaskTable taskTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taskTable.Task_ID)
            {
                return BadRequest();
            }

            db.Entry(taskTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskTableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TaskTables
        [ResponseType(typeof(TaskTable))]
        [Route("api/SaveTaskTable")]
        public IHttpActionResult SaveTaskTable(TaskTable taskTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TaskTables.Add(taskTable);
            db.SaveChanges();
   

            return CreatedAtRoute("DefaultApi", new { id = taskTable.Task_ID }, taskTable);
        }

        // DELETE: api/TaskTables/5
        [ResponseType(typeof(TaskTable))]
        [Route("api/DeleteTaskTable")]
        public IHttpActionResult DeleteTaskTable(int id)
        {
            TaskTable taskTable = db.TaskTables.Find(id);
            if (taskTable == null)
            {
                return NotFound();
            }

            db.TaskTables.Remove(taskTable);
            db.SaveChanges();
            return Ok(taskTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [Route("api/TaskTableExists")]
        private bool TaskTableExists(int id)
        {
            return db.TaskTables.Count(e => e.Task_ID == id) > 0;
        }

    }
}