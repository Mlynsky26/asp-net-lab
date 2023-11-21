namespace Labolatorium3___App.Models
{
    public interface ICarService
    {
        int Add(Car contact);
        Car? FindById(int id);
        List<Car> FindAll();
        void DeleteById(int id);
        void Update(Car contact);
    }
}
