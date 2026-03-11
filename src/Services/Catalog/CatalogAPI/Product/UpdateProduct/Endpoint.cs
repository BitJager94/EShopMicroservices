

namespace CatalogAPI.Product.UpdateProduct;


public record UpdateProductRequest(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<UpdateProductResponse>;

public record UpdateProductResponse(Guid Id);

public class Endpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products", async (UpdateProductRequest req, ISender sender) =>
        {
            var command = req.Adapt<Handler.UpdateProductCommand>(); //converts CreateProductRequest to CreateProductCommand

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateProductResponse>(); //converts UpdateProductResult to UpdateProductResponse

            return Results.Created($"/products/{response.Id}", response.Id);
        })
        .WithName("UpdateProduct")
        .WithDescription("Update Product")
        .Produces<UpdateProductResponse>()
        .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}


