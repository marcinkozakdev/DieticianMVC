using DieticianMVC.Domain.Model;
using DieticianMVC.Domain.Interfaces;

namespace DieticianMVC.Infrastructure.Repositories
{
    public class BodyMeasurementsRepository : IBodyMeasurementsRepository
    {
        private readonly Context _context;
        public BodyMeasurementsRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<BodyMeasurements> GetBodyMeasurementsByPatientId(int patientId)
        {
            var bodyMesurements = _context.BodyMeasurements.Where(i => i.PatientId == patientId);
            return bodyMesurements;
        }

        public BodyMeasurements GetBodyMeasurementsById(int bodyMeasurementsId)
        {
            var bodyMesurements = _context.BodyMeasurements.FirstOrDefault(i => i.Id == bodyMeasurementsId);
            return bodyMesurements;
        }

        public BodyMeasurements AddBodyMeasurements(BodyMeasurements bodyMeasurements)
        {
            _context.BodyMeasurements.Add(bodyMeasurements);
            _context.SaveChanges();
            return bodyMeasurements;
        }

        public BodyMeasurements UpdateBodyMeasurements(BodyMeasurements bodyMeasurements)
        {
            if (bodyMeasurements != null)
                _context.BodyMeasurements.Update(bodyMeasurements);
            _context.SaveChanges();

            return bodyMeasurements;
        }

        public void DeleteBodyMeasurements(int bodyMeasurementsId)
        {
            var bodyMeasurements = _context.BodyMeasurements.Find(bodyMeasurementsId);
            if (bodyMeasurements != null)
            {
                _context.BodyMeasurements.Remove(bodyMeasurements);
                _context.SaveChanges();
            }
        }
    }
}

