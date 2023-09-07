using SEDC.BurgerApp.DAL.Database;
using SEDC.BurgerApp.DAL.Models;

namespace SEDC.BurgerApp.DAL.Repositories
{
    public class BurgerRepository : IRepository<Burger>
    {

        private readonly BurgerAppDbContext _dbContext;

        public BurgerRepository(BurgerAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Burger> GetAll()
        {
            return _dbContext.Burgers;
        }

        public Burger? GetById(int id)
        {
            return _dbContext.Burgers.FirstOrDefault(x => x.Id == id);
        }

        public void Save(Burger entity)
        {
            _dbContext.Burgers.Add(entity);
            _dbContext.SaveChanges();
        }
        public void Delete(Burger entity)
        {
            _dbContext.Burgers.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Burger entity)
        {
            _dbContext.Burgers.Update(entity);
            _dbContext.SaveChanges();
        }

    }
}
