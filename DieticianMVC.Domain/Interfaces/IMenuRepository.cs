using DieticianMVC.Domain.Model;

namespace DieticianMVC.Domain.Interfaces
{
    public interface IMenuRepository
    {
        Menu GetMenuById(int menuId);
        IQueryable<Menu> GetAllMenusByPatientId(int patientId);
        Menu AddMenu(Menu menu);
        Menu UpdateMenu(Menu menu);
        void DeleteMenu(int menuId);
    }
}
