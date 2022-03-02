using AutoMapper;
using Midly.Dtos;
using Midly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Midly.App_Start
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            // Domain To Dto 
         
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            //  Dto To Domain   
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c=>c.Id, opt=>opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());
             
        }
    }
}