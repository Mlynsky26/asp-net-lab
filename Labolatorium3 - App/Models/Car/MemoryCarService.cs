using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Xml.Linq;

namespace Labolatorium3___App.Models
{
    public class MemoryCarService : ICarService
    {
        private Dictionary<int, Car> _cars = new Dictionary<int, Car>();
        private Dictionary<int, MakerEntity> _makers = new Dictionary<int, MakerEntity>();
        private int id = 1;

        public MemoryCarService(){
            _makers.Add(1, new MakerEntity() { Id = 1, Name = "Seat" });
            _makers.Add(2, new MakerEntity() { Id = 2, Name = "Opel" });
            _makers.Add(3, new MakerEntity() { Id = 3, Name = "BMW" });
            _makers.Add(4, new MakerEntity() { Id = 4, Name = "Mazada" });
            _makers.Add(5, new MakerEntity() { Id = 5, Name = "Audi" });
            _makers.Add(6, new MakerEntity() { Id = 6, Name = "Ford" });
            _makers.Add(7, new MakerEntity() { Id = 7, Name = "VolksWagen" });
            _makers.Add(8, new MakerEntity() { Id = 8, Name = "Mercedes" });
            _makers.Add(9, new MakerEntity() { Id = 9, Name = "Ferrari" });
            _makers.Add(10, new MakerEntity() { Id = 10, Name = "Renault" });
        }

        public int Add(Car car)
        {
            car.Id = id;
            car.Maker = _makers.ContainsKey(id) ? _makers[id] : null;
            _cars.Add(car.Id, car);
            id++;
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
            return _cars.ContainsKey(id) ? _cars[id] : null;
        }

        public List<Car> FindByOwnerId(int id)
        {
            return _cars.Values.ToList().FindAll(c => c.OwnerId == id);
        }

        public void Update(Car car)
        {
            if (_cars.ContainsKey(car.Id))
            {
                car.Maker = _makers.ContainsKey(id) ? _makers[id] : null;
                _cars[car.Id] = car;
            }
        }

        public PagingList<Car> FindPage(int page, int size, int maker)
        {
            List<Car> c = _cars.Values.ToList();
            if (maker > 0)
            {
                c = c.FindAll(x => x.MakerId == maker);
            }

            return PagingList<Car>.Create(
                    (p, s) => c.Skip((p - 1) * s)
                                .Take(s)
                    , page, size, c.Count
                );
        }

        public List<MakerEntity> GetMakers()
        {
            return _makers.Values.ToList ();
        }
    }
}
