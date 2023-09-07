using Microsoft.EntityFrameworkCore;
using SEDC.BurgerApp.DAL.Database;
using SEDC.BurgerApp.DAL.Models;

namespace SEDC.BurgerApp.DAL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly BurgerAppDbContext _dbContext;

        public OrderRepository(BurgerAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(Order entity)
        {
            _dbContext.Orders.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            return _dbContext.Orders
                .Include(x => x.OrderedBurgers)
                .ThenInclude(x => x.Burger);
        }

        public Order? GetById(int id)
        {
            return _dbContext.Orders
                .Include(x => x.OrderedBurgers)
                .ThenInclude(x => x.Burger)
                .SingleOrDefault(x => x.Id == id);
        }

        public void Save(Order entity)
        {
            _dbContext.Orders.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Order entity)
        {
            _dbContext.Orders.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
