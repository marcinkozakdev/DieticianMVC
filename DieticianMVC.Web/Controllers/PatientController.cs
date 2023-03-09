using DieticianMVC.Application.Interfaces;
using DieticianMVC.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DieticianMVC.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        
        public IActionResult Index()
        {
            var model = _patientService.GetAllPatientForList();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddPatient()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult AddPatient(PatientModel model)
        //{
        //    var id = patientService.AddPatient(model);
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult ViewPatient(int patientId)
        //{
        //    var id = patientService.GetPatientById(patientId);
        //    return View();
        //}
    }
}
