using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace ReadSenseApi.Database.Entities
{
    public class Device
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public string? DeviceInfo { get; set; }

        [Required]
        [ForeignKey(nameof(UserId))]
        public User? User { get; init; }
    }
}
