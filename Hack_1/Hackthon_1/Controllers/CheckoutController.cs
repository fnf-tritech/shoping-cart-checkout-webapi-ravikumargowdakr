using Microsoft.AspNetCore.Mvc;

namespace ShoppingCartDiscount.Controllers
{
    [ApiController]
    [Route("api/checkout")]
    public class CheckoutController : ControllerBase
    {
        private readonly CheckoutService checkoutService;

        public CheckoutController()
        {
            checkoutService = new CheckoutService();
        }

        [HttpGet]
        public IActionResult CalculateTotalMoney(string Elements)
        {
            decimal totalMoney = checkoutService.CalculateTotalMoney(Elements);
            return Ok(totalMoney);
        }
    }
}
