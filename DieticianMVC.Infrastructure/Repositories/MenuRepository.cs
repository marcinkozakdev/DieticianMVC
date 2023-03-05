using DieticianMVC.Domain.Interfaces;
using DieticianMVC.Domain.Model;

namespace DieticianMVC.Infrastructure.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly Context _context;
        public MenuRepository(Context context)
        {
            _context = context;
        }

        public Menu GetMenuById(int menuId)
        {
            var menu = _context.Menus.FirstOrDefault(i => i.Id == menuId);
            return menu;
        }

        public IQueryable<Menu> GetAllMenusByPatientId(int patientId)
        {
            var menu = _context.Menus.Where(i => i.PatientId == patientId);
            return menu;
        }

        public Menu AddMenu(Menu menu)
        {
            _context.Menus.Add(menu);
            _context.SaveChanges();
            return menu;
        }

        public Menu UpdateMenu(Menu menu)
        {
            if (menu != null)
                _context.Menus.Update(menu);
            _context.SaveChanges();
            return menu;
        }

        public void DeleteMenu(int menuId)
        {
            var menu = _context.Menus.FirstOrDefault(d => d.Id == menuId);
            if (menu != null)
            {
                _context.Menus.Remove(menu);
                _context.SaveChanges();
            }
        }
    }
}
