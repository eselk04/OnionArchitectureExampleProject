using OnionProject.Application.Repositories.Invoice;
using OnionProject.Domain.Entities;
using OnionProject.Persistence.Context;

namespace OnionProject.Persistence.Repository.InvoiceFiles;

public class InvoiceReadRepository :ReadRepository<InvoiceFile>,  IInvoiceReadRepository 
{
    public InvoiceReadRepository(PContext postgreContext) : base(postgreContext)
    {
    }
}