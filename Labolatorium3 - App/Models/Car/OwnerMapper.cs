using Data.Entities;
using Data.Models;

namespace Labolatorium3___App.Models
{
    public class OwnerMapper
    {
        public static Owner? FromEntity(OwnerEntity entity)
        {
            if(entity is null) return null;
            return new Owner()
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
                Phone = entity.Phone,
                Address = new AddressModel() { City = entity?.Address?.City, Street = entity?.Address?.Street, PostalCode = entity?.Address.PostalCode }
            };
        }

        public static OwnerEntity? ToEntity(Owner model)
        {
            if (model is null) return null;
            return new OwnerEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Phone = model.Phone,
                Address = new Address() { City = model?.Address?.City, Street = model?.Address?.Street, PostalCode = model?.Address.PostalCode }
            };
        }
    }
}
