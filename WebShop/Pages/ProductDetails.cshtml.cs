using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebShopProject.Data;
using WebShopProject.Models;

namespace WebShopProject.Pages
{
    public class ProductDetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public ProductDetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

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
    }
}
