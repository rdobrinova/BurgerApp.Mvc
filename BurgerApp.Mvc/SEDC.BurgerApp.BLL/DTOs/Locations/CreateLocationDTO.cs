using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.BurgerApp.BLL.DTOs.Locations
{
    public class CreateLocationDTO
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime OpensAt { get; set; }
        public DateTime ClosesAt { get; set; }
    }
}
