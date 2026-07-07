namespace WarehouseManager.Domain.Entities
{
    public class InventoryTransaction : BaseEntity
    {
        public Guid InventoryId { get; set; }

        public Guid UserId { get; set; }

        public string TransactionType { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public string Reference { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public Inventory Inventory { get; set; } = null!;

        public User User { get; set; } = null!;

    }
}
