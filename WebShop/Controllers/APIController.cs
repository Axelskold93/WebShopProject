using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShopProject.Data;
using WebShopProject.Models;

namespace WebShop.Controllers
{
    [Route("/api")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly AppDbContext database;

        public APIController(AppDbContext database)
        {
            this.database = database;
        }
        [HttpGet("products")]
        [AllowAnonymous]
        public IActionResult GetProducts(string? name, string? category, int pageNumber = 1, int pageSize = 10)
        {
            var products = database.Products.AsQueryable();
            if (!string.IsNullOrWhiteSpace(name))
            {
                products = products.Where(p => p.Name.Contains(name));
            }
            if (!string.IsNullOrWhiteSpace(category))
            {
                products = products.Where(p => p.Category.Contains(category));
            }
            var absoluteURL = $"{Request.Scheme}://{Request.Host}";
            foreach (var product in products)
            {
                if (!string.IsNullOrWhiteSpace(product.ImagePath))
                {
                    product.ImagePath = $"{absoluteURL}/images/{product.ImagePath}";
                }
            }
            return Ok(products.Skip((pageNumber - 1) * pageSize).Take(pageSize));
            
        }
    }
}// test url: https://localhost:5000/api/products?name=t%C3%A4lt&category=Camping
