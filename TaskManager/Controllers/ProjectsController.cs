using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using TaskManager.Models;
using System.Web.Http.Description;
using System.Data.Entity;

namespace TaskManager.Controllers
{

  
    public class ProjectsController : ApiController
    {

        private TaskManagerEntities db = new TaskManagerEntities();
        [ResponseType(typeof(List<ProjectTable>))]
        [Route("api/projects/{search}")]
        public IHttpActionResult GetProject(string search)
        {
            List<ProjectTable> proj = db.ProjectTables.Where(p => p.Project.Contains(search)).ToList();
            if (proj == null)
            {
                return NotFound();
            }
            return Ok(proj);
        }
       

        //Get Manager {user}  with manager role on search
        [ResponseType(typeof(List<UsersTable>))]
        [Route("api/manager/{search}")]
       
        public IHttpActionResult GetManager(string search)
        {
            List<UsersTable> manager = db.UsersTables.Where(u => u.First_Name.Contains(search) || u.Last_Name.Contains(search)).ToList();
            if (manager == null)
            {
                return NotFound();
            }
            return Ok(manager);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // POST: api/ProjectTables
        [ResponseType(typeof(ProjectTable))]
        [Route("api/SaveProjectTable")]
        public IHttpActionResult SaveProjectTable(ProjectTable projectTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProjectTables.Add(projectTable);
            db.SaveChanges();


            return CreatedAtRoute("DefaultApi", new { id = projectTable.Project_ID }, projectTable);
        }


        // PUT: api/ProjectTables/5
        [ResponseType(typeof(void))]
        [Route("api/UpdateProjectTable")]
        public IHttpActionResult UpdateProjectTable(int id, ProjectTable projectTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projectTable.Project_ID)
            {
                return BadRequest();
            }

            db.Entry(projectTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException)
            {
                if (!ProjectTableExists(id))
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

        // DELETE: api/ProjectTables/5
        [ResponseType(typeof(ProjectTable))]
        [Route("api/SuspendProjectTable")]
        public IHttpActionResult SuspendProjectTable(int id)
        {
            ProjectTable projectTable = db.ProjectTables.Find(id);
            if (projectTable == null)
            {
                return NotFound();
            }

            db.ProjectTables.Remove(projectTable);
            db.SaveChanges();
            return Ok(projectTable);
        }

        [Route("api/ProjectTableExists")]
        private bool ProjectTableExists(int id)
        {
            return db.TaskTables.Count(e => e.Project_ID == id) > 0;
        }
    }
}

