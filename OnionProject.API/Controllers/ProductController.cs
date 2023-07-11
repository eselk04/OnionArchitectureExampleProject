 using Microsoft.AspNetCore.Mvc;
 using OnionProject.Application.Abstractions;
 using OnionProject.Application.Abstractions.Storage;
 using OnionProject.Application.Pagination;
 using OnionProject.Application.Repositories.Product;
 using OnionProject.Application.Repositories.ProductImage;
 using OnionProject.Application.ViewModels;
 using OnionProject.Domain.Entities;

 namespace newproj.Controllers;
[Route("products")]
public class ProductController : Controller
{
    private IWebHostEnvironment _webHostEnvironment;
    private IProductService _productService;
    private IProductImageReadRepository _productImageReadRepository;
    private IProductImageWriteRepository _productImageWriteRepository;
    private IProductReadRepository _productReadRepository; 
    private IProductWriteRepository _ProductWriteRepository { get; set; }
    private IStorageService _storageService;
  
  

    public ProductController(IWebHostEnvironment webHostEnvironment,
        IProductService productService, IProductReadRepository productReadRepository,
        IProductWriteRepository productWriteRepository,
        IProductImageReadRepository productImageReadRepository, IProductImageWriteRepository productImageWriteRepository
        , IStorageService storageService)
    {
        _productService = productService;
        _productReadRepository = productReadRepository;
        _ProductWriteRepository = productWriteRepository;
        _webHostEnvironment = webHostEnvironment;
        _storageService = storageService;
        _productImageWriteRepository = productImageWriteRepository;



    }
    
    
    [HttpGet("getp")]
    public IActionResult GetAll([FromQuery] Pagination pagination)
    {
        var totalCount = _productReadRepository.GetAll().ToList().Count;
        var products = _productReadRepository.GetAll().Skip(pagination.Page * pagination.Size)
            .Take(pagination.Size).ToList();
        return Ok(new
        {
            products,totalCount
        });
    }

    [HttpPost("add")]
    public async Task<ActionResult> AddProduct([FromBody] VM_Create_Product model)
    {
        Product product = new(){Stock = model.Stock,
           Name = model.Name,
           Brand = model.Brand,
         
          
            Price = model.Price,
          Description = model.Description,
            Quantity = model.Quantity,
            ImageUrl = model.ImageUrl};
            
        
        var a = await _ProductWriteRepository.AddAsync(product);
        _ProductWriteRepository.Save();
        if (a)
        {
            return Ok(a);
        }
        return BadRequest(a);
       
    }
     [HttpPut("update")]
    public async Task<ActionResult> Put(VM_Update_Product model)
    {
        Product product = await _productReadRepository.GetByIdAsync(model.id);
        product.Stock = model.Stock;
        product.Name = model.Name;
        product.Brand = model.Brand;
        product.Price = model.Price;
        product.Description = model.Description;
        product.Quantity = model.Quantity;
        product.ImageUrl = model.ImageUrl;
        _ProductWriteRepository.Save();
        return Ok("succeed");

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _ProductWriteRepository.RemoveAsync(Convert.ToString(id));
         _ProductWriteRepository.Save();
         return Ok();
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Upload()
    { var datas = await _storageService.UploadAsync("resource/product-images", Request.Form.Files);
     await    _productImageWriteRepository.AddRangeAsync(datas.Select(u=>new ProductImage(){Name = u.fileName, Path = u.path,Storage = _storageService.StorageName}).ToList());
     await _productImageWriteRepository.Save();
     return Ok("Success");
     
    }


}