namespace Labolatorium3___App.Models
{
    public interface IOwnerService
    {
        int Add(Owner contact);
        Owner? FindById(int id);
        List<Owner> FindAll();
        void DeleteById(int id);
        void Update(Owner owner);
        PagingList<Owner> FindPage(int page, int size);
    }
}
