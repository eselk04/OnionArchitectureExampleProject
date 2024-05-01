using MediatR;
using OnionProject.Application.Repositories.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Features.Commands.Product.DeleteProduct
{
    internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {

        IProductWriteRepository productWriteRepository;
        public DeleteProductCommandHandler(IProductWriteRepository _productWriteRepository)
        {
            productWriteRepository = _productWriteRepository;   
        }
        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            productWriteRepository.RemoveAsync(request.ProductId);
            return new();


        }
    }
}
