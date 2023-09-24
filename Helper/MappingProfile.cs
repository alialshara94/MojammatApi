using System;
using AutoMapper;
using MojammatApi.Dto.RequestedService;
using MojammatApi.Dto.Users;
using MojammatApi.Dto.Visitors;
using MojammatApi.Models;

namespace MojammatApi.Helper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			//User Mapping block

			CreateMap<Users, GetUserDto>();
            CreateMap<CreateUserDto, Users>();
            CreateMap<UpdateUserDto, Users>();


            //Visitor Mapping block

            CreateMap<Visitor, GetVisitorDto>();
			CreateMap<CreateVisitorDto, Visitor>();
            CreateMap<UpdateVisitorDto, Visitor>();



            //Services Mapping block

            CreateMap<RequestedServices, GetRequestedServiceDto>();
            CreateMap<CreateRequestedServiceDto, RequestedServices>();
        }

		
	}
}

