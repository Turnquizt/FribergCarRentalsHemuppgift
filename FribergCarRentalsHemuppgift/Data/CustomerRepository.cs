using FribergCarRentalsHemuppgift.Models;

namespace FribergCarRentalsHemuppgift.Data
{
    public class CustomerRepository : ICustomer
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CustomerRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void Add(Customer customer)
        {
            applicationDbContext.Customers.Add(customer);
            applicationDbContext.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            applicationDbContext.Remove(customer);
            applicationDbContext.SaveChanges();
        }

        public IEnumerable<Customer> GetAll()
        {
            return applicationDbContext.Customers.OrderBy(s => s.FirstName);
        }

        public Customer GetById(int id)
        {
            return applicationDbContext.Customers.FirstOrDefault(s => s.Id == id);
        }

        public void Update(Customer customer)
        {
            applicationDbContext.Customers.Update(customer);
            applicationDbContext.SaveChanges();
        }
        public bool Any (int id)
        {
            return applicationDbContext.Customers.Any(s => s.Id == id);
        }
        public Customer GetCustomerByEmailAndPassword (string email, string password) 
        { 
            return applicationDbContext.Customers.FirstOrDefault(c => c.Email == email && c.Password == password);
        }
    }
}
