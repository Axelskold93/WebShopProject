using Microsoft.AspNetCore.Mvc.RazorPages;
using WebShopProject.Data;
using WebShopProject.Models;


namespace WebShop.Pages
{
    public class OrderSummaryModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly AccessControl _accessControl;

        public OrderSummaryModel(AppDbContext context, AccessControl accessControl)
        {
            _context = context;
            Cart = new List<Product>();
            _accessControl = accessControl;
        }

        public List<Product>? AllProducts { get; set; }
        public List<Product> Cart;
        public decimal TotalPrice { get; set; }

        public void OnGet()
        {
            AllProducts = _context.Products.ToList();

            if (_accessControl.LoggedInAccountID != null)
            {
                Cart = _context.Products
                                .Where(p => p.Account != null && p.Account.ID == _accessControl.LoggedInAccountID)
                                .ToList();
                TotalPrice = Cart.Sum(p => p.Price);
            }
        }
    }
}
