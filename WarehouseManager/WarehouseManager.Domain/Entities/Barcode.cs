
using WarehouseManager.Domain.Enums;

namespace WarehouseManager.Domain.Entities
{
    public class Barcode : BaseEntity
    {
        public Guid ProductId { get; set; }

        public string Code { get; set; } = string.Empty;

        public BarcodeType Type { get; set; }

        public Product Product { get; set; } = null!;
    }
}
