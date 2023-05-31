namespace ShoppingCartDiscount.Models
{
    public class Item
    {
        public char Elements { get; set; }
        public decimal Money { get; set; }
        public Discount_Money Discount_Money { get; set; }
    }
}
