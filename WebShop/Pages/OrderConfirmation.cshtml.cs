using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebShop.Models;
using WebShopProject.Data;
using WebShopProject.Models;


namespace WebShop.Pages
{
	public class OrderConfirmationModel : PageModel
	{

		private readonly AppDbContext _context;
		private readonly AccessControl _accessControl;

		public OrderConfirmationModel(AppDbContext context, AccessControl accessControl)
		{
			_context = context;
			_accessControl = accessControl;
		}

		public Cart? Cart { get; set; }
		public decimal TotalPrice { get; set; }
		public decimal TotalPricePerProduct { get; set; }
		public int Quantity { get; set; }


		public void OnGet()
		{

			Account currentAccount = _context.Accounts.Find(_accessControl.LoggedInAccountID);
			if (currentAccount != null)
			{

				var accountIdAdd = currentAccount.ID;

				Cart = _context.Carts.Include(c => c.CartItems)
									 .ThenInclude(ci => ci.Product)
									 .FirstOrDefault(c => c.AccountID == accountIdAdd);

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
					TotalPricePerProduct = item.Product.Price * item.Quantity;
				}
			}
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



			return RedirectToPage("/index");
		}
	}
}
