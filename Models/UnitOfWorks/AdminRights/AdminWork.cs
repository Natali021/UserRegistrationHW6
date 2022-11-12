using UserRegistration_HW6.Models.UnitOfWorks.UserRights;

namespace UserRegistration_HW6.Models.UnitOfWorks.AdminRights
{
    public class AdminWork : IDisposable
    {
        LocalHostContext userContext;
        private AdminRepo adminRepo;

        public AdminRepo AdminRepo
        {
            get
            {
                if (adminRepo == null)
                    adminRepo = new AdminRepo(userContext);
                return adminRepo;
            }
        }
        public AdminWork()
        {
            userContext = new LocalHostContext();
        }
        public void Dispose() => GC.SuppressFinalize(this);
    }
}
