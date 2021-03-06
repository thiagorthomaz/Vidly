﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Customer, CustomerDto>();
                cfg.CreateMap<Movie, MovieDto>();
                cfg.CreateMap<MembershipType, MembershipTypeDto>();
                cfg.CreateMap<Rental, RentalDto>();

                cfg.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
                cfg.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
                cfg.CreateMap<RentalDto, Rental>().ForMember(r => r.Id, opt => opt.Ignore());
            });


            /*
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            */

            //Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            //Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());

        }
    }
}