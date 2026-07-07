
using WarehouseManager.Domain.Enums;

namespace WarehouseManager.Domain.Entities
{
    public class SalesOrder : BaseEntity
    {
        public Guid CustomerId { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime OrderDate { get; set; }

        public SalesOrderStatus Status { get; set; } 

        public Customer Customer { get; set; } = null!;

        public User CreatedByUser { get; set; } = null!;

        public ICollection<SalesOrderItem> Items { get; set; } = new List<SalesOrderItem>();
    }
}
