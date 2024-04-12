using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebShopProject.Data;
using WebShopProject.Models;

namespace WebShopProject.Pages
{
    public class ProductDetailsModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly AccessControl _accessControl;

        public ProductDetailsModel(AppDbContext context, AccessControl accessControl)
        {
            _context = context;
            Cart = new List<Product>();
            _accessControl = accessControl;
        }

        public Product Product { get; set; }
        public List<Product> Cart;

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

        public ActionResult OnPostAddToCart(int productId, int currentPage)
        {
            Product product = _context.Products.Find(productId);
            product.Account = _context.Accounts.Find(_accessControl.LoggedInAccountID);
            if (product.Account != null)
            {
                Cart.Add(product);
                _context.SaveChanges();
            }

            return RedirectToPage("/ProductDetails", new { id = productId });
        }

    }
}
