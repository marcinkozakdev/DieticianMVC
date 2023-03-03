using DieticianMVC.Domain.Model;

namespace DieticianMVC.Domain.Interfaces
{
    public interface IFoodAllergiesAndIntolerancesRepository
    {
        IQueryable<FoodAllergiesAndIntolerances> GetDislikedProductsByPatientId(int patientId);
        FoodAllergiesAndIntolerances AddDislikedProduct(FoodAllergiesAndIntolerances foodAllergiesAndIntolerances);
        FoodAllergiesAndIntolerances UpdateDislikedProduct(FoodAllergiesAndIntolerances foodAllergiesAndIntolerances);
        void DeleteDislikedProduct(int foodAllergiesAndIntolerancesId);
    }
}
