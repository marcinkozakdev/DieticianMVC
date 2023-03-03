using DieticianMVC.Domain.Interfaces;
using DieticianMVC.Domain.Model;

namespace DieticianMVC.Infrastructure.Repositories
{
    public class DislikedProductRepository : IDislikedProductRepository
    {

        private readonly Context _context;
        public DislikedProductRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<DislikedProduct> GetDislikedProductsByPatientId(int patientId)
        {
            var dislikedProducts = _context.DislikedProducts.Where(i => i.Id == patientId);
            return dislikedProducts;
        }

        public DislikedProduct AddDislikedProduct(DislikedProduct dislikedProduct)
        {
            _context.DislikedProducts.Add(dislikedProduct);
            _context.SaveChanges();
            return dislikedProduct;
        }

        public DislikedProduct UpdateDislikedProduct(DislikedProduct dislikedProduct)
        {
            if (dislikedProduct != null)
                _context.DislikedProducts.Update(dislikedProduct);
            _context.SaveChanges();
            return dislikedProduct;
        }

        public void DeleteDislikedProduct(int dislikedProductId)
        {
            var dislikedProduct = _context.DislikedProducts.FirstOrDefault(d => d.Id == dislikedProductId);
            if (dislikedProduct != null)
            {
                _context.DislikedProducts.Remove(dislikedProduct);
                _context.SaveChanges();
            }
        }
    }
}
