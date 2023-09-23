using System;
using MojammatApi.Models;

namespace MojammatApi.Interfaces
{
	public interface IUserRepository
	{
		ICollection<Users> GetUsers(int page, int pageSize);
		Users GetUser(Guid id);
		bool CreateUser(Users user);
		bool UpdateUser( Users user);
		bool DeleteUser(Guid id);
	}
}

