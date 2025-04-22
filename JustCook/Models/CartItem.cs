namespace JustCook.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int BookId { get; set; }
        public CookBook? Book { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public decimal Total => Items.Sum(item => item.UnitPrice * item.Quantity);
    }
}
