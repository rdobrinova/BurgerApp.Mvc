using SEDC.BurgerApp.BLL.DTOs.Burgers;
using SEDC.BurgerApp.BLL.DTOs.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.BurgerApp.BLL.DTOs.Orders
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public bool IsDelivered { get; set; }
        public BurgerDTO Burger { get; set; } = new BurgerDTO();
    }
}
