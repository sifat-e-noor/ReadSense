using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadSenseApi.Database.Entities
{
    public class Environment
    {
        public enum State
        {
            [Display(Name = "Quiet Place")]
            Quiet,
            [Display(Name = "Chaotic Place")]
            Chaotic
        }

        public enum LocationEnum
        {
            Home,
            Transport,
            Outside
        }

        public enum Brightness
        {
            Dark,
            Dim,
            Bright
        }

        /// <summary>
        /// The unique identifier for the environment.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The unique identifier for the user associated with the environment.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The unique identifier for the device associated with the environment.
        /// </summary>
        public int DeviceId { get; set; }

        /// <summary>
        /// The state of the place where the environment is located.
        /// Possible values are Quiet or Chaotic.
        /// </summary>
        
        public State? PlaceState { get; set; }

        /// <summary>
        /// The time of day when the environment is being monitored.
        /// Possible values are Morning, Day, Evening, or Night.
        /// </summary>
        public LocationEnum? Location { get; set; }

        /// <summary>
        /// The brightness level of the environment.
        /// Possible values are Dark, Dim, or Bright.
        /// </summary>

        public Brightness? BrightnessLevel { get; set; }

        /// <summary>
        /// The date and time when the environment was inserted into the database.
        /// </summary>
        public DateTimeOffset? Inserted { get; set; }

        /// <summary>
        /// The date and time when the environment was last updated in the database.
        /// </summary>

        public DateTimeOffset? LastUpdated { get; set; }


        [Required]
        [ForeignKey(nameof(DeviceId))]
        public Device? Device { get; init; }

        public List<ReadSettingsEvent> ReadSettingsEvents { get; set; } = [];
    }
}
