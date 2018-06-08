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
    public class PRODUCTOSController : ApiController
    {
        private BdAppDonTomateEntities db = new BdAppDonTomateEntities();

        // GET: api/PRODUCTOS
        public IQueryable<PRODUCTOS> GetPRODUCTOS()
        {
            return db.PRODUCTOS;
        }

        // GET: api/PRODUCTOS/5
        [ResponseType(typeof(PRODUCTOS))]
        public async Task<IHttpActionResult> GetPRODUCTOS(string id)
        {
            PRODUCTOS pRODUCTOS = await db.PRODUCTOS.FindAsync(id);
            if (pRODUCTOS == null)
            {
                return NotFound();
            }

            return Ok(pRODUCTOS);
        }

        // PUT: api/PRODUCTOS/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPRODUCTOS(string id, PRODUCTOS pRODUCTOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pRODUCTOS.IDPRODUCTO)
            {
                return BadRequest();
            }

            db.Entry(pRODUCTOS).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PRODUCTOSExists(id))
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

        // POST: api/PRODUCTOS
        [ResponseType(typeof(PRODUCTOS))]
        public async Task<IHttpActionResult> PostPRODUCTOS(PRODUCTOS pRODUCTOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PRODUCTOS.Add(pRODUCTOS);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PRODUCTOSExists(pRODUCTOS.IDPRODUCTO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pRODUCTOS.IDPRODUCTO }, pRODUCTOS);
        }

        // DELETE: api/PRODUCTOS/5
        [ResponseType(typeof(PRODUCTOS))]
        public async Task<IHttpActionResult> DeletePRODUCTOS(string id)
        {
            PRODUCTOS pRODUCTOS = await db.PRODUCTOS.FindAsync(id);
            if (pRODUCTOS == null)
            {
                return NotFound();
            }

            db.PRODUCTOS.Remove(pRODUCTOS);
            await db.SaveChangesAsync();

            return Ok(pRODUCTOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PRODUCTOSExists(string id)
        {
            return db.PRODUCTOS.Count(e => e.IDPRODUCTO == id) > 0;
        }
    }
}