using MediatR;
using OnionProject.Application.Messages;
using OnionProject.Application.Repositories.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Features.Queries.Product.GetProductById
{
    internal class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>
    {
        IProductReadRepository _repository;
        public GetProductByIdQueryHandler(IProductReadRepository productReadRepository)
        {
            _repository = productReadRepository;
        }

        public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);
          
                   if(product != null)
            {
                return new()
                {
                    Name = product.Name,
                    Stock = product.Stock,
                    Price = product.Price,
                    Message = Messages.Messages.Successfull
                };
            }
                   else
            {
                return new()
                {
                    Message = Messages.Messages.ProductNotFound

                };
            }
                
            
         
    }
    }
}
