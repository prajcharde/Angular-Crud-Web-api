using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_ApI_Application.Dtos
{
    public class MemberDto
    {
        public int MemId { get;  set; }
        public string MemberName { get; set; }
        public string MemberEmail { get; set; }
        public string Address { get; set; }
    }
}