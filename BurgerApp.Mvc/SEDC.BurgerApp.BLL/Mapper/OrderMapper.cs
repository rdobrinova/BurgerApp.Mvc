using SEDC.BurgerApp.BLL.DTOs.Burgers;
using SEDC.BurgerApp.BLL.DTOs.Orders;
using SEDC.BurgerApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.BurgerApp.BLL.Mapper
{
    public static class OrderMapper
    {
        public static OrderDTO ToDTO(this Order order)
        {
            var burger = order.OrderedBurgers.First();
            return new OrderDTO
            {
                Id = order.Id,
                FullName = order.FullName,
                Address = order.Address,
                IsDelivered = order.IsDelivered,
                Burger = new BurgerDTO()
                {
                    Id = burger.Burger.Id,
                    Name = burger.Burger.Name,
                    HasFries = burger.Burger.HasFries,
                    IsVegetarian = burger.Burger.IsVegetarian,
                    IsVegan = burger.Burger.IsVegan,
                    Price = burger.Burger.Price,
                }
            };
        }

        public static OrderDetailsDTO ToDetailsDTO(this Order order)
        {
            return new OrderDetailsDTO
            {
                Id = order.Id,
                FullName = order.FullName,
                Address = order.Address,
                IsDelivered = order.IsDelivered,
            };
        }

    }
}
