namespace DieticianMVC.Application.ViewModels.Dietician
{
    public class ListDieticianForListVm
    {
        public List<DieticianForListVm> Dieticians { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
    }
}
