using SEDC.BurgerApp.DAL.Database;
using SEDC.BurgerApp.DAL.Models;

namespace SEDC.BurgerApp.DAL.Repositories
{
    public class LocationRepository : IRepository<Location>
    {
        private readonly BurgerAppDbContext _dbContext;

        public LocationRepository(BurgerAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(Location entity)
        {
            _dbContext.Locations.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Location> GetAll()
        {
            return _dbContext.Locations;
        }

        public Location? GetById(int id)
        {
            return _dbContext.Locations.SingleOrDefault(x => x.Id == id);  
        }

        public void Save(Location entity)
        {
           _dbContext.Locations.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Location entity)
        {
            _dbContext.Locations.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
