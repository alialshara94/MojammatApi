using System;
using Microsoft.EntityFrameworkCore;
using MojammatApi.Interfaces;
using MojammatApi.Models;
using MojammatApi.Services;

namespace MojammatApi.Repositories
{
	public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;

        public UserRepository(AppDbContext appDbContext)
		{
            this.appDbContext = appDbContext;
        }

        public bool CreateUser(Users user)
        {
            appDbContext.Add(user);
            return appDbContext.SaveChanges() > 0;
        }

        public bool DeleteUser(Guid id)
        {
            var user = appDbContext.users.Find(id);
            if (user == null)
            {
                return false;
            }
            appDbContext.users.Remove(user);
            return appDbContext.SaveChanges() > 0;
        }

        public Users GetUser(Guid id)
        {
            return appDbContext.users.Where(u => u.id == id).FirstOrDefault();
        }

        public ICollection<Users> GetUsers(int page, int pageSize)
        {
            return appDbContext.users.Take(pageSize).Skip((page-1)* pageSize).Where(u => u.role != "Admin").ToList();
        }

        public bool UpdateUser(Users user)
        {
            appDbContext.Update(user);
            return appDbContext.SaveChanges() > 0;
        }
    }
}

