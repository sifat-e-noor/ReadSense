using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadSenseApi.Database.Entities
{
    public class Device
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        [MaxLength(100)]
        public string? FingerPrint { get; set; }

        [Required]
        public string? DeviceInfo { get; set; }

        [Required]
        [ForeignKey(nameof(UserId))]
        public User? User { get; init; }

        public DateTimeOffset? Inserted { get; set; }

        public DateTimeOffset? LastUpdated { get; set; }
    }
}
