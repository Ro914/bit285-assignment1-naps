using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bit285_assignment1_naps.Models;

namespace bit285_assignment1_naps.Controllers
{
    public class NapsController : Controller
    {
        private User account;

        public NapsController(User user)
        {
            account = user;
        }

        [HttpGet]
        public IActionResult AccountInfo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AccountInfo(User user)
        {
            if (ModelState.GetFieldValidationState("FirstName") == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid &&
                ModelState.GetFieldValidationState("LastName") == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid &&
                ModelState.GetFieldValidationState("EmailAddress") == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid &&
                ModelState.GetFieldValidationState("Program") == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid)
            {
                account.FirstName = user.FirstName;
                account.LastName = user.LastName;
                account.EmailAddress = user.EmailAddress;
                account.Program = user.Program;
                return RedirectToAction("PasswordInfo");
            }
            else
                return View();
        }

        [HttpGet]
        public IActionResult PasswordInfo()
        {
            return View(account);
        }

        [HttpPost]
        public IActionResult PasswordInfo(User user)
        {
            if (ModelState.GetFieldValidationState("LastName") == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid && 
                ModelState.GetFieldValidationState("BirthYear") == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid && 
                ModelState.GetFieldValidationState("FavoriteColor") == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid)
            {
                account.LastName = user.LastName;
                account.BirthYear = user.BirthYear;
                account.FavoriteColor = user.FavoriteColor;
                return RedirectToAction("SelectPassword", user);
            }
            else
                return View(user);
        }

        [HttpGet]
        public IActionResult SelectPassword()
        {
            return View(account);
        }

        [HttpPost]
        public IActionResult SelectPassword(User user)
        {
            account.Password = user.Password;
            return RedirectToAction("ConfirmAccount", user);
        }

        [HttpGet]
        public IActionResult ConfirmAccount()
        {
            return View(account);
        }

        [HttpPost]
        public IActionResult ConfirmAccount(User user)
        {
            return RedirectToAction("Login", user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(account);
        }
    }
}