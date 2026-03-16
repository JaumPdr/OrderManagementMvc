namespace OrderManagementMvc.Models
{
    public class OrderItem
    {
        public int Id { get; private set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal SalePrice { get; set; }
        public Order Order { get; set; }

        public OrderItem() { }

        public OrderItem(Product product, int quantity, decimal salesPrice, Order order)
        {
            Product = product;
            Quantity = quantity;
            SalePrice = salesPrice;
            Order = order;
        }
    }
}
