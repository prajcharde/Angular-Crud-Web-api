using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_ApI_Application.Models
{
    public class Member
    {
        [Key]
        public int MemId { get; set; }
        public string MemberName { get; set; }
        public string MemberEmail { get; set; }
        public string Address { get; set; }

    }
}