namespace DieticianMVC.Domain.Model
{
    public class BodyMeasurements
    {
        public int Id { get; set; }
        public DateTime MeasurementDate { get; set;  }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal WaistCircumference { get; set; }
        public decimal HipCircumference { get; set; }
        public decimal ChestCircumference { get; set; }
        public decimal ArmCircumference { get; set; }
        public decimal CalfCircumference { get; set; }
        public decimal ThighCircumference { get; set; }
        public decimal TotalMuscleMass { get; set; }
        public decimal SkeletalMuscleMass { get; set; }
        public decimal BodyFatMass { get; set; }
        public decimal TotalWaterContent { get; set; }
        public decimal BoneMineralContent { get; set; }
        public decimal AdiposeTissue { get; set; }
        public decimal BasalMetabolism { get; set; }
        public int MetabolicAge { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
