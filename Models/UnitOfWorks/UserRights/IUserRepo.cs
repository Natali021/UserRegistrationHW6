
namespace UserRegistration_HW6.Models.UnitOfWorks.UserRights
{
    public interface IUserRepo<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        
        bool Add(T entity);
    }
}
