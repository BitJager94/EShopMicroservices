

using Microsoft.AspNetCore.Http.HttpResults;

namespace CatalogAPI.Product.GetProducts;


//public record GetProductRequest() : IQuery<GetProductResponse>;

public record GetProductResponse(IEnumerable<Models.Product> Products);

public class Endpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender) =>
        {

            var result = await sender.Send(new Handler.GetProductQuery());

            var response = result.Adapt<GetProductResponse>(); //converts CreateProductResult to CreateProductResponse

            return Results.Ok(response);
     
        })
        .WithName("GetProducts")
        .WithDescription("Get All Products")
        .Produces<GetProductResponse>()
        .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}


