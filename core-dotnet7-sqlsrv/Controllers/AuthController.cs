using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core_dotnet7_sqlsrv.Data;
using core_dotnet7_sqlsrv.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace core_dotnet7_sqlsrv.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AuthController(ApplicationDbContext db) {
            _db = db;
        }
        // GET: /<controller>/
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var passwordHasher = new PasswordHasher<User>();
            user.Password = passwordHasher.HashPassword(user, user.Password);

            _db.Users.Add(user);
            _db.SaveChanges();

            return Content("Create Success");
        }
    }
}

