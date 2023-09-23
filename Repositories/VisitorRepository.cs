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
            appDbContext.Add(visitor);
            return appDbContext.SaveChanges() > 0;
        }

        public bool DeleteUser(Guid id)
        {
            var visitor = appDbContext.visitors.Find(id);
            if (visitor == null)
            {
                return false;
            }
            appDbContext.visitors.Remove(visitor);
            return appDbContext.SaveChanges() > 0;
        }

        public ICollection<Users> GetVisitor(int page, int pageSize, string search)
        {
            return appDbContext.users.Take(pageSize).Skip((page - 1) * pageSize).Where(u => u.fullname == search).ToList();
        }

        public Users GetVisitor(Guid id)
        {
            return appDbContext.users.Where(u => u.id == id).FirstOrDefault();
        }

        public bool UpdateVisitor(Visitor visitor)
        {
            appDbContext.Update(visitor);
            return appDbContext.SaveChanges() > 0;
        }
    }
}

