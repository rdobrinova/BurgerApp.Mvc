using SEDC.BurgerApp.BLL.DTOs.Burgers;
using SEDC.BurgerApp.BLL.Mapper;
using SEDC.BurgerApp.DAL.Models;
using SEDC.BurgerApp.DAL.Repositories;

namespace SEDC.BurgerApp.BLL.Services.Implementation
{
    public class BurgerService : IBurgerService
    {
        private readonly IRepository<Burger> repository;

        public BurgerService(IRepository<Burger> repository)
        {
            this.repository = repository;
        }

        public void Create(CreateBurgerDTO newBurger)
        {
            repository.Save(new Burger(newBurger.Name, newBurger.Price)
            {
                IsVegetarian = newBurger.IsVegetarian,
                IsVegan = newBurger.IsVegan,
                HasFries = newBurger.HasFries,
            });
        }

        public void Delete(int id)
        {
            var burger = repository.GetById(id);
            if (burger == null)
            {
                throw new Exception();
            }

            repository.Delete(burger);
        }

        public IEnumerable<BurgerDTO> GetAll()
        {
            IEnumerable<Burger> burgers = repository.GetAll();
            return burgers.Select(x => x.ToDTO());
        }

        public BurgerDetailsDTO GetById(int id)
        {
            Burger? burger = repository.GetById(id);

            if (burger == null)
            {
                throw new Exception("Burger not found");
            }
            return burger.ToDetailsDTO();
        }

        public BurgerDTO Update(BurgerDTO burgerDTO)
        {
            Burger? burger = repository.GetById(burgerDTO.Id);

            if (burger == null)
            {
                throw new Exception("");
            }
            burger.Name = burgerDTO.Name;
            burger.Price = burgerDTO.Price;
            burger.IsVegetarian = burgerDTO.IsVegetarian;
            burger.IsVegan = burgerDTO.IsVegan;
            burger.HasFries = burgerDTO.HasFries;

            repository.Update(burger);
            return burger.ToDTO();
        }

    }
}
