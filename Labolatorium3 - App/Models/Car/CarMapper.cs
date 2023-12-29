using Data.Entities;

namespace Labolatorium3___App.Models
{
    public class CarMapper
    {
        public static Car FromEntity(CarEntity entity)
        {
            return new Car()
            {
                Id = entity.Id,
                Maker = entity.Maker,
                MakerId = entity.MakerId,
                Name = entity.Name,
                Volume = entity.Volume,
                Power = entity.Power,
                EngineType = (EngineType)entity.EngineType,
                Registration = entity.Registration,
                OwnerId = entity.OwnerId,
                Owner = OwnerMapper.FromEntity(entity.Owner)
            };
        }

        public static CarEntity ToEntity(Car model)
        {
            return new CarEntity()
            {
                Id = model.Id,
                Maker = model.Maker,
                MakerId = model.MakerId,
                Name = model.Name,
                Volume = model.Volume,
                Power = model.Power,
                EngineType = (int)model.EngineType,
                Registration = model.Registration,
                OwnerId = model.OwnerId,
                Owner = OwnerMapper.ToEntity(model.Owner)
            };
        }
    }
}
