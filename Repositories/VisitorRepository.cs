using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MojammatApi.Dto;
using MojammatApi.Dto.Visitors;
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

        public bool UpdateVisitor(UpdateVisitorDto updateVisitorDto, Guid id)
        {
            bool isExist = appDbContext.visitors.Any(v => v.id == id);

            if (isExist) {
                Visitor oldVisitor = appDbContext.visitors.Where(v => v.id == id).First();

                oldVisitor.fullname = updateVisitorDto.fullname != string.Empty ? updateVisitorDto.fullname! : oldVisitor.fullname;
                oldVisitor.inDate = updateVisitorDto.inDate != string.Empty ? DateOnly.Parse(updateVisitorDto.inDate!) : oldVisitor.inDate;
                oldVisitor.inTime = updateVisitorDto.inTime != string.Empty ? TimeOnly.Parse(updateVisitorDto.inTime!) : oldVisitor.inTime;
                oldVisitor.outDate = updateVisitorDto.outDate != string.Empty ? DateOnly.Parse(updateVisitorDto.outDate!) : oldVisitor.outDate;
                oldVisitor.outTime = updateVisitorDto.outTime != string.Empty ? TimeOnly.Parse(updateVisitorDto.outTime!) : oldVisitor.outTime;
                oldVisitor.status = updateVisitorDto.status != string.Empty ? bool.Parse(updateVisitorDto.status!) : oldVisitor.status;
                oldVisitor.userId = updateVisitorDto.userId != string.Empty ? Guid.Parse(updateVisitorDto.userId!) : oldVisitor.userId;
                appDbContext.Update(oldVisitor);
                return appDbContext.SaveChanges() > 0;
            } else
            {
                return false;
            }
        }

    }
}