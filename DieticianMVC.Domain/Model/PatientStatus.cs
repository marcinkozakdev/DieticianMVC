namespace DieticianMVC.Domain.Model
{
    public class PatientStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Patient Patients { get; set; }  
    }
}
