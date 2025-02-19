using FribergCarRentalsHemuppgift.Data;
using FribergCarRentalsHemuppgift.Models;
using FribergCarRentalsHemuppgift.Areas.Admin.Models;

namespace FribergCarRentalsHemuppgift.Areas.Admin.Data
{
    public class AdminRepository : IAdmin
    {
        private readonly ApplicationDbContext applicationDbContext;

        public AdminRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public IEnumerable<AdminModel> GetAll()
        {
            return applicationDbContext.Admins.OrderBy(s => s.AdminUserName);
        }

        public AdminModel GetById(int id)
        {
            return applicationDbContext.Admins.FirstOrDefault(s => s.Id == id);
        }
        public AdminModel GetByAdminUsernameAndPassword(string name, string password)
        {
            return applicationDbContext.Admins.FirstOrDefault(s => s.AdminUserName == name && s.AdminPassword == password);
        }
    }
}
