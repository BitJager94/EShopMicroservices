namespace BasketAPI.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketCommandResult>;

    public record DeleteBasketCommandResult(bool isSuccess);

    public class Handler : ICommandHandler<DeleteBasketCommand, DeleteBasketCommandResult>
    {
        public async Task<DeleteBasketCommandResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
        {


            return new DeleteBasketCommandResult(true);
        }
    }
}
