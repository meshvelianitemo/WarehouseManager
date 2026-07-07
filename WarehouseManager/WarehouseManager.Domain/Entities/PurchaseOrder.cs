namespace WarehouseManager.Domain.Entities
{
    public class PurchaseOrder : BaseEntity
    {
        public Guid SupplierId { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime OrderDate { get; set; }

        public string Status { get; set; } = string.Empty;

        public Supplier Supplier { get; set; } = null!;

        public User CreatedByUser { get; set; } = null!;

        public ICollection<PurchaseOrderItem> Items { get; set; } = new List<PurchaseOrderItem>();
    }
}
