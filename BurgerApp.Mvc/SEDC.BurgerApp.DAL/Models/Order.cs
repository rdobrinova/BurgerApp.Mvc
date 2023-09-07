using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.BurgerApp.DAL.Models
{
    public class Order : BaseEntity
    {
        public Order() { }
        public Order(string fullName, string address, bool isDelivered)
        {
            FullName = fullName;
            Address = address;
            IsDelivered = isDelivered;
            OrderedBurgers = new List<OrderedBurger>();
        }

        public string FullName { get; set; }
        public string Address { get; set; }
        public bool IsDelivered { get; set; }
        public ICollection<OrderedBurger> OrderedBurgers { get; set; }
    }
}
