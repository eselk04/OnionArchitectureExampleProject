using System.Net;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OnionProject.Application.Abstractions.Storage.Local;
using File = OnionProject.Domain.Entities.File;

namespace OnionProject.Infrastructure.Storage.Local;

public class LocalStorage : ILocalStorage
{

    private IWebHostEnvironment webHostEnvironment;

    public LocalStorage(IWebHostEnvironment _webHostEnvironment)
    {
        webHostEnvironment = _webHostEnvironment;
        
    }
    public async Task<List<(string fileName, string path)>> UploadAsync(string pathOrContainer, IFormFileCollection files)
    {
        string uploadPath = Path.Combine(webHostEnvironment.WebRootPath, pathOrContainer);
       
        if (!Directory.Exists(uploadPath))
            Directory.CreateDirectory(uploadPath);
        List<(string fileName, string path)> datas = new();
        foreach (IFormFile file in  files)
        { await CopyFileAsync(Path.Combine(uploadPath,file.Name),file);
            datas.Add((file.Name , $"{uploadPath}//{file.Name}"));
        }
        return datas;
            //todo Eğer ki yukardaki if geçerli değil ise bueada dosyaların sunucuda tutulmaya calısıluırken hata alındıgına dail hata oluştuğuna dair bildiilmeli.
    }

    public async Task DeleteAsync(string pathOrContainerName, string fileName) =>
        System.IO.File.Delete($"{pathOrContainerName}//{fileName}");
        
    public List<string> GetFiles(string pathOrContainerName)
    {
        DirectoryInfo directory = new(pathOrContainerName);
        return  directory.GetFiles().Select(a => a.Name).ToList();
        
    }

    public bool HasFile(string pathOrContainerName, string fileName) => System.IO.File.Exists($"{pathOrContainerName}//{fileName}");


    async Task<bool> CopyFileAsync(string path, IFormFile file)
    {
        try
        {
            await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, 
                useAsync: true);
            await file.CopyToAsync(fileStream);
            await fileStream.FlushAsync();
            return true;
        }
        catch (Exception e)
        {
            //todo Log it.
            throw e ;
        }
    }

    async Task<string> renameFileAsync(string fileName)
    {
        
         string newFileName = await Task.Run(() =>
        {
            string extension = Path.GetExtension(fileName);
            string oldName = fileName;
            string newName = $"{fileName}{DateTime.Now.ToString("yyyyMMddHHmmss")}";
            string fileNewName = $"{newName}{extension}";
            return fileNewName;
        });

         return newFileName;


    }

    
    
    
}