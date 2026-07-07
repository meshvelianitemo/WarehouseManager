namespace WarehouseManager.Domain.Entities
{
    public class Inventory : BaseEntity
    {
        public Guid ProductId { get; set; }

        public Guid LocationId { get; set; }

        public int Quantity { get; set; }

        public Product Product { get; set; } = null!;

        public Location Location { get; set; } = null!;

        public ICollection<InventoryTransaction> Transactions { get; set; } = new List<InventoryTransaction>();

    }
}
