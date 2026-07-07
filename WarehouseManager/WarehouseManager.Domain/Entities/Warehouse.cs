
namespace WarehouseManager.Domain.Entities
{
    public class Warehouse : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public ICollection<Location> Locations { get; set; } = new List<Location>();

        public ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
        public ICollection<Pallet> Pallets { get; set; } = new List<Pallet>();
    }
}
