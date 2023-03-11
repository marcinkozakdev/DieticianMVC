namespace DieticianMVC.Application.ViewModels.Patient
{
    public class ListPatientsForListVm
    {
        public List<PatientForListVm> Patients { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
    }
}
