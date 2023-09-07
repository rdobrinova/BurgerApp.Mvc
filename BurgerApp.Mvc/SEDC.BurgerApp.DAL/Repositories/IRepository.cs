using SEDC.BurgerApp.DAL.Models;

namespace SEDC.BurgerApp.DAL.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        public IEnumerable<T> GetAll();

        public T? GetById(int id);

        public void Save(T entity);

        public void Update(T entity);

        public void Delete(T entity);
    }
}
