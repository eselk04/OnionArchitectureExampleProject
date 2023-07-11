using OnionProject.Application.Repositories;
using OnionProject.Application.Repositories.Invoice;
using OnionProject.Domain.Entities;

namespace OnionProject.Persistence.Repository.InvoiceFiles;

public class InvoiceWriteRepository : WriteRepository<InvoiceFile>, IInvoiceWriteRepository
{
    
}