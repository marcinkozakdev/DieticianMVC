using DieticianMVC.Domain.Model;

namespace DieticianMVC.Domain.Interfaces
{
    public interface IDislikedProductRepository
    {
        IQueryable<DislikedProduct> GetDislikedProductsByPatientId(int patientId);
        DislikedProduct AddDislikedProduct(DislikedProduct dislikedProduct);
        DislikedProduct UpdateDislikedProduct(DislikedProduct dislikedProduct);
        void DeleteDislikedProduct(int dislikedProductId);
    }
}
