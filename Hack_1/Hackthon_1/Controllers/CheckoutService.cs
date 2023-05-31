using ShoppingCartDiscount.Models;
using System.Collections;
using System.Linq;

namespace ShoppingCartDiscount.Controllers
{
    public class CheckoutService
    {
        private readonly Hashtable items;

        public CheckoutService()
        {
            items = new Hashtable
            {
                { 'A', new Item { Elements = 'A', Money = 50, Discount_Money = new Discount_Money { Quantity = 3, Discount_MoneyMoney = 130 } } },
                { 'B', new Item { Elements = 'B', Money = 30, Discount_Money = new Discount_Money { Quantity = 2, Discount_MoneyMoney = 45 } } },
                { 'C', new Item { Elements = 'C', Money = 20 } },
                { 'D', new Item { Elements = 'D', Money = 15 } }
            };
        }

        public decimal CalculateTotalMoney(string Elements)
        {
            var itemCounts = GetItemCounts(Elements);

            decimal totalMoney = 0;

            foreach (DictionaryEntry item in itemCounts)
            {
                char element = (char)item.Key;
                int quantity = (int)item.Value;

                if (items.ContainsKey(element))
                {
                    Item selectedItem = (Item)items[element];
                    totalMoney += CalculateItemMoney(selectedItem, quantity);
                }
            }

            return totalMoney;
        }

        private Hashtable GetItemCounts(string Elements)
        {
            var itemCounts = new Hashtable();

            foreach (char element in Elements)
            {
                if (itemCounts.ContainsKey(element))
                {
                    itemCounts[element] = (int)itemCounts[element] + 1;
                }
                else
                {
                    itemCounts[element] = 1;
                }
            }

            return itemCounts;
        }

        private decimal CalculateItemMoney(Item item, int quantity)
        {
            decimal totalMoney = 0;

            if (item.Discount_Money != null)
            {
                int discountQuantity = item.Discount_Money.Quantity;
                int regularQuantity = quantity % discountQuantity;
                int discountMoneyQuantity = quantity / discountQuantity;

                totalMoney += discountMoneyQuantity * item.Discount_Money.Discount_MoneyMoney;
                totalMoney += regularQuantity * item.Money;
            }
            else
            {
                totalMoney = quantity * item.Money;
            }

            return totalMoney;
        }
    }
}
