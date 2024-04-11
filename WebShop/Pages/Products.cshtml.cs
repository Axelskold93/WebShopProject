using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebShopProject.Data;
using WebShopProject.Models;

namespace WebShopProject.Pages
{
	public class ProductsModel : PageModel
	{
		private readonly AppDbContext _context;
		private readonly AccessControl _accessControl;

		public ProductsModel(AppDbContext context, AccessControl accessControl)
		{ 
			_context = context;
			Cart = new List<Product>();
			_accessControl = accessControl;
		}
		public List<Product>? Products { get; set; }
		public List<Product> Cart;
		public int TotalPages { get; set; }
		public int CurrentPage { get; set; }

		public string? SearchName { get; set; }
		public string? SearchCategory { get; set; }

		public List<string?> Categories { get; set; } = new List<string?>();


        public void OnGet(int? pageNumber, string productName, string category)
			 
        {
            if (pageNumber.HasValue)
            {
                CurrentPage = pageNumber.Value;
            }
            const int PageSize = 10;
            
            

			IQueryable<Product> productsQuery = _context.Products;

			if (!string.IsNullOrEmpty(productName))
			{
				productsQuery = productsQuery.Where(p => p.Name.Contains(productName));
			}

			if (!string.IsNullOrEmpty(category))
			{
				productsQuery = productsQuery.Where(p => p.Category.Contains(category));
			}

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

            Products = productsQuery
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();

			Categories = _context.Products.Select(p => p.Category).Distinct().ToList();

			SearchName = productName;
			SearchCategory = category;

		}
		public ActionResult OnPostAddToCart(int productId, int currentPage)
		{
			Product product = _context.Products.Find(productId);
			product.Account = _context.Accounts.Find(_accessControl.LoggedInAccountID);
			if (product.Account != null)
			{
				
				_context.SaveChanges();
			}
			
			Products = _context.Products.ToList();
			

			return RedirectToPage(new { pageNumber = currentPage });
		}
	}
}
