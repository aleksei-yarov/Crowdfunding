using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Crowdfunding.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Crowdfunding.Controllers
{
    public class AdminController : Controller
    {
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly UserManager<CustomUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminController(UserManager<CustomUser> manager, RoleManager<IdentityRole> roleManager, SignInManager<CustomUser> signInManager)
        {
            _userManager = manager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            
        }
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Index()
        {
            ViewBag.Admin = await _userManager.GetUsersInRoleAsync("Admin");            
            var Model = _userManager.Users.ToList(); 
            return View(Model);
        }


        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Block(string data)
        {            
            if (data != null)
            {
                var usersToBlock = data.Split("/");
                foreach (var userId in usersToBlock)
                {
                    var userBlock = await _userManager.FindByIdAsync(userId);
                    if (userBlock.UserName == User.Identity.Name)
                    {
                        await _signInManager.SignOutAsync();
                    }
                    await _userManager.SetLockoutEndDateAsync(userBlock, DateTimeOffset.MaxValue);
                }
            }            
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Unblock(string data)
        {
            if (data != null)
            {
                var usersToUnblock = data.Split("/");
                foreach (var userId in usersToUnblock)
                {
                    var userUnblock = await _userManager.FindByIdAsync(userId);                    
                    await _userManager.SetLockoutEndDateAsync(userUnblock, default);
                }
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string data)
        {
            if (data != null)
            {
                var usersToDelete = data.Split("/");
                foreach (var userId in usersToDelete)
                {
                    var userDelete = await _userManager.FindByIdAsync(userId);
                    if (User.Identity.Name == userDelete.UserName)
                    {
                        await _signInManager.SignOutAsync();
                    }
                    await _userManager.DeleteAsync(userDelete);
                }
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles="Admin")]
        public async Task<IActionResult> SetAdmin(string data)
        {
            if (data != null)
            {
                var users = data.Split("/");
                foreach (var userId in users)
                {
                    var userAdmin = await _userManager.FindByIdAsync(userId);
                    await _userManager.AddToRoleAsync(userAdmin, "admin");
                }
            }


            //await _roleManager.CreateAsync(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveAdmin(string data)
        {
            if (data != null)
            {
                var users = data.Split("/");
                foreach (var userId in users)
                {
                    var userAdmin = await _userManager.FindByIdAsync(userId);
                    if (User.Identity.Name == userAdmin.UserName)
                    {
                        await _signInManager.SignOutAsync();
                    }
                    await _userManager.RemoveFromRoleAsync(userAdmin, "admin");
                }
            }
            return RedirectToAction("Index");
        }
               
    }
}