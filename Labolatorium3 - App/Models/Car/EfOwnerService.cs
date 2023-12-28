using Data;
using SQLitePCL;

namespace Labolatorium3___App.Models
{
    public class EfOwnerService : IOwnerService
    {
        private readonly AppDbContext _context;
        public EfOwnerService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Owner Owner)
        {
            var e = _context.Owners.Add(OwnerMapper.ToEntity(Owner));
            _context.SaveChanges();
 
            return e.Entity.Id;
        }

        public void DeleteById(int id)
        {
            var find = _context.Owners.Find(id);
            if (find is not null)
            {
                _context.Owners.Remove(find);
                _context.SaveChanges();
            }
        }

        public List<Owner> FindAll()
        {
            return _context.Owners.Select(e => OwnerMapper.FromEntity(e)).ToList();
        }

        public Owner? FindById(int id)
        {
            var find = _context.Owners.Find(id);
            return find is null ? null : OwnerMapper.FromEntity(find);
        }

        public void Update(Owner Owner)
        {
            var entity = OwnerMapper.ToEntity(Owner);
            _context.Update(entity);
            _context.SaveChanges();
        }
        public PagingList<Owner> FindPage(int page, int size)
        {
            return PagingList<Owner>.Create(
                    (p, s) => _context.Owners
                    .OrderBy(c => c.Name)
                    .Skip((p - 1) * s)
                    .Take(s)
                    .Select(OwnerMapper.FromEntity)
                    .ToList()
                    , page, size, _context.Owners.Count()
                );
        }

    }
}
