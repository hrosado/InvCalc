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
using InvCalc.Models;

namespace InvCalc.Controllers
{
    public class PAPIController : ApiController
    {
        private InvCalcEntities db = new InvCalcEntities();

        // GET: api/PAPI
        public IQueryable<PrimaryTable> GetPrimaryTables()
        {
            return db.PrimaryTables;
        }

        // GET: api/PAPI/5
        [ResponseType(typeof(PrimaryTable))]
        public async Task<IHttpActionResult> GetPrimaryTable(int id)
        {
            PrimaryTable primaryTable = await db.PrimaryTables.FindAsync(id);
            if (primaryTable == null)
            {
                return NotFound();
            }

            return Ok(primaryTable);
        }

        // PUT: api/PAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPrimaryTable(int id, PrimaryTable primaryTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != primaryTable.ID)
            {
                return BadRequest();
            }

            db.Entry(primaryTable).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrimaryTableExists(id))
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

        // POST: api/PAPI
        [ResponseType(typeof(PrimaryTable))]
        public async Task<IHttpActionResult> PostPrimaryTable(PrimaryTable primaryTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PrimaryTables.Add(primaryTable);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = primaryTable.ID }, primaryTable);
        }

        // DELETE: api/PAPI/5
        [ResponseType(typeof(PrimaryTable))]
        public async Task<IHttpActionResult> DeletePrimaryTable(int id)
        {
            PrimaryTable primaryTable = await db.PrimaryTables.FindAsync(id);
            if (primaryTable == null)
            {
                return NotFound();
            }

            db.PrimaryTables.Remove(primaryTable);
            await db.SaveChangesAsync();

            return Ok(primaryTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrimaryTableExists(int id)
        {
            return db.PrimaryTables.Count(e => e.ID == id) > 0;
        }
    }
}