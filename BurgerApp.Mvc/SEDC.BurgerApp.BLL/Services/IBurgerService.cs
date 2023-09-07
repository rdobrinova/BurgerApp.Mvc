using SEDC.BurgerApp.BLL.DTOs.Burgers;
using SEDC.BurgerApp.DAL.Models;

namespace SEDC.BurgerApp.BLL.Services
{
    public interface IBurgerService
    {
        public IEnumerable<BurgerDTO> GetAll();

        public BurgerDetailsDTO GetById(int id);

        public BurgerDTO Update(BurgerDTO burgerDTO);

        public void Create(CreateBurgerDTO create);

        public void Delete(int id);
    }
}
