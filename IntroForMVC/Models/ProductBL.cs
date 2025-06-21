namespace IntroForMVC.Models
{
    public class ProductBL
    {
        List<Product> products;
        public ProductBL()
        {
            products = new List<Product>();
            products.Add(new Product() { Id = 1, Name = "Iphone 16", Price = 1200, Description = "Smart Phone", ImageURL = "1.jpg" });
            products.Add(new Product() { Id = 2, Name = "S25", Price = 1500, Description = "Smart Phone", ImageURL = "2.jpg" });
            products.Add(new Product() { Id = 3, Name = "Pixel 8", Price = 950, Description = "Smart Phone", ImageURL = "3.jpg" });
            products.Add(new Product() { Id = 4, Name = "Galaxy Fold", Price = 2000, Description = "Smart Fold Phone", ImageURL = "4.jpg" });

        }

        public List<Product> GetAll()
        {
            return products;
        }

        public Product GetById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }
    }
}
