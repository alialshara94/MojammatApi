using System;
using MojammatApi.Models;

namespace MojammatApi.Interfaces
{
	public interface IVisitorRepository
	{
        ICollection<Visitor> GetVisitors(int page, int pageSize, string search);
        Visitor GetVisitor(Guid id);
        bool CreateVisitor(Visitor visitor);
        bool UpdateVisitor(Visitor visitor, Guid id);
        bool DeleteVisitor(Guid id);
    }
}

