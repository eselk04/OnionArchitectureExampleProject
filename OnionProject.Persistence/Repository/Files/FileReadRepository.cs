using OnionProject.Application.Repositories.File;
using OnionProject.Persistence.Context;
using File = OnionProject.Domain.Entities.File;

namespace OnionProject.Persistence.Repository.Files;

public class FileReadRepository :ReadRepository<Domain.Entities.File>, IFileReadRepository 
{
    public FileReadRepository(PContext postgreContext) : base(postgreContext)
    {
    }
}