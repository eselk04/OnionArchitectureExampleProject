using OnionProject.Application.Repositories;
using OnionProject.Application.Repositories.File;

namespace OnionProject.Persistence.Repository.Files;

public class FileWriteRepository :WriteRepository<Domain.Entities.File>, IFileWriteRepository
{
    
}