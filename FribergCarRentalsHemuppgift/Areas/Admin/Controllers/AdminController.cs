using Microsoft.AspNetCore.Mvc;
using FribergCarRentalsHemuppgift.Areas.Admin.Data;
using FribergCarRentalsHemuppgift.Areas.Admin.ViewModel;
using FribergCarRentalsHemuppgift.Areas.Admin.Filters;


namespace FribergCarRentalsHemuppgift.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class AdminController : Controller
    {
        private readonly IAdmin _adminRepository;

        public AdminController(IAdmin adminRepository) 
        {
            _adminRepository = adminRepository;
        }
        // GET: Admin/Admin

        [AdminLoginAuthorization]
        public IActionResult Index()
        {
            return View();
        }

        // GET: Admin/Login
        [Route("Admin/Login")]
        public ActionResult Login() 
        { 
            return View(); 
        }

        // POST: Admin/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Admin/Login")]
        public ActionResult Login(AdminLoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var admin = _adminRepository.GetByAdminUsernameAndPassword(viewModel.AdminUsername, viewModel.AdminPassword);

            if (admin == null)
            {
                ModelState.AddModelError("", "Ogilitigt Användarnamn eller Lösenord");
                return View(viewModel);
            }

            HttpContext.Session.SetString(key: "userId", value: $"{admin.Id}");
            HttpContext.Session.SetString(key: "isAdmin", value: "true");

            return RedirectToAction("Index", "Admin");
        }
    }
}
