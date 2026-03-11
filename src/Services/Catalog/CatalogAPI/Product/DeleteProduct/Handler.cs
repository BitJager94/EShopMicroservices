
using Marten;

namespace CatalogAPI.Product.DeleteProduct;

public class Handler
{
    public record DeleteProductdCommand(Guid Id) : ICommand<DeleteProductdResult>;

    public record DeleteProductdResult(bool IsSuccess);

    internal class DeleteProductdCommandHandler(IDocumentSession session) : ICommandHandler<DeleteProductdCommand, DeleteProductdResult>
    {
        public async Task<DeleteProductdResult> Handle(DeleteProductdCommand command, CancellationToken cancellationToken)
        {
            //validation shifted to pipelineBehavoiur in program.cs
            //var validationResult = await validator.ValidateAsync(request, cancellationToken); 
            //var errors = validationResult.Errors.Select(i => i.ErrorMessage).ToList();
            //if (errors.Any()) {
            //    throw new ValidationException(errors.FirstOrDefault());
            //}

            session.Delete<Models.Product>(command.Id);

            await session.SaveChangesAsync();

            return new DeleteProductdResult(true);
        }
    }
}

