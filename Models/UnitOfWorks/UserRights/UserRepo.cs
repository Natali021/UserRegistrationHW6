using System.Linq;

namespace UserRegistration_HW6.Models.UnitOfWorks.UserRights
{
    public class UserRepo : IUserRepo<User>
    {
        private LocalHostContext context;

        public UserRepo(LocalHostContext context)
        {
            this.context = context;
        }

        public bool Add(User entity)
        {
            context.Add(entity);
            context.SaveChanges();
            return true;
        }

        public User Get(int id) => context.Users.Find(id);

        public IEnumerable<User> GetAll() => context.Users;

        public IEnumerable<string> GetAllLogin()
        {
            IEnumerable<string> users = new List<string>();
            users = context.Users.Select(u => u.UserLogin);
            
            return users;
        }

        public bool UpdatePassword(User entity)
        {
            context.Update(entity);
            context.SaveChanges();
            return true;
        }

    }
}
