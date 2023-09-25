using System;
using Microsoft.EntityFrameworkCore;
using MojammatApi.Dto.Users;
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

        public bool UpdateUser(UpdateUserDto updateUserDto, Guid id)
        {
            bool isExist = appDbContext.users.Any(u => u.id == id);
            if (isExist)
            {
                Users oldUser = appDbContext.users.Where(u => u.id == id).First();

                oldUser.fullname = updateUserDto.fullname != string.Empty ? updateUserDto.fullname! : oldUser.fullname;
                oldUser.phone = updateUserDto.phone != string.Empty ? updateUserDto.phone! : oldUser.phone;
                oldUser.apartmentNo = updateUserDto.apartmentNo != string.Empty ? updateUserDto.apartmentNo! : oldUser.apartmentNo;
                oldUser.identification = updateUserDto.identification != string.Empty ? updateUserDto.identification! : oldUser.identification;
                oldUser.building = updateUserDto.building != string.Empty ? updateUserDto.building! : oldUser.building;
                oldUser.floor = updateUserDto.floor != string.Empty ? updateUserDto.floor! : oldUser.floor;
                oldUser.role = updateUserDto.role != string.Empty ? updateUserDto.role! : oldUser.role;
                oldUser.status = updateUserDto.status == string.Empty ? oldUser.status : bool.Parse(updateUserDto.status!);
                appDbContext.Update(oldUser);
                return appDbContext.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }
    }
}