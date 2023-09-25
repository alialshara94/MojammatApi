using MojammatApi.Dto.Invoices;
using MojammatApi.Models;

namespace MojammatApi.Interfaces
{
    public interface IInvoiceRepository
    {
        ICollection<Invoices> GetInvoices(int page, int pageSize, string search);
        Invoices GetInvoice(Guid id);
        bool CreateInvoice(Invoices invoices);
        bool UpdateInvoice(UpdateInvoiceDto updateInvoiceDto, Guid id);
        bool DeleteInvoice(Guid id);
    }
}
