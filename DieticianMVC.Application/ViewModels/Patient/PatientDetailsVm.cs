﻿using DieticianMVC.Domain.Model;

namespace DieticianMVC.Application.ViewModels.Patient
{
    public class PatientDetailsVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<FoodPreferencesForListVm> FoodPreferences { get; set; }
        public List<FoodAllergiesAndIntolerancesForListVm> FoodAllergiesAndIntolerances { get; set; }
        public List<DislikedProductForListVm> DislikedProducts { get; set; }
        public List<LikedProductForListVm> LikedProducts { get; set; }
        public List<BodyMeasurementsForListVm> BodyMeasurements { get; set; }
        public List<Menu> Menus { get; set; }
    }
}