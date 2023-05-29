using ShoppingCartDiscount;
using ShoppingCartDiscount.Controllers;
using Xunit;

namespace ShoppingCartDiscount.Tests
{
    public class CheckoutServiceTests
    {
        [Fact]
        public void CalculateTotalMoney_SingleItemWithDiscount_ReturnsCorrectTotalMoney()
        {
            // Arrange
            var checkoutService = new CheckoutService();
            var Elements = "AAABBCD"; // 3 items 'B' with discount
            var expectedTotalMoney = 210; // Discounted Money for 3 items 'B'

            // Act
            var actualTotalMoney = checkoutService.CalculateTotalMoney(Elements);

            // Assert
            Assert.Equal(expectedTotalMoney, actualTotalMoney);
        }

        [Fact]
        public void CalculateTotalMoney_MultipleItemsWithMixedDiscounts_ReturnsCorrectTotalMoney()
        {
            // Arrange
            var checkoutService = new CheckoutService();
            var Elements = "AAAA"; // 2 items 'A' with discount, 3 items 'B' with discount
            var expectedTotalMoney =180 ; // Discounted Money for 2 items 'A' + discounted Money for 3 items 'B' + regular Money for other items

            // Act
            var actualTotalMoney = checkoutService.CalculateTotalMoney(Elements);

            // Assert
            Assert.Equal(expectedTotalMoney, actualTotalMoney);
        }

        [Fact]
        public void CalculateTotalMoney_ItemsWithNoDiscount_ReturnsCorrectTotalMoney()
        {
            // Arrange
            var checkoutService = new CheckoutService();
            var Elements = "AAB"; // No discounts applicable
            var expectedTotalMoney = 130; // Regular Money for all items

            // Act
            var actualTotalMoney = checkoutService.CalculateTotalMoney(Elements);

            // Assert
            Assert.Equal(expectedTotalMoney, actualTotalMoney);
        }

        [Fact]
        public void CalculateTotalMoney_MultipleItemsWithQuantityDiscount_ReturnsCorrectTotalMoney()
        {
            // Arrange
            var checkoutService = new CheckoutService();
            var Elements = "AAACD"; // 5 items 'A' with discount
            var expectedTotalMoney = 165; // Discounted Money for 5 items 'A'

            // Act
            var actualTotalMoney = checkoutService.CalculateTotalMoney(Elements);

            // Assert
            Assert.Equal(expectedTotalMoney, actualTotalMoney);
        }
    }
}
