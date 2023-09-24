using MojammatApi.Dto;
using MojammatApi.Interfaces;
using MojammatApi.Models;
using MojammatApi.Services;

namespace MojammatApi.Repositories
{
    public class VisitorRepository : IVisitorRepository
	{

        private readonly AppDbContext appDbContext;
        public VisitorRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public bool CreateVisitor(Visitor visitor)
        {
            appDbContext.visitors.Add(visitor);
            return appDbContext.SaveChanges() > 0;
        }

        public bool DeleteVisitor(Guid id)
        {
            var visitor = appDbContext.visitors.Find(id);
            if (visitor == null)
            {
                return false;
            }
            appDbContext.visitors.Remove(visitor);
            return appDbContext.SaveChanges() > 0;
        }



        //public ICollection<Visitor> GetVisitors(int page, int pageSize, string search)
        // {
        //     return appDbContext.visitors.Take(pageSize).Skip((page - 1) * pageSize).Where(u => u.fullname == search).ToList();
        // }

        public ICollection<Visitor> GetVisitors(int page, int pageSize, string search = null)
        {
            IQueryable<Visitor> query = appDbContext.visitors;

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(u => u.fullname.Contains(search));
            }

            return query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public Visitor GetVisitor(Guid id)
        {
            return appDbContext.visitors.Where(u => u.id == id).FirstOrDefault();
        }

        public bool UpdateVisitor(Visitor visitorInfo, Guid id)
        {


            var visitor = appDbContext.visitors.Where(u => u.id == id).FirstOrDefault();
            if (visitor == null)
            {
                return false;
            }

            //visitor.fullname = visitorInfo.fullname;
            //visitor.inDate = visitorInfo.inDate;
            //visitor.inTime = visitorInfo.inTime;
            //visitor.outDate = visitorInfo.outDate;
            //visitor.outTime = visitorInfo.outTime;
            //visitor.status = visitorInfo.status;
            //visitor.userId = visitorInfo.userId;

            //appDbContext.visitors.Update(visitor);
            return appDbContext.SaveChanges() > 0;
        }

    }
}

