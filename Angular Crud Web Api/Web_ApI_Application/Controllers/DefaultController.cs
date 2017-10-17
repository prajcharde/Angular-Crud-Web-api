using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Web_ApI_Application.Models;

namespace Web_ApI_Application.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class DefaultController : ApiController
    {
        // GET: api/Default
        private MemberContext context;
        public DefaultController()
        {
            context = new MemberContext();
        }
        // GET: api/Default
        public IHttpActionResult Get()
        {
            var res=context.Members.ToList();
            return Ok(res);
        }

        // GET: api/Default/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Default
        public IHttpActionResult Post(Member value)
        {
            context.Members.Add(value);
            context.SaveChanges();
            return Ok("Ok");
        }

        // PUT: api/Default/5
        public IHttpActionResult Put(int id,Member member)
        {
            var res = context.Members.SingleOrDefault(c => c.MemId == id);
            res.MemberName = member.MemberName;
            res.MemberEmail = member.MemberEmail;
            res.Address = member.Address;
            context.SaveChanges();
            return Ok("Ok");
        }

        // DELETE: api/Default/5
        public IHttpActionResult Delete(int id)
        {
            var res = context.Members.Find(id);
            context.Members.Remove(res);
            context.SaveChanges();
            return Ok("Ok");
        }
    }
}
