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
    public class CustomerController : Controller
    {
        private readonly ICustomer _customerRepository;

        public CustomerController(ICustomer customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: Admin/Customer
        public IActionResult Index()
        {
            return View(_customerRepository.GetAll());
        }

        // GET: Admin/Customer/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
        // GET: Customer By Id
            var customer = _customerRepository.GetById(id.Value);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Admin/Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,FirstName,LastName,Email,Password")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerRepository.Add(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Admin/Customer/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customerRepository.GetById(id.Value);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Admin/Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,FirstName,LastName,Email,Password")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _customerRepository.Update(customer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Admin/Customer/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customerRepository.GetById(id.Value);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Admin/Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer != null)
            {
                _customerRepository.Delete(customer);
            }

            
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _customerRepository.Any(id);
        }
    }
}
