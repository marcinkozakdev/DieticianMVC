using DieticianMVC.Domain.Model;

namespace DieticianMVC.Domain.Interfaces
{
    public interface IFoodPreferencesRepository
    {
        IQueryable<FoodPreferences> GetFoodPreferencesByPatientId(int patientId);
        FoodPreferences AddFoodPreferences(FoodPreferences foodPreferences);
        FoodPreferences UpdateFoodPreferences(FoodPreferences foodPreferences);
        void DeleteFoodPreferences(int foodPreferencesId);
    }
}
