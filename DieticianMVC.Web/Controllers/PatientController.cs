using Microsoft.AspNetCore.Mvc;

namespace DieticianMVC.Web.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            var model = patientService.GetAllCustomersForList();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddPatient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPatient(PatientModel model)
        {
            var id = patientService.AddPatient(model);
            return View();
        }

        [HttpGet]
        public IActionResult ViewPatient(int patientId)
        {
            var id = patientService.GetPatientById(patientId);
            return View();
        }
    }
}
