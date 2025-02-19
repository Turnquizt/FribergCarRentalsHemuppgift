using FribergCarRentalsHemuppgift.Models;

namespace FribergCarRentalsHemuppgift.Data
{
    public class CarRepository : ICar
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CarRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void Add(Car car)
        {
            applicationDbContext.Cars.Add(car);
            applicationDbContext.SaveChanges();
        }

        public void Delete(Car car)
        {
            applicationDbContext.Cars.Remove(car);
            applicationDbContext.SaveChanges();
        }

        public IEnumerable<Car> GetAll()
        {
            return applicationDbContext.Cars.OrderBy(s => s.Brand);
        }

        public Car GetById(int id)
        {
            return applicationDbContext.Cars.FirstOrDefault(s => s.Id == id);
        }

        public void Update(Car car)
        {
            applicationDbContext.Cars.Update(car);
            applicationDbContext.SaveChanges();
        }
        public bool Any(int id) 
        { 
            return applicationDbContext.Cars.Any(s => s.Id == id);
        }
    }
}
