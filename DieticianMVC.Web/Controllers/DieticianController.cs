using DieticianMVC.Application.Interfaces;
using DieticianMVC.Application.ViewModels.Dietician;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DieticianMVC.Web.Controllers
{
    public class DieticianController : Controller
    {
        private readonly IDieticianService _dieticianService;
        private readonly ILogger<DieticianController> _logger;

        public DieticianController(IDieticianService dieticianService, ILogger<DieticianController> logger)
        {
            _dieticianService = dieticianService;
            _logger = logger;
        }

        [Route("Dieticians")]
        public IActionResult Index()
        {
            var dieticians = _dieticianService.GetAllDieticiansForList();
            return View(dieticians);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        [Route("Dietician/Profile/{id}")]
        public IActionResult ViewDietician(string id)
        {
            var dieticianVm = _dieticianService.GetDieticianDetails(id);
            if (dieticianVm == null)
            {
                _logger.LogInformation("Can't show dietician details - dietician dosen't exist");
                return RedirectToAction("Index");
            }
            return View(dieticianVm);
        }

        [Route("Dietician/New")]
        public IActionResult AddDietician()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!_dieticianService.CheckIfDieticianExist(userId))
            {
                return RedirectToAction("ViewEmployee");
            }
            var model = new NewDieticianVm()
            {
                UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value
            };
            return View(model);
        }

        [Route("Dietician/Details")]
        public IActionResult ViewDietician()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var dieticianVm = _dieticianService.GetDieticianDetails(userId);
            if (dieticianVm == null)
            {
                _logger.LogInformation("Can't show dietician details - dietician dosen't exist");
                return RedirectToAction("Index");
            }
            return View(dieticianVm);
        }

        [Route("Dietician/Edit")]
        public IActionResult EditDietician()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var dieticianVm = _dieticianService.GetDieticianForEdit(userId);
            if (dieticianVm == null)
            {
                _logger.LogInformation("Can't edit dietician - dietician dosen't exist");
                return RedirectToAction("Index");
            }
            return View(dieticianVm);
        }

        [HttpPost]
        [Route("Dietician/Edit")]
        public IActionResult EditDietician(NewDieticianVm dieticianVm)
        {
            if (!ModelState.IsValid)
            {
                return View(dieticianVm.Id);
            }
            _dieticianService.UpdateDietician(dieticianVm);
            return RedirectToAction("ViewDietician");
        }

        //[Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            _dieticianService.DeleteDietician(id);
            _logger.LogInformation("Dietician " + id + " has been deleted");
            return RedirectToAction("Index");
        }

        public IActionResult NewAddress()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = new NewAddressVm
            {
                DieticianId = _dieticianService.GetDieticianByUserId(userId).Id
            };
            return PartialView("AddNewAddressForDietician", model);
        }

        [HttpPost]
        public IActionResult AddNewAddressForDietician(NewAddressVm addressVm)
        {
            var id = _dieticianService.AddAddress(addressVm);
            return RedirectToAction("EditDietician");
        }

       
        public IActionResult EditAddress(int id)
        {
            var model = _dieticianService.GetAddressForEdit(id);
            if (model == null)
            {
                _logger.LogInformation("Can't edit address - address dosen't exist");
                return RedirectToAction("EditDietician");
            }
            return PartialView("EditAddressForDietician", model);
        }

        [HttpPost]
        public IActionResult EditAddressForDietician(NewAddressVm addressVm)
        {
            _dieticianService.UpdateAddress(addressVm);
            return RedirectToAction("EditDietician");

        }

        public IActionResult DeleteAddress(int id)
        {
            _dieticianService.DeleteAddress(id);
            return RedirectToAction("EditDietician");
        }
    }
}
