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
using BDDontomate;

namespace BDDontomate.Controllers.Api
{
    public class PERFILESController : ApiController
    {
        private BdAppDonTomateEntities db = new BdAppDonTomateEntities();

        // GET: api/PERFILES
        public IQueryable<PERFILES> GetPERFILES()
        {
            return db.PERFILES;
        }

        // GET: api/PERFILES/5
        [ResponseType(typeof(PERFILES))]
        public async Task<IHttpActionResult> GetPERFILES(int id)
        {
            PERFILES pERFILES = await db.PERFILES.FindAsync(id);
            if (pERFILES == null)
            {
                return NotFound();
            }

            return Ok(pERFILES);
        }

        // PUT: api/PERFILES/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPERFILES(int id, PERFILES pERFILES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pERFILES.IDPERFIL)
            {
                return BadRequest();
            }

            db.Entry(pERFILES).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PERFILESExists(id))
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

        // POST: api/PERFILES
        [ResponseType(typeof(PERFILES))]
        public async Task<IHttpActionResult> PostPERFILES(PERFILES pERFILES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PERFILES.Add(pERFILES);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pERFILES.IDPERFIL }, pERFILES);
        }

        // DELETE: api/PERFILES/5
        [ResponseType(typeof(PERFILES))]
        public async Task<IHttpActionResult> DeletePERFILES(int id)
        {
            PERFILES pERFILES = await db.PERFILES.FindAsync(id);
            if (pERFILES == null)
            {
                return NotFound();
            }

            db.PERFILES.Remove(pERFILES);
            await db.SaveChangesAsync();

            return Ok(pERFILES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PERFILESExists(int id)
        {
            return db.PERFILES.Count(e => e.IDPERFIL == id) > 0;
        }
    }
}