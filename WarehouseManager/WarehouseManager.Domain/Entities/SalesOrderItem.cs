namespace WarehouseManager.Domain.Entities
{
    public class SalesOrderItem : BaseEntity
    {
        public Guid SalesOrderId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public SalesOrder SalesOrder { get; set; } = null!;

        public Product Product { get; set; } = null!;
    }
}
