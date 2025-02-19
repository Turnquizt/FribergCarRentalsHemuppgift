using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FribergCarRentalsHemuppgift.Data;
using FribergCarRentalsHemuppgift.Models;
using FribergCarRentalsHemuppgift.Areas.Admin.Filters;

namespace FribergCarRentalsHemuppgift.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminLoginAuthorization]
    public class BookingOrderController : Controller
    {
        private readonly IBookingOrder _bookingOrderRepository;

        public BookingOrderController(IBookingOrder bookingOrderRepository)
        {
            _bookingOrderRepository = bookingOrderRepository;
        }

        // GET: Admin/BookingOrder
        public IActionResult Index()
        {
            return View(_bookingOrderRepository.GetAllWithCarAndCustomer());
        }

        // GET: Admin/BookingOrder/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingOrder = _bookingOrderRepository.GetBookingOrderWithCarAndCustomer(id.Value);
                
            if (bookingOrder == null)
            {
                return NotFound();
            }

            return View(bookingOrder);
        }

        // GET: Admin/BookingOrder/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingOrder = _bookingOrderRepository.GetBookingOrderWithCarAndCustomer(id.Value);
            
            if (bookingOrder == null)
            {
                return NotFound();
            }

            return View(bookingOrder);
        }

        // POST: Admin/BookingOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var bookingOrder = _bookingOrderRepository.GetById(id);
            if (bookingOrder != null)
            {
                _bookingOrderRepository.Delete(bookingOrder);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
