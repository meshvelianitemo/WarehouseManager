namespace WarehouseManager.Domain.Entities
{
    public class Location : BaseEntity
    {
        public Guid WarehouseId { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public Warehouse Warehouse { get; set; } = null!;

        public ICollection<Inventory> Inventory { get; set; } = new List<Inventory>();
        public ICollection<Pallet> Pallets { get; set; } = new List<Pallet>();
    }
}
