using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class AddUserTableController : ApiController
    {
        private TaskManagerEntities db = new TaskManagerEntities();

        // GET: api/GetAllUsers
        [Route("api/GetAllUsers")]
        public IQueryable<UsersTable> GetAllUsers()
        {
            return db.UsersTables;
        }


        // GET: api/GetUserTable/1
        [ResponseType(typeof(UsersTable))]
        [Route("api/GetUserTable")]
        public IHttpActionResult GetUserTable(int id)
        {
            UsersTable usertable = db.UsersTables.Find(id);
            if (usertable == null)
            {
                return NotFound();
            }

            return Ok(usertable);
        }


        // PUT: api/UpdateUserTable/5
        [ResponseType(typeof(void))]
        [Route("api/UpdateUserTable")]
        public IHttpActionResult UpdateTaskTable(int id, UsersTable usertable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usertable.User_ID)
            {
                return BadRequest();
            }

            db.Entry(usertable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTableExists(id))
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




        // POST: api/SaveUsersTable
        [ResponseType(typeof(UsersTable))]
        [Route("api/SaveUsersTable")]
        public IHttpActionResult SaveUsersTable(UsersTable usertable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UsersTables.Add(usertable);
            db.SaveChanges();


            return CreatedAtRoute("DefaultApi", new { id = usertable.User_ID }, usertable);
        }

        // DELETE: api/DeleteUserTable/1
        [ResponseType(typeof(UsersTable))]
        [Route("api/DeleteUserTable")]
        public IHttpActionResult DeleteUserTable(int id)
        {
            UsersTable usertable = db.UsersTables.Find(id);
            if (usertable == null)
            {
                return NotFound();
            }

            db.UsersTables.Remove(usertable);
            db.SaveChanges();
            return Ok(usertable);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [Route("api/UserTableExists")]
        private bool UserTableExists(int id)
        {
            return db.UsersTables.Count(e => e.User_ID == id) > 0;
        }

        //[ResponseType(typeof(UsersTable))]
        //[Route("api/SaveNewUsers")]
        //public IHttpActionResult SaveNewUsers(AddUserTable user)
        //{
        //    if(!ModelState.IsValid)
        //        return BadRequest("Invalid data.");

        //    using (var ctx = new TaskManagerEntities())
        //    {
        //        ctx.UsersTables.Add(new UsersTable()


        //        {
        //            Employee_ID = user.Employee_ID,
        //            First_Name = user.First_Name,
        //            Last_Name = user.Last_Name
        //        });

        //        ctx.SaveChanges();
        //    }
        //    return Ok();

        //}

    }
}
