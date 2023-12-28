using Data;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Labolatorium3___App.Models
{
    public class EfCarService : ICarService
    {
        private readonly AppDbContext _context;
        public EfCarService(AppDbContext context)
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
            return _context.Cars.Include(x => x.Owner).Select(e => CarMapper.FromEntity(e)).ToList();
        }

        public Car? FindById(int id)
        {
            var find = _context.Cars.Include(x => x.Owner).Single(x => x.Id == id);
            Console.WriteLine(find.ToString());
            return find is null ? null : CarMapper.FromEntity(find);
        }
        public List<Car> FindByOwnerId(int id)
        {
            return _context.Cars.Include(x => x.Owner).Where(x => x.OwnerId == id).Select(e => CarMapper.FromEntity(e)).ToList();
        }

        public void Update(Car car)
        {
            var entity = CarMapper.ToEntity(car);
            _context.Update(entity);
            _context.SaveChanges();
        }

        public PagingList<Car> FindPage(int page, int size)
        {
            return PagingList<Car>.Create(
                    (p, s) => _context.Cars
                    .OrderBy(c => c.Name)
                    .Skip((p - 1) * s)
                    .Take(s)
                    .Select(CarMapper.FromEntity)
                    .ToList()
                    , page, size, _context.Cars.Count()
                );
        }
    }
}
