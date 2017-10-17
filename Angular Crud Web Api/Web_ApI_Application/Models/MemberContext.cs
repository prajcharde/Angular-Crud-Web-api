using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Web_ApI_Application.Models
{
    public class MemberContext:DbContext
    {
        public MemberContext():base("MyConnection") {}

        public DbSet<Member>Members{get;set;}
    }
}