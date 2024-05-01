using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using OnionProject.Application.Repositories.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P = OnionProject.Domain.Entities;
namespace OnionProject.Application.Features.Commands.Product.UpdateProduct
{
    internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        IProductReadRepository _productReadRepository;
        IProductWriteRepository _productWriteRepository;
        public UpdateProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }
        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product product = await _productReadRepository.GetByIdAsync(request.Id);
            product.Stock = request.Stock;
            product.Name = request.Name;
            product.Price = request.Price;
            product.Description = request.Description;
            product.ImageUrl = request.ImageUrl;
            await _productWriteRepository.Save();

            return new();

        }
    }
}
