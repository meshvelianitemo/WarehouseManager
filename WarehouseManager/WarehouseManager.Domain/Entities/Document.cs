
using WarehouseManager.Domain.Enums;
namespace WarehouseManager.Domain.Entities
{
    public class Document : BaseEntity
    {
        public Guid UploadedBy { get; set; }

        public string FileName { get; set; } = string.Empty;

        public DocumentType DocumentType {  get; set; }

        public string FilePath { get; set; } = string.Empty;

        public DateTime UploadedAt { get; set; }

        public User UploadedByUser { get; set; } = null!;
    }
}
