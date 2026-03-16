using OrderManagementMvc.Enums;

namespace OrderManagementMvc.Models
{
    public class Order
    {
        public int Id { get; private set; }
        public DateTime OrderDate { get; private set; }
        public Customer Customer { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; private set; } = new List<OrderItem>();

        public Order() { }

        public Order(Customer customer, OrderStatus status)
        {
            Customer = customer;
            OrderDate = DateTime.Now;
            Status = status;
            
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }
    }
}
