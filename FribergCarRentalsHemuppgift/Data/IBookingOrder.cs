using FribergCarRentalsHemuppgift.Models;

namespace FribergCarRentalsHemuppgift.Data
{
    public interface IBookingOrder
    {
        BookingOrder GetById (int id);
        IEnumerable<BookingOrder> GetAll ();
        void Add(BookingOrder bookingOrder);
        void Delete(BookingOrder bookingOrder);
        IEnumerable<BookingOrder> GetAllByCustomer(int id);
        IEnumerable<BookingOrder> GetAllByCustomerWithCarAndCustomer(int id);
        IEnumerable<BookingOrder> GetAllWithCarAndCustomer();
        BookingOrder GetBookingOrderWithCarAndCustomer(int id);

    }
}
