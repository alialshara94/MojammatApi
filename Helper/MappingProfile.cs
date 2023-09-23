using System;
using AutoMapper;
using MojammatApi.Dto.Users;
using MojammatApi.Models;

namespace MojammatApi.Helper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Users, GetUserDto>();
            CreateMap<CreateUserDto, Users>();
        }

		
	}
}

