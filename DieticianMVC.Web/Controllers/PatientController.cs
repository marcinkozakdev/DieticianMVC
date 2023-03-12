using DieticianMVC.Application.Interfaces;
using DieticianMVC.Application.Services;
using DieticianMVC.Application.ViewModels.Patient;
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

        [HttpGet]
        public IActionResult Index()
        {
            var model = _patientService.GetAllPatientForList(3, 1,"");
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNumber, string searchString)
        {
            if(!pageNumber.HasValue)
                pageNumber = 1;

            if(searchString is null)
                searchString = String.Empty;

            var model = _patientService.GetAllPatientForList(pageSize, pageNumber.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new NewPatientVm());
        }

        [HttpPost]
        public IActionResult Add(NewPatientVm patientVm)
        {
            var id = _patientService.AddPatient(patientVm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var patient = _patientService.GetPatientForEdit(id);
            return View(patient);
        }

        [HttpPost]
        public IActionResult Edit(NewPatientVm patientVm)
        {
            _patientService.UpdatePatient(patientVm);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(PatientDetailsVm patientVm)
        {
            _patientService.UpdatePatientDetails(patientVm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int patientId)
        {
            _patientService.DeletePatient(patientId);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int patientId)
        {
            var patient = _patientService.GetPatientDetails(patientId);
            return View(patient);
        }
    }
}
