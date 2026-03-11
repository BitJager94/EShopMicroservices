


using Marten;
using static CatalogAPI.Product.CreateProduct.Handler;

namespace CatalogAPI.Product.CreateProduct;

public class Handler
{
    public record CreateProductCommand(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid id);

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Product Name Is Required");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Product Price Is Required");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Product Image File Is Required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Product Description Is Required");
        }
    }
    internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {

            //validation shifted to pipelineBehavoiur in program.cs
            //var validationResult = await validator.ValidateAsync(request, cancellationToken); 
            //var errors = validationResult.Errors.Select(i => i.ErrorMessage).ToList();
            //if (errors.Any()) {
            //    throw new ValidationException(errors.FirstOrDefault());
            //}

            var product = new Models.Product()
            {
                Name = command.Name,
                Description = command.Description,
                Category = command.Category,
                Price = command.Price,
                ImageFile = command.ImageFile,
            };

            session.Store(product);

            await session.SaveChangesAsync(cancellationToken);

            return new CreateProductResult(product.Id);

        }
    }
}
