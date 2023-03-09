using DieticianMVC.Domain.Interfaces;
using DieticianMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace DieticianMVC.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly Context _context;
        public PatientRepository(Context context)
        {
            _context = context;
        }

        public void DeletePatient(int patientId)
        {
            var patient = _context.Patients.Find(patientId);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
            }
        }

        public int AddPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
            return patient.Id;
        }

        public Patient UpdatePatient(Patient patient)
        {
            if (patient != null)
                _context.Patients.Update(patient);
            _context.SaveChanges();
            return patient;
        }

        public IQueryable<Patient> GetPatientByDieticianId(int dieticianId)
        {
            var patients = _context.Patients.Where(i => i.DieticianId == dieticianId);
            return patients;
        }

        public Patient GetPatientById(int patientId)
        {
            var patient = _context.Patients.FirstOrDefault(i => i.Id == patientId);
            return patient;
        }

        public Patient GetPatient(int patientId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Patient> GetAllActivePatients()
        {
            var patients = _context.Patients.AsNoTracking();
            return patients;
        }

    }
}
