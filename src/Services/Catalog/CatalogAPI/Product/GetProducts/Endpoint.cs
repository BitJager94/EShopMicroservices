

using Microsoft.AspNetCore.Http.HttpResults;

namespace CatalogAPI.Product.GetProducts;


public record GetProductsRequest(int? PageNumebr = 1, int? PageSize = 10) : IQuery<GetProductsResponse>;

public record GetProductsResponse(IEnumerable<Models.Product> Products);

public class Endpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async ([AsParameters] GetProductsRequest request, ISender sender) =>
        {
            var query = request.Adapt<Handler.GetProductsQuery>();

            var result = await sender.Send(query);

            var response = result.Adapt<GetProductsResponse>(); //converts CreateProductResult to CreateProductResponse

            return Results.Ok(response);
     
        })
        .WithName("GetProducts")
        .WithDescription("Get All Products")
        .Produces<GetProductsResponse>()
        .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}


