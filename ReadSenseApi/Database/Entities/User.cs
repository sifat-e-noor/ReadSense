using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ReadSenseApi.Database.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        public string? LastName { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Username { get; set; }

        [JsonIgnore]
        [MaxLength(50)]
        public string? Password { get; set; }

        [Required]
        public Boolean? AgreementSigned { get; set; } = false;

        public DateTimeOffset? Inserted { get; set; }

        public DateTimeOffset? LastUpdated { get; set; }

        public List<Device> Devices { get; } = new List<Device>();
        
    }
}
