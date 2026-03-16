using BasketAPI.Models;
using SharedBlocks.CQRS;

namespace BasketAPI.Basket.GetBasket
{
    public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;

    public record GetBasketResult(ShoppingCart Cart);

    public class Handler : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
