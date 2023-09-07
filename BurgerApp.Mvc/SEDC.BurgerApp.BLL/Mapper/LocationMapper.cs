using SEDC.BurgerApp.BLL.DTOs.Burgers;
using SEDC.BurgerApp.BLL.DTOs.Locations;
using SEDC.BurgerApp.BLL.DTOs.Orders;
using SEDC.BurgerApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.BurgerApp.BLL.Mapper
{
    public static class LocationMapper
    {
        public static LocationDTO ToDTO(this Location location)
        {
            return new LocationDTO
            {
                Id = location.Id,
                Name = location.Name,
                Address = location.Address,
                OpensAt = location.OpensAt,
                ClosesAt = location.ClosesAt,
            };
        }

        public static LocationDetailsDTO ToDetailsDTO(this Location location)
        {
            return new LocationDetailsDTO
            {
                Id = location.Id,
                Name = location.Name,
                Address = location.Address,
                OpensAt = location.OpensAt,
                ClosesAt = location.ClosesAt,
            };
        }
    }
}
