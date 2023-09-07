using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.BurgerApp.BLL.DTOs.Burgers
{
    public class BurgerDetailsDTO
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }
        public bool HasFries { get; set; }
        public string Description { get; set; }
    }
}
