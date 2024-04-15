using WebShopProject.Models;

namespace WebShop.Models
{
    public class CartItem
    {
        public int ID { get; set; }
        public int CartID { get; set; }
        public Cart Cart { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
