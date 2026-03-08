

namespace CatalogAPI.Product.CreateProduct;


public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResponse>;

public record CreateProductResponse(Guid Id);

public class Endpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async (CreateProductRequest req, ISender sender) =>
        {
            var command = req.Adapt<Handler.CreateProductCommand>(); //converts CreateProductRequest to CreateProductCommand

            var result = await sender.Send(command);

            var response = result.Adapt<CreateProductResponse>(); //converts CreateProductResult to CreateProductResponse

            return Results.Created($"/products/{response.Id}", response.Id);
        })
        .WithName("CreateProduct")
        .WithDescription("CreateProduct")
        .Produces<CreateProductResponse>()
        .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}


