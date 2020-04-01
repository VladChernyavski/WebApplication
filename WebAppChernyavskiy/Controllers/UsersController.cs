﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppChernyavskiy.Models.Account;
using WebAppChernyavskiy.ViewModels.Roles;

namespace WebAppChernyavskiy.Controllers {
    public class UsersController : Controller{

        RoleManager<IdentityRole> _roleManager;
        UserManager<User> _userManager;
        public UsersController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager) {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult RolesList() => View(_roleManager.Roles.ToList());

        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(string name) {
            if (!string.IsNullOrEmpty(name)) {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded) {
                    return RedirectToAction("RolesList");
                }
                else {
                    foreach (var error in result.Errors) {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(name);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id) {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null) {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("RolesList");
        }

        public IActionResult UserList() => View(_userManager.Users.ToList());

        public async Task<IActionResult> Edit(string userId) {
            // получаем пользователя
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null) {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                ChangeRoleViewModel model = new ChangeRoleViewModel {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles) {
            // получаем пользователя
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null) {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                // получаем все роли
                var allRoles = _roleManager.Roles.ToList();
                // получаем список ролей, которые были добавлены
                var addedRoles = roles.Except(userRoles);
                // получаем роли, которые были удалены
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);

                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                return RedirectToAction("UserList");
            }

            return NotFound();
        }

        public async Task<ActionResult> LockOut(string userId) {
            User user = await _userManager.FindByIdAsync(userId);

            if (user != null) {
                user.LockoutEnabled = true;
                user.LockoutEnd = DateTime.Now.AddYears(100).Date;
                await _userManager.UpdateAsync(user);
            }

            return RedirectToAction("UserList");
        }

        public async Task<ActionResult> UnLock(string userId) {
            User user = await _userManager.FindByIdAsync(userId);

            if (user != null) {
                user.LockoutEnd = DateTime.Now;
                await _userManager.UpdateAsync(user);
            }

            return RedirectToAction("UserList");
        }

        [HttpPost]
        public async Task<ActionResult> DeleteUser(string userId) {
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null) {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("UserList");
        }

    }
}
