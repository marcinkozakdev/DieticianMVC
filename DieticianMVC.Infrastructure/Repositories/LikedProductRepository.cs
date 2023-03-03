using DieticianMVC.Domain.Interfaces;
using DieticianMVC.Domain.Model;

namespace DieticianMVC.Infrastructure.Repositories
{
    public class LikedProductRepository : ILikedProductRepository
    {

        private readonly Context _context;
        public LikedProductRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<LikedProduct> GetLikedProductsByPatientId(int patientId)
        {
            var dislikedProducts = _context.LikedProducts.Where(i => i.Id == patientId);
            return dislikedProducts;
        }

        public LikedProduct AddLikedProduct(LikedProduct likedProduct)
        {
            _context.LikedProducts.Add(likedProduct);
            _context.SaveChanges();
            return likedProduct;
        }

        public LikedProduct UpdateLikedProduct(LikedProduct likedProduct)
        {
            if (likedProduct != null)
                _context.LikedProducts.Update(likedProduct);
            _context.SaveChanges();
            return likedProduct;
        }

        public void DeleteLikedProduct(int likedProductId)
        {
            var likedProduct = _context.LikedProducts.FirstOrDefault(d => d.Id == likedProductId);
            if (likedProduct != null)
            {
                _context.LikedProducts.Remove(likedProduct);
                _context.SaveChanges();
            }
        }
    }
}
