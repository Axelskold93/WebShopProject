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
		public Account CurrentAccount { get; set; }
		public List<Product>? Products { get; set; }
		public int CurrentPage { get; set; }	
		public ProductDetailsModel(AppDbContext context, AccessControl accessControl)
		{
			_context = context;
			_accessControl = accessControl;
		}

		public IActionResult OnGet(int? id, int currentPage)
		{
			CurrentPage = currentPage;
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
			

			CurrentAccount = _context.Accounts.Include(a => a.Cart).ThenInclude(c => c.CartItems).FirstOrDefault(a => a.ID == _accessControl.LoggedInAccountID);


			Product product = _context.Products.Find(productId);

			if (product != null && CurrentAccount != null)
			{
				if (CurrentAccount.Cart == null)
				{
					CurrentAccount.Cart = new Cart { AccountID = CurrentAccount.ID };
					CurrentAccount.Cart.CartItems = new List<CartItem>();
					_context.Carts.Add(CurrentAccount.Cart);
				}



				var existingCartItem = CurrentAccount.Cart.CartItems.FirstOrDefault(item => item.ProductID == productId);

				if (existingCartItem != null)
				{
					existingCartItem.Quantity++;
				}

				else
				{
					CartItem cartItem = new CartItem { CartID = CurrentAccount.Cart.ID, ProductID = productId, Quantity = 1 };
					CurrentAccount.Cart.CartItems.Add(cartItem);
				}


			}
			_context.SaveChanges();
			Products = _context.Products.ToList();
			return RedirectToPage("/ProductDetails", new { id = productId, currentPage = CurrentPage });
		}
	}
}
