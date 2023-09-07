using SEDC.BurgerApp.BLL.DTOs.Burgers;
using SEDC.BurgerApp.BLL.DTOs.Orders;
using SEDC.BurgerApp.BLL.Mapper;
using SEDC.BurgerApp.DAL.Models;
using SEDC.BurgerApp.DAL.Repositories;

namespace SEDC.BurgerApp.BLL.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> repository;

        public OrderService(IRepository<Order> repository)
        {
            this.repository = repository;
        }


        public void Create(CreateOrderDTO create)
        {

            if (create.OrderedBurgerId == 0)
                throw new Exception("Invalid burger!");

            var order = new Order(create.FullName, create.Address, create.IsDelivered)
            {
                Id = create.OrderId,
            };

            order.OrderedBurgers.Add(new OrderedBurger()
            {
                BurgerId = create.OrderedBurgerId,
                OrderId = order.Id,
            });

            repository.Save(order);
        }

        public void Delete(int id)
        {
            var order = repository.GetById(id);
            if (order == null)
            {
                throw new Exception();
            }
            repository.Delete(order);
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            IEnumerable<Order> orders = repository.GetAll();

            return orders.Select(x => x.ToDTO());
        }

        public OrderDetailsDTO GetById(int id)
        {
            var order = repository.GetById(id);
            if (order == null)
            {
                throw new Exception();
            }
            return order.ToDetailsDTO();
        }

        public void Update(OrderDTO orderDTO)
        {
            Order? order = repository.GetById(orderDTO.Id);

            if (order == null)
                throw new Exception("Order does not exist!");

            order.Address = orderDTO.Address;
            order.IsDelivered = orderDTO.IsDelivered;
            order.FullName = orderDTO.FullName;

            repository.Update(order);
        }
    }
}
