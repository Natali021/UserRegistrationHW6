using UserRegistration_HW6.Models.UnitOfWorks.UserRights;

namespace UserRegistration_HW6.Models.UnitOfWorks.AdminRights
{
    public class AdminRepo : IUserRepo<User>
    {
        private LocalHostContext context;

        public AdminRepo(LocalHostContext context)
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

        
    }
}
