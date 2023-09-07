using System.ComponentModel.DataAnnotations.Schema;

namespace SEDC.BurgerApp.DAL.Models
{
    public class OrderedBurger : BaseEntity
    {
        public OrderedBurger() { }

        public int OrderId { get; set; }
        public int BurgerId { get; set; }


        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }

        [ForeignKey(nameof(BurgerId))]
        public Burger Burger { get; set; }
    }
}
