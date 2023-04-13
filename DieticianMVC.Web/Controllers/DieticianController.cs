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

        [Route("dietician/all")]
        public IActionResult Index()
        {
            var dieticians = _dieticianService.GetAllDieticiansForList();
            return View();
        }

        [HttpGet]
        //[Authorize(Roles = "Accountant, Chief, Admin")]
        [Route("dietician/profile/{id}")]
        public IActionResult ViewDietician(string id)
        {
            var empVm = _dieticianService.GetDieticianDetails(id);
            if (empVm == null)
            {
                _logger.LogInformation("Can't show dietician details - employee dosen't exist");
                return RedirectToAction("Index");
            }
            return View(empVm);
        }

    }
}
