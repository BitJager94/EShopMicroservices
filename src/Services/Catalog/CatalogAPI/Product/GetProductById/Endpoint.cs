



using static CatalogAPI.Product.GetProductById.Handler;

namespace CatalogAPI.Product.GetProductById;


public record GetProductByIdRequest(Guid Id) : IQuery<GetProductByIdResponse>;

public record GetProductByIdResponse(Models.Product Product);

public class Endpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
        {

            var result = await sender.Send(new Handler.GetProductByIdQuery(id));

            var response = result.Adapt<GetProductByIdResponse>(); //converts GetProductByIdResult to GetProductByIdResponse
            Console.WriteLine(response);
            return Results.Ok(response);
     
        })
        .WithName("GetProductById")
        .WithDescription("Get Product By Id")
        .Produces<GetProductByIdResponse>()
        .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}


