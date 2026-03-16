namespace OrderManagementMvc.Models
{
    public class Product
    {

        public int Id { get; private set; }
        public string Name { get; set; }
        public int StockQuantity { get; set; }
        public decimal Price { get; set; }

        public Product() { }

        public Product(string name, int stockQuantity, decimal price)
        {
            Name = name;
            StockQuantity = stockQuantity;
            Price = price;
        }

    }
}
