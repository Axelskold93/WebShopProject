using Microsoft.AspNetCore.Mvc.RazorPages;
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
            Cart = new List<Product>();
            _accessControl = accessControl;
        }

        public List<Product>? Products { get; set; }
        public List<Product> Cart;
        public decimal TotalPrice { get; set; }

        public void OnGet()
        {
            Products = _context.Products.ToList();


            Cart = _context.Products.Where(p => p.Account != null && p.Account.ID == _accessControl.LoggedInAccountID).ToList();
            TotalPrice = (decimal)Cart.Sum(p => p.Price);
        }
    }
}
