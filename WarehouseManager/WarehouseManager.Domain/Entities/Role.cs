using WarehouseManager.Domain.Enums;

namespace WarehouseManager.Domain.Entities
{
    public class Role : BaseEntity
    {
        public RoleName Name { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
