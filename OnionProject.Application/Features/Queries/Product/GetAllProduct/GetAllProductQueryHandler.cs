using MediatR;
using OnionProject.Application.Pagination;
using OnionProject.Application.Repositories.Product;

namespace OnionProject.Application.Features.Queries.Product.GetAllProduct;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
{
    private readonly IProductReadRepository _productReadRepository;
    public GetAllProductQueryHandler(IProductReadRepository productReadRepository)
    {
        _productReadRepository = productReadRepository;
    }

    public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
    {
        var totalCount = _productReadRepository.GetAll().ToList().Count;
        var products = _productReadRepository.GetAll().Skip(request.Page * request.Size)
            .Take(request.Size).ToList();



        return new() { Products = products, TotalProductCount = totalCount };
    }
}