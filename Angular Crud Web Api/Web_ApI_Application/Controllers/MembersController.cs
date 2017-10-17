using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Web_ApI_Application.Models;

namespace Web_ApI_Application.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class MembersController : ApiController
    {
        private MemberContext db = new MemberContext();

        // GET: api/Members
        public IQueryable<Member> GetMembers()
        {
            return db.Members;
        }

        // GET: api/Members/5
        [ResponseType(typeof(Member))]
        public IHttpActionResult GetMember(int id)
        {
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        // PUT: api/Members/5
        [ResponseType (typeof(void))]
        //[HttpPut]
        //[Route("api/Members/PutMember/{id}")]
        public IHttpActionResult PutMember(int id, Member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != member.MemId)
            {
                return BadRequest();
            }

            db.Entry(member).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
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

        // POST: api/Members
        [ResponseType(typeof(Member))]
        public IHttpActionResult PostMember(Member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Members.Add(member);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = member.MemId }, member);
        }

        // DELETE: api/Members/5
        [ResponseType(typeof(Member))]
        public IHttpActionResult DeleteMember(int id)
        {
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return NotFound();
            }

            db.Members.Remove(member);
            db.SaveChanges();

            return Ok(member);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MemberExists(int id)
        {
            return db.Members.Count(e => e.MemId == id) > 0;
        }
    }
}