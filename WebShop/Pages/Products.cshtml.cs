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
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }

        public void OnGet(int? page)
        {
            const int PageSize = 10;
            CurrentPage = page ?? 1;

            var totalProducts = _context.Products.Count();
            TotalPages = (int)Math.Ceiling((double)totalProducts / (double)PageSize);

            if (CurrentPage > TotalPages)
            {
                CurrentPage = TotalPages;
            }
            if (CurrentPage < 1)
            {
                CurrentPage = 1;
            }

            Products = _context.Products
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();

        }
    }
}
