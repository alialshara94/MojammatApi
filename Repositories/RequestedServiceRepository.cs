using System;
using Microsoft.EntityFrameworkCore;
using MojammatApi.Dto.RequestedService;
using MojammatApi.Dto.Visitors;
using MojammatApi.Interfaces;
using MojammatApi.Models;
using MojammatApi.Services;

namespace MojammatApi.Repositories
{
	public class RequestedServiceRepository : IRequestedServiceRepository
    {
        private readonly AppDbContext appDbContext;
        public RequestedServiceRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public bool CreateService(RequestedServices requestedServices)
        {
            appDbContext.services.Add(requestedServices);
            return appDbContext.SaveChanges() > 0;
        }

        public bool DeleteService(Guid id)
        {
            var service = appDbContext.services.Find(id);
            if (service == null)
            {
                return false;
            }
            appDbContext.services.Remove(service);
            return appDbContext.SaveChanges() > 0;
        }

        public RequestedServices GetService(Guid id)
        {
            return appDbContext.services.Where(u => u.id == id).FirstOrDefault();
        }

        

        public IEnumerable<RequestedServices> GetServiceByUser(Guid userId)
        {
            return appDbContext.services.Where(s => s.userId == userId).ToList();
        }

        public ICollection<RequestedServices> GetServices(int page, int pageSize, string type)
        {
            IQueryable<RequestedServices> query = appDbContext.services;

            if (!string.IsNullOrEmpty(type))
            {
                query = query.Where(u => u.type.Contains(type));
            }

            return query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public bool UpdateService(UpdateRequestedSreviceDto updateRequestedSreviceDto, Guid id)
        {
            bool isExist = appDbContext.services.Any(v => v.id == id);

            if (isExist)
            {
                RequestedServices oldServices = appDbContext.services.Where(v => v.id == id).First();

                oldServices.title = updateRequestedSreviceDto.title != string.Empty ? updateRequestedSreviceDto.title! : oldServices.title;
                oldServices.description = updateRequestedSreviceDto.description != string.Empty ? updateRequestedSreviceDto.description! : oldServices.description;
                oldServices.type = updateRequestedSreviceDto.type != string.Empty ? updateRequestedSreviceDto.type! : oldServices.type;
                oldServices.date = updateRequestedSreviceDto.date != string.Empty ? DateOnly.Parse(updateRequestedSreviceDto.date!) : oldServices.date;
                oldServices.status = updateRequestedSreviceDto.status != string.Empty ? bool.Parse(updateRequestedSreviceDto.status!) : oldServices.status;
                oldServices.userId = updateRequestedSreviceDto.userId != string.Empty ? Guid.Parse(updateRequestedSreviceDto.userId!) : oldServices.userId;
                appDbContext.Update(oldServices);
                return appDbContext.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }
    }
}

