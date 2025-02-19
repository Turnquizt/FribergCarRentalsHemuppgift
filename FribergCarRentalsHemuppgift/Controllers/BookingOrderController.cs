using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FribergCarRentalsHemuppgift.Data;
using FribergCarRentalsHemuppgift.Models;
using FribergCarRentalsHemuppgift.Filters;

namespace FribergCarRentalsHemuppgift.Controllers
{
    [LoginAuthorization]
    public class BookingOrderController : Controller
    {
        private readonly IBookingOrder _bookingOrderRepository;
        private readonly ICar _carRepository;

        public BookingOrderController(IBookingOrder bookingOrderRepository, ICar carRepository)
        {
            _bookingOrderRepository = bookingOrderRepository;
            _carRepository = carRepository;
        }

        // GET: BookingOrder
        public IActionResult Index()
        {
            string customerId = HttpContext.Session.GetString("userId");

            if (string.IsNullOrEmpty(customerId))
            {
                return NotFound();
            }

            try
            {
                int id = int.Parse(customerId);
                return View(_bookingOrderRepository.GetAllByCustomerWithCarAndCustomer(id));
            }
            catch (Exception ex) 
            {
                return NotFound();
            }
        }
        // GET: BookingOrder/Details
        public ActionResult Details(int id)
        {
            return View(_bookingOrderRepository.GetBookingOrderWithCarAndCustomer(id));
        }

        // GET: BookingOrder/Create
        public IActionResult Create(int carId)
        {
            string customerId = HttpContext.Session.GetString("userId");

            if (string.IsNullOrEmpty(customerId))
            {
                return NotFound();
            }

            try
            {
                int id = int.Parse(customerId);
                Car car = _carRepository.GetById(carId);
                var order = new BookingOrder
                {
                    Car = car,
                    CarId = carId,
                    CustomerId = id,
                    StartDate = DateOnly.FromDateTime(DateTime.Today),
                    EndDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1))
                };

                return View(order);
            }
            catch (Exception ex)
            {
                return NotFound();
            }

            
        }

        // POST: BookingOrder/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,CarId,CustomerId,StartDate,EndDate")] BookingOrder bookingOrder)
        {
            if (ModelState.IsValid)
            {
                //Model.BookingPrice = (Model.EndDate.DayNumber - Model.StartDate.DayNumber) * Model.Car.PricePerDay;
                var car = _carRepository.GetById(bookingOrder.CarId);
                bookingOrder.BookingPrice = (bookingOrder.EndDate.DayNumber - bookingOrder.StartDate.DayNumber) * car.PricePerDay;
                _bookingOrderRepository.Add(bookingOrder);
                
                return RedirectToAction(nameof(Details), new {id = bookingOrder.Id});
            }
            return View(bookingOrder);
        }

        // GET: BookingOrder/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingOrder = _bookingOrderRepository.GetById(id.Value);
            if (bookingOrder == null)
            {
                return NotFound();
            }
            if (bookingOrder.EndDate <= DateOnly.FromDateTime(DateTime.Today)) 
            {
                return RedirectToAction("Index");
            }

            return View(bookingOrder);
        }

        // POST: BookingOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var customerId = 1;
            
            var bookingOrder = _bookingOrderRepository.GetById(id);
            if (bookingOrder != null && bookingOrder.CustomerId == customerId)
            {
                _bookingOrderRepository.Delete(bookingOrder);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
