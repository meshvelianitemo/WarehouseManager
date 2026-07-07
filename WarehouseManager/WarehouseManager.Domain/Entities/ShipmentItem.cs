namespace WarehouseManager.Domain.Entities
{
    public class ShipmentItem : BaseEntity
    {
        public Guid ShipmentId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public Shipment Shipment { get; set; } = null!;

        public Product Product { get; set; } = null!;
    }
}
