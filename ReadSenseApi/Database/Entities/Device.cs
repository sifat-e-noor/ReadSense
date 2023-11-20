using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadSenseApi.Database.Entities
{
    /// <summary>
    /// Represents a user device in the database.
    /// </summary>
    public class Device
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        [MaxLength(100)]
        public string? FingerPrint { get; set; }

        [Required]
        public string? DeviceInfo { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; init; }

        /// <summary>
        /// The current read settings in JSON format for this device.
        /// </summary>
        public string? ReadSettings { get; set; }

        public DateTimeOffset? Inserted { get; set; }

        public DateTimeOffset? LastUpdated { get; set; }
        public List<Environment> Environments { get; } = new List<Environment>();
    }
}
