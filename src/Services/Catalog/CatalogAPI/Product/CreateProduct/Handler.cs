

namespace CatalogAPI.Product.CreateProduct
{

using SharedBlocks.CQRS;
using System.Threading;
using System.Threading.Tasks;

    public class Handler
    {
        public record CreateProductCommand(string Name, List<string> Category, string Description) : ICommand<CreateProductResult>;

        public record CreateProductResult(Guid Id);

        internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
        {
            public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
