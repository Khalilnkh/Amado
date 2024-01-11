using Amado.Models;

namespace Amado.ViewModels.Shops
{
    public class ShopVM
    {
        public IEnumerable<Product> Products { get; set; }
        public Product Product { get; set; }
        public ProductColor ProductColor { get; set; }

        public List<Brand> Brands { get; set; }
        public List<Category> Categories { get; set; }
    }
}
