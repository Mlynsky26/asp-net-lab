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
                Name = entity.Name,
                Volume = entity.Volume,
                Power = entity.Power,
                EngineType = EngineType.Gas,
                Registration = entity.Registration,
                Owner = "",
            };
        }

        public static CarEntity ToEntity(Car model)
        {
            return new CarEntity()
            {
                Id = model.Id,
                Maker = model.Maker,
                Name = model.Name,
                Volume = model.Volume,
                Power = model.Power,
                EngineType = "Gas",
                Registration = model.Registration,
                Owner = "",
            };
        }
    }
}
