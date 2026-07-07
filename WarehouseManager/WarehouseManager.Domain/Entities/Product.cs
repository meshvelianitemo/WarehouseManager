using WarehouseManager.Domain.Enums;

namespace WarehouseManager.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Guid CategoryId { get; set; }

        public Guid SupplierId { get; set; }

        public string SKU { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        
        public ProductStatus Status { get; set;  }

        public ProductType Type { get; set; }

        public DateTime CreatedAt { get; set; }

        public Category Category { get; set; } = null!;

        public Supplier Supplier { get; set; } = null!;

        public ICollection<Barcode> Barcodes { get; set; } = new List<Barcode>();

        public ICollection<Inventory> Inventory { get; set; } = new List<Inventory>();

        public ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();
        public ICollection<ShipmentItem> ShipmentItems { get; set; } = new List<ShipmentItem>();
        public ICollection<SalesOrderItem> SalesOrderItems { get; set; } = new List<SalesOrderItem>();
    }
}
