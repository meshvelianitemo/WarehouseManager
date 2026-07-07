namespace WarehouseManager.Domain.Entities
{
    public class Pallet : BaseEntity
    {
        public Guid WarehouseId { get; set; }

        public Guid LocationId { get; set; }

        public string Barcode { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public Warehouse Warehouse { get; set; } = null!;

        public Location Location { get; set; } = null!;
    }
}
