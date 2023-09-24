using System;
using MojammatApi.Models;

namespace MojammatApi.Interfaces
{
	public interface IRequestedServiceRepository
	{
        ICollection<RequestedServices> GetServices(int page, int pageSize, string type);
        RequestedServices GetService(Guid id);
        IEnumerable<RequestedServices> GetServiceByUser(Guid id);
        bool CreateService(RequestedServices requestedServices);
        bool UpdateService(RequestedServices requestedServices, Guid id);
        bool DeleteService(Guid id);
    }
}

