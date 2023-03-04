using DieticianMVC.Domain.Interfaces;
using DieticianMVC.Domain.Model;

namespace DieticianMVC.Infrastructure.Repositories
{
    public class PatientStatusRepository : IPatientStatusRepository
    {
        private readonly Context _context;
        public PatientStatusRepository(Context context)
        {
            _context = context;
        }

        public void DeletePatientStatus(int patientId)
        {
            var patientStatus = _context.PatientStatuses.Find(patientId);
            if (patientStatus != null)
            {
                _context.PatientStatuses.Remove(patientStatus);
                _context.SaveChanges();
            }
        }

        public PatientStatus AddPatientStatus(PatientStatus patientStatus)
        {
            _context.PatientStatuses.Add(patientStatus);
            _context.SaveChanges();
            return patientStatus;
        }

        public PatientStatus UpdatePatientStatus(PatientStatus patientStatus)
        {
            if (patientStatus != null)
                _context.PatientStatuses.Update(patientStatus);
            _context.SaveChanges();
            return patientStatus;
        }

        public PatientStatus GetPatientStatusByPatientId(int patientId)
        {
            var patientStatus = _context.PatientStatuses.FirstOrDefault(i => i.PatientId == patientId);
            return patientStatus;
        }
    }
}

