using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebShopProject.Data;
using WebShopProject.Models;

namespace WebShop.Pages
{
    public class ShoppingCartModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly AccessControl _accessControl;
        public List<Product>? Products { get; set; }
        public List<Product> Cart;
		

		public decimal TotalPrice { get; set; }

		public ShoppingCartModel(AppDbContext context, AccessControl accessControl)
		{
			_context = context;
			Cart = new List<Product>();
			_accessControl = accessControl;
		}



		public void OnGet()
        {
            Products = _context.Products.ToList();

			Cart = _context.Products.Where(p => p.Account != null && p.Account.ID == _accessControl.LoggedInAccountID).ToList();
			TotalPrice = (decimal)Cart.Sum(p => p.Price);
        }
        public ActionResult OnPostAddToCart(int productId)
        {
            Product product = _context.Products.Find(productId);
            product.Account = _context.Accounts.Find(_accessControl.LoggedInAccountID);
			if (product.Account != null)
			{
				product.Account.ID = _accessControl.LoggedInAccountID;
				_context.SaveChanges();
			}
			Cart.Add(product);
			Products = _context.Products.ToList();

			return RedirectToPage();
		}
		public ActionResult OnPostRemoveFromCart(int productId)
		{
			Product product = _context.Products.Find(productId);
			product.Account = null;
			_context.SaveChanges();
			Cart.Remove(product);
			Products = _context.Products.ToList();
			return RedirectToPage();

		}
    }
}
