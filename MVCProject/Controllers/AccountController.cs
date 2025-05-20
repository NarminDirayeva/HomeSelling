using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.ViewModels.Account;

namespace MVCProject.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> _usermanager;
        private SignInManager<AppUser> _signinmanager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _usermanager = userManager;
            _signinmanager = signInManager;
            
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterVM newUser)
        {
            if (!ModelState.IsValid)
            {
                return View(newUser);
            }

            
            AppUser existingUserByEmail = await _usermanager.FindByEmailAsync(newUser.Email);
            if (existingUserByEmail != null)
            {
                ModelState.AddModelError(string.Empty, "An account with this email already exists.");
                return View(newUser);
            }

           
            AppUser existingUserByUsername = await _usermanager.FindByNameAsync(newUser.Username);
            if (existingUserByUsername != null)
            {
                ModelState.AddModelError(string.Empty, "An account with this username already exists.");
                return View(newUser);
            }

           
            AppUser user = new AppUser
            {
                Name = newUser.Name,
                Surname = newUser.Surname,
                Email = newUser.Email,
                UserName = newUser.Username
            };

            IdentityResult result = await _usermanager.CreateAsync(user, newUser.Password);
            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(" ", error.Description);
                }
                return View(newUser);
            }

            await _signinmanager.SignInAsync(user, false);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginVM user, string? ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser existed = await _usermanager.FindByEmailAsync(user.UsernameOrEmail);
            if (existed == null)
            {
                existed = await _usermanager.FindByNameAsync(user.UsernameOrEmail);

                if (existed == null)
                {
                    ModelState.AddModelError(string.Empty, "Username or email is incorrect");
                    return View(user); 
                }
            }

            var result = await _signinmanager.PasswordSignInAsync(existed, user.Password, user.IsRemember, true);

            if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "Account is temporarily locked out");
                return View(user);
            }

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Password is incorrect");
                return View(user);
            }

            if (ReturnUrl != null)
            {
                Redirect(ReturnUrl);
            }

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> LogOut()
        {
            await _signinmanager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
