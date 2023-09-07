using SEDC.BurgerApp.BLL.DTOs.Locations;
using SEDC.BurgerApp.BLL.Mapper;
using SEDC.BurgerApp.DAL.Models;
using SEDC.BurgerApp.DAL.Repositories;

namespace SEDC.BurgerApp.BLL.Services.Implementation
{
    public class LocationService : ILocationService
    {
        private readonly IRepository<Location> repository;


        public LocationService(IRepository<Location> repository)
        {
            this.repository = repository;
        }
        public void Create(CreateLocationDTO newLocation)
        {
            repository.Save(new Location(newLocation.Name, newLocation.Address, newLocation.OpensAt, newLocation.ClosesAt)
            {
            });
        }

        public void Delete(int id)
        {
            var location = repository.GetById(id);
            if (location == null)
            {
                throw new Exception();
            }
            repository.Delete(location);
        }

        public IEnumerable<LocationDTO> GetAll()
        {
            IEnumerable<Location> locations = repository.GetAll();
            return locations.Select(x => x.ToDTO());
        }

        public LocationDetailsDTO GetById(int id)
        {
            Location? location = repository.GetById(id);
            if (location == null)
            {
                throw new Exception("Location not found");
            }
            return location.ToDetailsDTO();
        }

        public LocationDTO Update(LocationDTO locationDTO)
        {
            var location = repository.GetById(locationDTO.Id);
            if (location == null)
            {
                throw new Exception("");
            }
            location.Name = locationDTO.Name;
            location.Address = locationDTO.Address;
            location.OpensAt = locationDTO.OpensAt; 
            location.ClosesAt = locationDTO.ClosesAt;

            repository.Update(location);
            return location.ToDTO();
        }
    }
}
