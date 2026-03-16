
using Marten;
using Marten.Pagination;

namespace CatalogAPI.Product.GetProducts;

public class Handler
{
    public record GetProductsQuery(int? PageNumebr = 1, int? PageSize = 10) : IQuery<GetProductsResult>;

    public record GetProductsResult(IEnumerable<Models.Product> Products);

    internal class GetProductsQueryHandler(IDocumentSession session) : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            var products = await session.Query<Models.Product>().ToPagedListAsync(query.PageNumebr?? 1, query.PageSize?? 10, cancellationToken);

            return new GetProductsResult(products);
        }
    }
}
