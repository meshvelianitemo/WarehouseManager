namespace WarehouseManager.Domain.Entities
{
    public class Shipment : BaseEntity
    {
        public Guid WarehouseId { get; set; }

        public string ShipmentNumber { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public Warehouse Warehouse { get; set; } = null!;

        public ICollection<ShipmentItem> Items { get; set; } = new List<ShipmentItem>();
    }
}
