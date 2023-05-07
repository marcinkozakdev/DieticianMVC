using DieticianMVC.Application.Interfaces;
using DieticianMVC.Application.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace DieticianMVC.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("Users")]
        public IActionResult Index()
        {
            var model = _userService.GetAllUsers(10,1,"");
            return View(model);
        }

        [HttpPost]
        [Route("Users")]
        public IActionResult Index(int pageSize, int pageNo, string searchString)
        {
            if(pageNo == null)
            {
                pageNo = 1;
            }
            if(searchString is null)
            {
                searchString = String.Empty;
            }
            var model = _userService.GetAllUsers(pageSize, pageNo, searchString);
            return View(model);
        }

        public IActionResult AddRolesToUser(string id)
        {
            var userVm = _userService.GetUserDetails(id);
            return PartialView("AddRolesToUser", userVm);
        }

        [HttpPost]
        public async Task<IActionResult> AddRolesToUser(UserDetailVm user)
        {
            await _userService.ChangeUserRolesAsync(user.Id, user.UserRoles);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            await _userService.DeleteUserAsync(id);
            return RedirectToAction("Index");
        }
    }
}
