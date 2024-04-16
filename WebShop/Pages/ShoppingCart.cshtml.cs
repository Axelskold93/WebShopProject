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

			CalculateCartSummary();
		}

		public ActionResult OnPostEmptyCart()
		{
			Account CurrentAccount = _context.Accounts
				.Include(a => a.Cart)
				.ThenInclude(c => c.CartItems)
				.FirstOrDefault(a => a.ID == _accessControl.LoggedInAccountID);

			if (CurrentAccount != null && CurrentAccount.Cart != null)
			{
				CurrentAccount.Cart.CartItems.Clear(); 
				_context.SaveChanges(); 
			}

			CalculateCartSummary();

			return RedirectToPage("/ShoppingCart"); 
		}

		public void CalculateCartSummary()
		{
			Account CurrentAccount = _context.Accounts
				.Include(a => a.Cart)
				.ThenInclude(c => c.CartItems)
				.FirstOrDefault(a => a.ID == _accessControl.LoggedInAccountID);
			
			TotalPrice = 0;

			if (CurrentAccount.Cart != null && CurrentAccount.Cart.CartItems != null)
			{
				foreach (var item in CurrentAccount.Cart.CartItems)
				{

					TotalPrice += item.Product.Price * item.Quantity;
				}
			}
		}
	}
}
