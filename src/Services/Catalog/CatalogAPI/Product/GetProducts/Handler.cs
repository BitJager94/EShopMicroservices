
using Marten;

namespace CatalogAPI.Product.GetProducts;

public class Handler
{
    public record GetProductQuery() : IQuery<GetProductsResult>;

    public record GetProductsResult(IEnumerable<Models.Product> Products);

    internal class GetProductsQueryHandler(IDocumentSession session) : IQueryHandler<GetProductQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var products = await session.Query<Models.Product>().ToListAsync(cancellationToken);

            return new GetProductsResult(products);
        }
    }
}
