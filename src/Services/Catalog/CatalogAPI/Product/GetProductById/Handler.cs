
using Marten;

namespace CatalogAPI.Product.GetProductById;

public class Handler
{
    public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;

    public record GetProductByIdResult(Models.Product Product);

    internal class GetProductsQueryHandler(IDocumentSession session) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Models.Product>(query.Id, cancellationToken);

            if (product == null)
            {
                //throw ProductNotFoudn();
            }

            return new GetProductByIdResult(product);
        }
    }
}
