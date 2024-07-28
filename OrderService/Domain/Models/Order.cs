namespace OrderService.Domain.Models
{
    public class Order
    {
        public Guid Id { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public DateTime CreatedDate { get; private set; }

        protected Order() { }

        public Order(string productName, int quantity)
        {
            Id = Guid.NewGuid();
            ProductName = productName;
            Quantity = quantity;
            CreatedDate = DateTime.UtcNow;
        }
    }
}
