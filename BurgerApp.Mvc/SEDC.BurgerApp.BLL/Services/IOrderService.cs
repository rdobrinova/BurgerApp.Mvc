using SEDC.BurgerApp.BLL.DTOs.Orders;

namespace SEDC.BurgerApp.BLL.Services
{
    public interface IOrderService
    {
        public IEnumerable<OrderDTO> GetAll();

        public OrderDetailsDTO GetById(int id);

        public void Update(OrderDTO orderDTO);

        public void Create(CreateOrderDTO create);

        public void Delete(int id);
    }
}
