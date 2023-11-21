using System.Numerics;
using System.Xml.Linq;

namespace Labolatorium3___App.Models
{
    public class MemoryCarService : ICarService
    {
        private Dictionary<int, Car> _cars = new Dictionary<int, Car>();
        private int id = 1;

        public MemoryCarService()
        {
            Car car = new Car() { Id = id, Maker = "Opel", Name = "Astra", Volume = 1900, Power = 130, EngineType = EngineType.Diesel, Registration = "KRA 12DSC", Owner = "Marek" };
            Add(car);
        }

        public int Add(Car car)
        {
            car.Id = id++;
            _cars.Add(car.Id, car);
            return car.Id;
        }

        public void DeleteById(int id)
        {
            _cars.Remove(id);
        }

        public List<Car> FindAll()
        {
            return _cars.Values.ToList();
        }

        public Car? FindById(int id)
        {
            return _cars[id];
        }

        public void Update(Car car)
        {
            if (_cars.ContainsKey(car.Id))
            {
                _cars[car.Id] = car;
            }
        }
    }
}
