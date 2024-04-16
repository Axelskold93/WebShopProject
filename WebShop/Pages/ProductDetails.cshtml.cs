using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebShop.Models;
using WebShopProject.Data;
using WebShopProject.Models;

namespace WebShopProject.Pages
{
	public class ProductDetailsModel : PageModel
	{
		private readonly AppDbContext _context;
		private readonly AccessControl _accessControl;
		public Product Product { get; set; }
		public Cart Cart { get; set; }

		public ProductDetailsModel(AppDbContext context, AccessControl accessControl)
		{
			_context = context;
			_accessControl = accessControl;
		}

		public IActionResult OnGet(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Product = _context.Products.FirstOrDefault(m => m.ProductId == id);

			if (Product == null)
			{
				return NotFound();
			}

			return Page();
		}

		public ActionResult OnPostAddToCart(int productId)
		{
			Product product = _context.Products.Find(productId);
			Account currentAccount = _context.Accounts.Include(a => a.Cart.CartItems).Single(account => account.ID == _accessControl.LoggedInAccountID);

			if (product != null && currentAccount != null)
			{
				if (currentAccount.Cart == null)
				{
					currentAccount.Cart = new Cart { AccountID = currentAccount.ID };
					_context.Carts.Add(currentAccount.Cart);
				}

				CartItem cartItem = new CartItem { CartID = currentAccount.Cart.ID, ProductID = productId };
				currentAccount.Cart.CartItems.Add(cartItem);
				_context.SaveChanges();
			}



			return RedirectToPage("/ProductDetails", new { id = productId });
		}
		

	}
}
