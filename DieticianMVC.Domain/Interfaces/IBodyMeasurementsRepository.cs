﻿using DieticianMVC.Domain.Model;

namespace DieticianMVC.Domain.Interfaces
{
    public interface IBodyMeasurementsRepository
    {
        IQueryable<BodyMeasurements> GetBodyMeasurementsByPatientId(int patientId);
        BodyMeasurements GetBodyMeasurementsById(int bodyMeasurementsId);
        int AddBodyMeasurements(BodyMeasurements bodyMeasurements);
        BodyMeasurements UpdateBodyMeasurements(BodyMeasurements bodyMeasurements);
        void DeleteBodyMeasurements(int bodyMeasurementsId);
    }
}
