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
		public List<Product>? Products { get; set; }
		public int TotalPages { get; set; }
		public int CurrentPage { get; set; }

		public string? SearchName { get; set; }
		public string? SearchCategory { get; set; }

		public List<string?> Categories { get; set; } = new List<string?>();


		public void OnGet(int? page, string productName, string category)
		{
			const int PageSize = 10;
			CurrentPage = page ?? 1;

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
			TotalPages = (int)Math.Ceiling(totalProducts / (double)PageSize);

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

			Categories = _context.Products.Select(p => p.Category).Distinct().ToList();

			SearchName = productName;
			SearchCategory = category;

		}
	}
}
