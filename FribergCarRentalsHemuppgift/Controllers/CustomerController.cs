using FribergCarRentalsHemuppgift.Data;
using FribergCarRentalsHemuppgift.Models;
using FribergCarRentalsHemuppgift.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FribergCarRentalsHemuppgift.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomer _customerRepository;

        public CustomerController(ICustomer customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //GET: CustomerController/Login
        public ActionResult Login() 
        {
            return View();
        }

        //POST: CustomerController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login (LoginViewModel viewModel) 
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
                var customer = _customerRepository.GetCustomerByEmailAndPassword(viewModel.Email, viewModel.Password);
            
            if (customer == null) 
            {
                ModelState.AddModelError("", "Ogilitigt Epostadress eller Lösenord");
                return View(viewModel);
            }
            
            HttpContext.Session.SetString(key: "userId", value: $"{customer.Id}");
            
            return RedirectToAction("Index","BookingOrder");
        }

        //GET: CustomerController/Logout
        public ActionResult Logout() 
        { 
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        //GET: CustomerController/Register
        public ActionResult Register() 
        {
            return View();
        }

        //POST: CustomerController/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer 
                { 
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    Email = registerViewModel.Email,
                    Password = registerViewModel.Password,
                };
                
                _customerRepository.Add(customer);
                return RedirectToAction("Index","Home");
            }
            return View(registerViewModel);
        }

        // GET: Customer/LoginAndRegister
        public ActionResult LoginAndRegister() 
        {
            return View();
        }
    }
}
