namespace BasketAPI.Models
{
    public class ShoppingCart
    {
        public string UserName;

        public List<ShoppingCartItem> Items;

        public decimal TotalPrice => Items.Sum(item  => item.Price);

        public ShoppingCart(string userName)
        {
            UserName = userName;
        }

        public ShoppingCart()
        {
        }
    }
}
