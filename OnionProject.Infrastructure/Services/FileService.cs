using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using OnionProject.Application.Services;
using OnionProject.Infrastructure.Operations;

namespace OnionProject.Infrastructure.Services;

public class FileService : IFileService

{
    private readonly IWebHostEnvironment webHostEnvironment;
    public FileService(IWebHostEnvironment _webHostEnvironment)
    {
        webHostEnvironment = _webHostEnvironment;
    }

    public async Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files)
    {
        string uploadPath = Path.Combine(webHostEnvironment.WebRootPath, path);
       
        if (!Directory.Exists(uploadPath))
            Directory.CreateDirectory(uploadPath);
        List<bool> results = new();
        List<(string fileName , string path)> datas = new();
        foreach (IFormFile file in  files)
        {  string fileNewName = await FileRenameAsync(file.FileName);
       
            
            
           bool result = await CopyFileAsync(Path.Combine(path,fileNewName),file);
           Console.WriteLine(Path.Combine(path,fileNewName));
           datas.Add((fileNewName,$"{uploadPath}//{fileNewName}"));
           results.Add(result); }

        if (results.TrueForAll(r => r.Equals(true)))
        {  return datas;
        }
        else
        {
            Console.WriteLine("Errors in the list ! ");
            return null;
        }
        
          
        
        //todo Eğer ki yukardaki if geçerli değil ise bueada dosyaların sunucuda tutulmaya calısıluırken hata alındıgına dail hata oluştuğuna dair bildiilmeli.
        
    }

    public async Task<string> FileRenameAsync(string fileName)
    
    {
       string newFileName = await Task.Run(() =>
        {
            string extension = Path.GetExtension(fileName);
            
            string resultName = $"{Path.GetFileNameWithoutExtension(fileName)}{DateTime.Now.ToString("yyyyMMddHHmmss")}{extension}";
            return resultName;
            
        });
        
        return newFileName;
    }

    public async Task<bool> CopyFileAsync(string path, IFormFile file)
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
            //Log it .
            throw e ;
        }
    }
}