using DieticianMVC.Domain.Model;

namespace DieticianMVC.Domain.Interfaces
{
    public interface IHomeMeasureRepository
    {
        IEnumerable<HomeMeasure> GetAllHomeMeasure();
        HomeMeasure AddHomeMeasure(HomeMeasure homeMeasure);
        HomeMeasure UpdateHomeMeasure(HomeMeasure homeMeasure);
        void DeleteHomeMeasure(int homeMeasureId);
    }
}
