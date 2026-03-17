using BasketAPI.Basket.DeleteBasket;

namespace BasketAPI.Basket.StoreBasket
{
    public record StoreBasketCommandRequest(ShoppingCart Cart);
    public record StoreBasketCommandResponse(string UserName);

    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket", async (StoreBasketCommandRequest request, ISender sender) =>
            {
                var command = request.Adapt<StoreBasketCommand>();

                var result = sender.Send(command);

                var response = result.Adapt<StoreBasketCommandResponse>();

                return Results.Created($"/basket/{response.UserName}", response);
            })
            .WithName("StoreBasket")
            .WithDescription("Store Basket")
            .Produces<DeleteBasketCommandResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest);
        }
    }
}
