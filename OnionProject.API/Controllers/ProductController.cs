using System.Runtime.InteropServices.JavaScript;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionProject.Application.Abstractions;
using OnionProject.Application.Abstractions.Storage;
using OnionProject.Application.Features.Queries.Product.GetAllProduct;
using OnionProject.Application.Features.Commands.Product.UpdateProduct;
using OnionProject.Application.Features.Queries.Product.GetProductById;
using OnionProject.Application.Pagination;
using OnionProject.Application.Repositories.Product;
using OnionProject.Application.Repositories.ProductImage;
using OnionProject.Application.ViewModels;
using OnionProject.Domain.Entities;
using OnionProject.Application.Messages;

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
    private readonly IMediator _mediator;
  

    public ProductController(IWebHostEnvironment webHostEnvironment,
        IProductService productService, IProductReadRepository productReadRepository,
        IProductWriteRepository productWriteRepository,
        IProductImageReadRepository productImageReadRepository, IProductImageWriteRepository productImageWriteRepository
        , IStorageService storageService , IMediator mediator )
    {
        _productService = productService;
        _productReadRepository = productReadRepository;
        _ProductWriteRepository = productWriteRepository;
        _webHostEnvironment = webHostEnvironment;
        _storageService = storageService;
        _productImageWriteRepository = productImageWriteRepository;
       
        _mediator = mediator;

    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetProductByIdQueryRequest getProductByIdQueryRequest)
    {

        GetProductByIdQueryResponse response = await _mediator.Send(getProductByIdQueryRequest);
        if(response.Message == Messages.Successfull)
        {
            return Ok(response);
        }
        return Ok(response.Message);
       
        
    }


    [HttpGet("getp")]
    public async Task<IActionResult> GetAll([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
    {
       GetAllProductQueryResponse response = await _mediator.Send(getAllProductQueryRequest);

        return Ok(response);
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
    public async Task<ActionResult> Put([FromBody] UpdateProductCommandRequest updateProductCommandRequest)
        
    {
        UpdateProductCommandResponse response = await _mediator.Send(updateProductCommandRequest);
       
        return Ok(response);

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