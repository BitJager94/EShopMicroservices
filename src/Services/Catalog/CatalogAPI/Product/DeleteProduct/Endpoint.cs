


namespace CatalogAPI.Product.DeleteProduct;


//public record DeleteProductdRequest(Guid Id) : IQuery<DeleteProductdResponse>;

public record DeleteProductdResponse(bool IsSuccess);

public class Endpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{id}", async (Guid id, ISender sender) =>
        {

            var result = await sender.Send(new Handler.DeleteProductdCommand(id));

            var response = result.Adapt<DeleteProductdResponse>(); //converts GetProductByIdResult to GetProductByIdResponse

            return Results.Ok(response);
     
        })
        .WithName("DeleteProduct")
        .WithDescription("Delete Product By Id")
        .Produces<DeleteProductdResponse>()
        .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}


