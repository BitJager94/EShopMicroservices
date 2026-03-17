
namespace BasketAPI.Basket.DeleteBasket
{
    //public record GetBasketReuest(string UserName);
    public record DeleteBasketCommandResponse(bool isSuccess);
    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/basket/{username}", async (string username, ISender sender) =>
            {
                var result = sender.Send(new DeleteBasketCommand(username));

                var response = result.Adapt<DeleteBasketCommandResponse>();

                return Results.Ok(response);
            })
            .WithName("DeleteBaset")
            .WithDescription("Delete Basket")
            .Produces<DeleteBasketCommandResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest);
        }
    }
}
