using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Web_ApI_Application.Dtos;
using Web_ApI_Application.Models;

namespace Web_ApI_Application.Models
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/Member")]
    public class MemberController : ApiController
    {
        private MemberContext context;   
        public MemberController()
        {
            context = new MemberContext();
        }
        // GET api/values
        public IEnumerable<Member> Get()
        {
            return context.Members.ToList();

        }
        public MemberDto Get(int id)
        {
            var member = context.Members.SingleOrDefault(c => c.MemId == id);
            if (member == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Member, MemberDto>(member);
        }
        
        //By using IHttpActionResult
        [HttpPost]
        public IHttpActionResult CreateMember(MemberDto memberDto)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
            return BadRequest();
            var member = Mapper.Map<MemberDto, Member>(memberDto);
            context.Members.Add(member);
            context.SaveChanges();
            memberDto.MemId = member.MemId;
            return Created(new Uri(Request.RequestUri + "/" + member.MemId), memberDto);
        }
         [HttpPut]
         [Route("api/Member/UpdateMember/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateMember(int id, MemberDto memberDto)
       {
           if (!ModelState.IsValid)
               throw new HttpResponseException(HttpStatusCode.BadRequest);
           var memberInDb = context.Members.SingleOrDefault(c => c.MemId == id);
           if (memberInDb == null)
               throw new HttpResponseException(HttpStatusCode.NotFound);
           Mapper.Map(memberDto, memberInDb);
           memberInDb.MemberName = memberDto.MemberName;
           memberInDb.MemberEmail =memberDto.MemberEmail;
           memberInDb.Address = memberDto.Address;
           context.SaveChanges();
           return Ok();
       }
        [HttpDelete]
        public IHttpActionResult DeleteMember(int id)
        {
            var memberInDb = context.Members.SingleOrDefault(c => c.MemId == id);
            if (memberInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            context.Members.Remove(memberInDb);
            return Ok();
         }
         

    }
}














































































































