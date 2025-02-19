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
    public class CarController : Controller
    {
        private readonly ICar _carRepository;

        public CarController(ICar carRepository)
        {
            _carRepository = carRepository;
        }

        // GET: Admin/Car
        public IActionResult Index()
        {
            return View(_carRepository.GetAll());
        }

        // GET: Admin/Car/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // GET: Car with Id
            var car = _carRepository.GetById(id.Value);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Admin/Car/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Car/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Brand,Model,ProductionYear,Milage,Horsepower,ImgUrl")] Car car)
        {
            if (ModelState.IsValid)
            {
                _carRepository.Add(car);
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Admin/Car/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _carRepository.GetById(id.Value);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Admin/Car/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Brand,Model,ProductionYear,Milage,Horsepower,ImgUrl")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _carRepository.Update(car);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
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
            return View(car);
        }

        // GET: Admin/Car/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _carRepository.GetById(id.Value);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Admin/Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var car = _carRepository.GetById(id);
            if (car != null)
            {
                _carRepository.Delete(car);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _carRepository.Any(id);
        }
    }
}
