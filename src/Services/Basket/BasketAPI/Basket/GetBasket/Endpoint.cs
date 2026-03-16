

using Mapster;

namespace BasketAPI.Basket.GetBasket
{
    //public record GetBasketReuest(string UserName);
    public record GetBasketResponse(ShoppingCart Cart);
    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/basket/{username}", async (string username, ISender sender) =>
            {
                var result = sender.Send(new GetBasketQuery(username));

                var response = result.Adapt<GetBasketResponse>();

                return Results.Ok(response);
            })
            .WithName("GetBasket")
            .WithDescription("Get Basket")
            .Produces<GetBasketResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest);
        }
    }
}
