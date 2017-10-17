using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_ApI_Application.Dtos;
using Web_ApI_Application.Models;

namespace Web_ApI_Application.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Member, MemberDto>();
            CreateMap<MemberDto, Member>();
        }
    }
}