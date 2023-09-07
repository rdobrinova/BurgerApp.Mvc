using SEDC.BurgerApp.BLL.DTOs.Burgers;
using SEDC.BurgerApp.BLL.DTOs.Locations;
using SEDC.BurgerApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.BurgerApp.BLL.Mapper
{
    public static class BurgerMapper
    {
        public static BurgerDTO ToDTO(this Burger burger)
        {
            return new BurgerDTO
            {
                Id = burger.Id,
                Name = burger.Name,
                Price = burger.Price,
                IsVegetarian = burger.IsVegetarian,
                IsVegan = burger.IsVegan,
                HasFries = burger.HasFries,
            };
        }

        public static BurgerDetailsDTO ToDetailsDTO(this Burger burger)
        {
            return new BurgerDetailsDTO
            {
                Id = burger.Id,
                Name = burger.Name,
                Price = burger.Price,
                IsVegetarian = burger.IsVegetarian,
                IsVegan = burger.IsVegan,
                HasFries = burger.HasFries,
            };
        }
    }
}
