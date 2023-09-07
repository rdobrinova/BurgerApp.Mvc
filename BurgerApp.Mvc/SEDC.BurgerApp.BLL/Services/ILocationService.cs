using SEDC.BurgerApp.BLL.DTOs.Locations;

namespace SEDC.BurgerApp.BLL.Services
{
    public interface ILocationService
    {
        public IEnumerable<LocationDTO> GetAll();

        public LocationDetailsDTO GetById(int id);

        public LocationDTO Update(LocationDTO locationDTO);

        public void Create(CreateLocationDTO create);

        public void Delete(int id);
    }
}
