using System;
using MojammatApi.Models;

namespace MojammatApi.Interfaces
{
	public interface IVisitorRepository
	{
        ICollection<Users> GetVisitor(int page, int pageSize, string search);
        Users GetVisitor(Guid id);
        bool CreateVisitor(Visitor visitor);
        bool UpdateVisitor(Visitor visitor);
        bool DeleteUser(Guid id);
    }
}

