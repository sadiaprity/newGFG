﻿using evaluation2.Data;
using evaluation2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace evaluation2.Controllers
{
    public class VolunteerController : Controller
    {
        private readonly MyDbContext _context;


        public VolunteerController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string name, string password)
        {
            var v = _context.Volunteer.FirstOrDefault(u => (u.Email == name || u.Username == name) && u.Password == password);
            if (v != null)
            {
                HttpContext.Session.SetInt32("UserId", v.Id);
                HttpContext.Session.SetString("Username", v.Username);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Incorrect email or password!";
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup
            (Volunteer model)
        {
            if (_context.Users.Any(u => u.Email == model.Email))
            {
                ViewBag.Error = "Volunteer already exists!";
                return View();
            }
            if (model.Password != model.ConfirmPassword)
            {
                ViewBag.Error = "Passwords do not match!";
                return View();
            }
            _context.Volunteer.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Login");
        }
    }
}
