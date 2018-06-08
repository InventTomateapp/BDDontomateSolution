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
    public class PERSONASController : ApiController
    {
        private BdAppDonTomateEntities db = new BdAppDonTomateEntities();

        // GET: api/PERSONAS
        public IQueryable<PERSONAS> GetPERSONAS()
        {
            return db.PERSONAS;
        }

        // GET: api/PERSONAS/5
        [ResponseType(typeof(PERSONAS))]
        public async Task<IHttpActionResult> GetPERSONAS(int id)
        {
            PERSONAS pERSONAS = await db.PERSONAS.FindAsync(id);
            if (pERSONAS == null)
            {
                return NotFound();
            }

            return Ok(pERSONAS);
        }

        // PUT: api/PERSONAS/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPERSONAS(int id, PERSONAS pERSONAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pERSONAS.IDPERSONA)
            {
                return BadRequest();
            }

            db.Entry(pERSONAS).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PERSONASExists(id))
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

        // POST: api/PERSONAS
        [ResponseType(typeof(PERSONAS))]
        public async Task<IHttpActionResult> PostPERSONAS(PERSONAS pERSONAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PERSONAS.Add(pERSONAS);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pERSONAS.IDPERSONA }, pERSONAS);
        }

        // DELETE: api/PERSONAS/5
        [ResponseType(typeof(PERSONAS))]
        public async Task<IHttpActionResult> DeletePERSONAS(int id)
        {
            PERSONAS pERSONAS = await db.PERSONAS.FindAsync(id);
            if (pERSONAS == null)
            {
                return NotFound();
            }

            db.PERSONAS.Remove(pERSONAS);
            await db.SaveChangesAsync();

            return Ok(pERSONAS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PERSONASExists(int id)
        {
            return db.PERSONAS.Count(e => e.IDPERSONA == id) > 0;
        }
    }
}