using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAppChernyavskiy.Models.Account;
using WebAppChernyavskiy.ViewModels.Account;
using WebAppChernyavskiy.ViewModels.Roles;

namespace WebAppChernyavskiy.Controllers {
    public class AccountController : Controller {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model) {
            if (ModelState.IsValid) {

                User user = new User { Email = model.Email, UserName = model.Email }; 
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded) {
                    await _signInManager.SignInAsync(user, false);
                    await _userManager.AddToRoleAsync(user, "user");
                    return RedirectToAction("Index", "Home");
                } else {
                    foreach (var error in result.Errors) {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = null) {
                LoginViewModel model = new LoginViewModel {
                    ReturnUrl = returnUrl,
                    ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
                };

                return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model) {
                if (ModelState.IsValid) {

                    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                    if (result.Succeeded) {
                        if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl)) {
                            return Redirect(model.ReturnUrl);
                        }
                        else {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else {
                        if (result.IsLockedOut) {
                            ModelState.AddModelError("", "Пользователь заблокирован");
                        }
                        else {
                            ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                        }
                    }
                }
                return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout() {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ExternalLogin(string provider, string returnUrl) {

                var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });
                var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

                return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null) {
                returnUrl = returnUrl ?? Url.Content("~/");

                LoginViewModel loginViewModel = new LoginViewModel {
                    ReturnUrl = returnUrl,
                    ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
                };

                if (remoteError != null) {
                    ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");

                    return View("Login", loginViewModel);
                }

                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null) {
                    ModelState.AddModelError(string.Empty, "Error loading external login information.");

                    return View("Login", loginViewModel);
                }

                var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider,
                    info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

                if (signInResult.IsLockedOut) {
                    ModelState.AddModelError("", "Пользователь заблокирован");
                    return View("Login", loginViewModel);
                }

                if (signInResult.Succeeded) {
                    return LocalRedirect(returnUrl);
                }
                else {
                    var email = info.Principal.FindFirstValue(ClaimTypes.Email);

                    if (email != null) {
                        var user = await _userManager.FindByEmailAsync(email);

                        if (user == null) {
                            user = new User {
                                UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                                Email = info.Principal.FindFirstValue(ClaimTypes.Email)
                            };

                            await _userManager.CreateAsync(user);
                        }
                        await _userManager.AddToRoleAsync(user, "user");
                        await _userManager.AddLoginAsync(user, info);
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        return LocalRedirect(returnUrl);
                    }

                    return View("Error");
                }             
            
        }

    }
}
