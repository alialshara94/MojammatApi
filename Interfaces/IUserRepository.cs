using System;
using MojammatApi.Dto.Users;
using MojammatApi.Models;

namespace MojammatApi.Interfaces
{
	public interface IUserRepository
	{
		ICollection<Users> GetUsers(int page, int pageSize);
		Users GetUser(Guid id);
		bool CreateUser(Users user);
		bool UpdateUser( UpdateUserDto updateUserDto, Guid id);
		bool DeleteUser(Guid id);
	}
}

