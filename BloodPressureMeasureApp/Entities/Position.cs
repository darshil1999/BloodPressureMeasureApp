using System.ComponentModel.DataAnnotations;

namespace BloodPressureMeasureApp.Entities
{
    public class Position
    {
        [Key]
        public string PositionId { get; set; }

        public string? PositionName { get; set; }
    }
}
