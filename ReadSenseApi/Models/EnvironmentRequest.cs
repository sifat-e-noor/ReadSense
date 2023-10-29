using static ReadSenseApi.Database.Entities.Environment;

namespace ReadSenseApi.Models
{
    public class EnvironmentRequest
    {
        /// <summary>
        /// The state of the place where the environment is located.
        /// Possible values are Quiet or Chaotic.
        /// </summary>
        public State PlaceState { get; set; }

        public TimeOfDayEnum TimeOfDay { get; set; }

        public Brightness BrightnessLevel { get; set; }
    }
}
