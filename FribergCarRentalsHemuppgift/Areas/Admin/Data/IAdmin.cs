using FribergCarRentalsHemuppgift.Areas.Admin.Models;
using FribergCarRentalsHemuppgift.Models;

namespace FribergCarRentalsHemuppgift.Areas.Admin.Data
{
    public interface IAdmin
    {
        AdminModel GetById(int id);
        IEnumerable<AdminModel> GetAll();
        AdminModel GetByAdminUsernameAndPassword(string username, string password);
    }
}
