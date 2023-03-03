using DieticianMVC.Domain.Model;

namespace DieticianMVC.Domain.Interfaces
{
    public interface ILikedProductRepository
    {
        IQueryable<LikedProduct> GetLikedProductsByPatientId(int patientId);
        LikedProduct AddLikedProduct(LikedProduct likedProduct);
        LikedProduct UpdateLikedProduct(LikedProduct likedProduct);
        void DeleteLikedProduct(int likedProductId);
    }
}
