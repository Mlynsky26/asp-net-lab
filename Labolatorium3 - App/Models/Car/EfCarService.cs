using Data;
using SQLitePCL;

namespace Labolatorium3___App.Models
{
    public class EfCarService : ICarService
    {
        private readonly CarsDbContext _context;
        public EfCarService(CarsDbContext context)
        {
            _context = context;
        }

        public int Add(Car car)
        {
            var e = _context.Cars.Add(CarMapper.ToEntity(car));
            _context.SaveChanges();
 
            return e.Entity.Id;
        }

        public void DeleteById(int id)
        {
            var find = _context.Cars.Find(id);
            if (find is not null)
            {
                _context.Cars.Remove(find);
                _context.SaveChanges();
            }
        }

        public List<Car> FindAll()
        {
            return _context.Cars.Select(e => CarMapper.FromEntity(e)).ToList();
        }

        public Car? FindById(int id)
        {
            var find = _context.Cars.Find(id);
            return find is null ? null : CarMapper.FromEntity(find);
        }

        public void Update(Car car)
        {
            var entity = CarMapper.ToEntity(car);
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
