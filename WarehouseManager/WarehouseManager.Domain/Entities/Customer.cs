namespace WarehouseManager.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public ICollection<SalesOrder> Orders { get; set; } = new List<SalesOrder>();
    }
}
