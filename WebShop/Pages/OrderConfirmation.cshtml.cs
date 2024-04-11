using Microsoft.AspNetCore.Mvc.RazorPages;
using WebShopProject.Data;


namespace WebShop.Pages
{
    public class OrderConfirmationModel : PageModel
    {
        private readonly AppDbContext _context;

        public OrderConfirmationModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }
    }
}
