using MojammatApi.Dto.Invoices;
using MojammatApi.Interfaces;
using MojammatApi.Models;
using MojammatApi.Services;

namespace MojammatApi.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext appDbContext;
        public InvoiceRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public bool CreateInvoice(Invoices invoices)
        {
            appDbContext.invoices.Add(invoices);
            return appDbContext.SaveChanges() > 0;
        }

        public bool DeleteInvoice(Guid id)
        {
            var invoice = appDbContext.invoices.Find(id);
            if (invoice == null)
            {
                return false;
            }
            appDbContext.invoices.Remove(invoice);
            return appDbContext.SaveChanges() > 0;
        }

        public Invoices GetInvoice(Guid id)
        {
            return appDbContext.invoices.Where(u => u.id == id).FirstOrDefault();
        }

        public IEnumerable<Invoices> GetInvoiceByUserId(Guid userId)
        {
            return appDbContext.invoices.Where(s => s.userId == userId).ToList();
        }

        public ICollection<Invoices> GetInvoices(int page, int pageSize, string search)
        {
            IQueryable<Invoices> query = appDbContext.invoices;

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(u => u.number.Contains(search));
            }

            return query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public bool UpdateInvoice(UpdateInvoiceDto updateInvoiceDto, Guid id)
        {
            bool isExist = appDbContext.invoices.Any(i => i.id == id);

            if (isExist)
            {
                Invoices oldInvoice = appDbContext.invoices.Where(i => i.id == id).First();

                oldInvoice.title = updateInvoiceDto.title != string.Empty ? updateInvoiceDto.title : oldInvoice.title;
                oldInvoice.number = updateInvoiceDto.number != string.Empty ? updateInvoiceDto.number : oldInvoice.number;
                oldInvoice.price = updateInvoiceDto.price != string.Empty ? decimal.Parse(updateInvoiceDto.price!) : oldInvoice.price;
                oldInvoice.date = updateInvoiceDto.date != string.Empty ? DateOnly.Parse(updateInvoiceDto.date!) : oldInvoice.date;
                oldInvoice.isPaid = updateInvoiceDto.isPaid != string.Empty ? bool.Parse(updateInvoiceDto.isPaid!) : oldInvoice.isPaid;
                oldInvoice.status = updateInvoiceDto.status != string.Empty ? bool.Parse(updateInvoiceDto.status!) : oldInvoice.status;
                oldInvoice.userId = updateInvoiceDto.userId != string.Empty ? Guid.Parse(updateInvoiceDto.userId!) : oldInvoice.userId;

                appDbContext.Update(oldInvoice);
                return appDbContext.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }

        
    }
}
