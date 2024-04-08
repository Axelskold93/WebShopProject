using Microsoft.AspNetCore.Mvc.RazorPages;
using WebShopProject.Data;
using WebShopProject.Models;

namespace WebShopProject.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly AppDbContext _context;

        public ProductsModel(AppDbContext context)
        {
            _context = context;
        }
        public List<Product> Products { get; set; }
        public void OnGet()
        {

            Products = _context.Products.ToList();

        }
    }
}
