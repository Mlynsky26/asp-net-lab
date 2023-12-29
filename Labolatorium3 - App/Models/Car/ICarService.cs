using Data.Entities;

namespace Labolatorium3___App.Models
{
    public interface ICarService
    {
        int Add(Car contact);
        Car? FindById(int id);
        List<Car> FindAll();
        List<Car> FindByOwnerId(int id);
        void DeleteById(int id);
        void Update(Car contact);
        PagingList<Car> FindPage(int page, int size, int maker);
        List<MakerEntity> GetMakers();
    }
}
