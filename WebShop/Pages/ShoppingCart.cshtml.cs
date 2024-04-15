using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebShop.Models;
using WebShopProject.Data;
using WebShopProject.Models;

namespace WebShop.Pages
{
    public class ShoppingCartModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly AccessControl _accessControl;

        public ShoppingCartModel(AppDbContext context, AccessControl accessControl)
        {
            _context = context;
            _accessControl = accessControl;
        }

        public Cart? Cart { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }

        public void OnGet()
        {

            Account currentAccount = _context.Accounts.Find(_accessControl.LoggedInAccountID);
            if (currentAccount != null)
            {
                
                var accountId = currentAccount.ID;

			    Cart = _context.Carts.Include(c => c.CartItems)
                                     .ThenInclude(ci => ci.Product)
                                     .FirstOrDefault(c => c.AccountID == accountId);

			}
            Quantity = 0;
            if (Cart != null)
            {
				foreach (var item in Cart.CartItems)
                {
					Quantity += item.Quantity;
				}
			}   
            if (Cart != null)
            {
				TotalPrice = 0;
				foreach (var item in Cart.CartItems)
                {
					TotalPrice += item.Product.Price * item.Quantity;
				}
			}   
        }
    }
}
