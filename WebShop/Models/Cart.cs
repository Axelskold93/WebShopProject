using WebShopProject.Models;

namespace WebShop.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public int AccountID { get; set; }
        public Account? Account { get; set; }
        public List<CartItem>? CartItems { get; set; }
    }
}
