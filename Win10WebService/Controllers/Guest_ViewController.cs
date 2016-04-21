using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Win10WebService;

namespace Win10WebService.Controllers
{
    public class Guest_ViewController : ApiController
    {
        private GuestViewDBContext db = new GuestViewDBContext();

        // GET: api/Guest_View
        public IQueryable<Guest_View> GetGuest_View()
        {
            return db.Guest_View;
        }

        // GET: api/Guest_View/5
        [ResponseType(typeof(Guest_View))]
        public async Task<IHttpActionResult> GetGuest_View(string id)
        {
            Guest_View guest_View = await db.Guest_View.FindAsync(id);
            if (guest_View == null)
            {
                return NotFound();
            }

            return Ok(guest_View);
        }

        // PUT: api/Guest_View/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGuest_View(string id, Guest_View guest_View)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != guest_View.Name)
            {
                return BadRequest();
            }

            db.Entry(guest_View).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Guest_ViewExists(id))
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

        // POST: api/Guest_View
        [ResponseType(typeof(Guest_View))]
        public async Task<IHttpActionResult> PostGuest_View(Guest_View guest_View)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Guest_View.Add(guest_View);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Guest_ViewExists(guest_View.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = guest_View.Name }, guest_View);
        }

        // DELETE: api/Guest_View/5
        [ResponseType(typeof(Guest_View))]
        public async Task<IHttpActionResult> DeleteGuest_View(string id)
        {
            Guest_View guest_View = await db.Guest_View.FindAsync(id);
            if (guest_View == null)
            {
                return NotFound();
            }

            db.Guest_View.Remove(guest_View);
            await db.SaveChangesAsync();

            return Ok(guest_View);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Guest_ViewExists(string id)
        {
            return db.Guest_View.Count(e => e.Name == id) > 0;
        }
    }
}