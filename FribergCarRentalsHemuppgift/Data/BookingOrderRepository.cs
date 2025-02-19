using FribergCarRentalsHemuppgift.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergCarRentalsHemuppgift.Data
{
    public class BookingOrderRepository : IBookingOrder
    {
        private readonly ApplicationDbContext applicationDbContext;

        public BookingOrderRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public void Add(BookingOrder bookingOrder) 
        { 
            applicationDbContext.BookingOrders.Add(bookingOrder);
            applicationDbContext.SaveChanges();
        }

        public void Delete(BookingOrder bookingOrder)
        {
            applicationDbContext.BookingOrders.Remove(bookingOrder);
            applicationDbContext.SaveChanges();

        }

        public IEnumerable<BookingOrder> GetAll()
        {
            return applicationDbContext.BookingOrders.OrderBy(s => s.Id);
        }

        public BookingOrder GetById(int id)
        {
            return applicationDbContext.BookingOrders.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<BookingOrder> GetAllByCustomer(int id)
        { 
            return applicationDbContext.BookingOrders.Where(s => s.CustomerId == id).ToList();
        }
        public IEnumerable<BookingOrder> GetAllByCustomerWithCarAndCustomer(int id)
        {
            return applicationDbContext.BookingOrders.Where(s => s.CustomerId == id)
                .Include(b => b.Car)
                .Include(b => b.Customer).ToList();
        }

        public IEnumerable<BookingOrder> GetAllWithCarAndCustomer()
        {
            return applicationDbContext.BookingOrders
                .Include(b => b.Car)
                .Include(b => b.Customer).ToList();
        }
        public BookingOrder GetBookingOrderWithCarAndCustomer(int id) 
        {
            var bookingOrder = applicationDbContext.BookingOrders
                .Include(b => b.Car)
                .Include(b => b.Customer)
                .FirstOrDefault(m => m.Id == id);

            return bookingOrder;
        }
    }
}
