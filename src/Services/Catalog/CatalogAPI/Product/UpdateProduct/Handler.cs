


using Marten;

namespace CatalogAPI.Product.UpdateProduct;

public class Handler
{
    public record UpdateProductCommand(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<UpdateProductResult>;

    public record UpdateProductResult(bool IsSuccess);

    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Product Id Is Required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Product Name Is Required");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Product Price Is Required");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Product Image File Is Required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Product Description Is Required");
        }
    }

    internal class UpdateProductCommandHandler(IDocumentSession session) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {

            //validation shifted to pipelineBehavoiur in program.cs
            //var validationResult = await validator.ValidateAsync(request, cancellationToken); 
            //var errors = validationResult.Errors.Select(i => i.ErrorMessage).ToList();
            //if (errors.Any()) {
            //    throw new ValidationException(errors.FirstOrDefault());
            //}

           
            Models.Product product = await session.LoadAsync<Models.Product>(command.Id, cancellationToken);

            if (product is null)
            {
                //throw new ProductNotFoundException()
            }

            product.Name = command.Name;
            product.Description = command.Description;
            product.Price = command.Price;
            product.ImageFile = command.ImageFile;
            product.Category = command.Category;

            session.Update<Models.Product>(product);

            await session.SaveChangesAsync();

            return new UpdateProductResult(true);
        }
    }
}
