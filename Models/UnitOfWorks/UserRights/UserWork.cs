namespace UserRegistration_HW6.Models.UnitOfWorks.UserRights
{
    public class UserWork : IDisposable
    {
        LocalHostContext userContext;
        private UserRepo userRepo;

        public UserRepo UserRepo
        {
            get
            {
                if (userRepo == null)
                    userRepo = new UserRepo(userContext);
                return userRepo;
            }
        }
        public UserWork()
        {
            userContext = new LocalHostContext();
        }
        public void Dispose() => GC.SuppressFinalize(this);
        
    }
}
