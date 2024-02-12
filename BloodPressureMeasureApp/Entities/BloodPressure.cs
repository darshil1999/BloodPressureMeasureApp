using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodPressureMeasureApp.Entities
{
    public class BloodPressure
    {
        public int BloodPressureId { get; set; }

        [Required(ErrorMessage = "Systolic is required.")]
        [Range(20, 400, ErrorMessage = "Systolic must between 20 to 400.")]
        public int? Systolic { get; set; }

        [Required(ErrorMessage = "Diastolic is required.")]
        [Range(10, 300, ErrorMessage = "Diastolic must between 10 to 300.")]
        public int? Diastolic { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public DateTime? MeasurementDate { get; set; }

        public string PositionId { get; set; }
        [ForeignKey("PositionId")]
        public Position Position { get; set; }

        public string BPCategory
        {
            get
            {
                if (Systolic < 120 && Diastolic < 80)
                    return "Normal";
                if (Systolic <= 129 && Diastolic < 80)
                    return "Elevated";
                if (Systolic <= 139 || Diastolic <= 89)
                    return "Hypertension Stage 1";
                if (Systolic >= 140 || Diastolic >= 90)
                    return "Hypertension Stage 2";
                if (Systolic > 180 || Diastolic > 120)
                    return "Hypertensive Crisis";
                return "Unknown";
            }
        }


    }
}
