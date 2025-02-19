using FribergCarRentalsHemuppgift.Models;

namespace FribergCarRentalsHemuppgift.Data
{
    public interface ICustomer
    {
        Customer GetById (int id);
        IEnumerable<Customer> GetAll ();
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
        bool Any(int id);
        Customer GetCustomerByEmailAndPassword(string email, string password);
    }
}
