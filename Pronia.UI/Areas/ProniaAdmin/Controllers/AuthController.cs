using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pronia.Core.Entities;
using Pronia.Core.Utilites;
using Pronia.UI.Areas.ProniaAdmin.ViewModels.AuthViewModel;
using Pronia.UI.Areas.ProniaAdmin.ViewModels.LoginViewModel;

namespace Pronia.UI.Areas.ProniaAdmin.Controllers;
[Area("ProniaAdmin")]
//[Authorize]
public class AuthController : Controller
{
    public readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }
    [AllowAnonymous]
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterVM newUser)
    {
        if (!ModelState.IsValid)
        {
            return View(newUser);
        }
        AppUser user = new()
        {
            Fullname= newUser.Username,
            Email= newUser.Email,
            UserName= newUser.Username
        };
        IdentityResult result =  await _userManager.CreateAsync(user, newUser.Password);
        if (!result.Succeeded)
        {
            foreach (var erorr in result.Errors)
            {
                ModelState.AddModelError("", erorr.Description);
            }
            return View(newUser);
        }
        await _userManager.AddToRoleAsync(user, UserRole.Member);
        return RedirectToAction(nameof(Login));
    }
    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginVM login)
    {
        if (!ModelState.IsValid) return View(login);
        AppUser user = await _userManager.FindByEmailAsync(login.Email);
        if (user == null)
        {
            ModelState.AddModelError("","Invalid Login");
            return View(login);
        }
        Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, login.Password,login.RememberMe, true);
        if (signInResult.IsLockedOut)
        {
            ModelState.AddModelError("", "Your account is locked. Try it later");
            return View(login);
        }
        if (!signInResult.Succeeded)
        {
            ModelState.AddModelError("", "Invalid Login");
            return View(login);
        }
        return RedirectToAction("Index", "Home", new { area = string.Empty });
    }
    [AllowAnonymous]
    public async Task<IActionResult> Logout()
    {
        if (User.Identity.IsAuthenticated)
        {
            await _signInManager.SignOutAsync();
        }
        return RedirectToAction("Index", "Home", new { area = string.Empty });
    }

    #region Create Role
    //public async Task CreateRole()
    //{
    //    foreach (var role in Enum.GetValues(typeof(UserRole.Roles)))
    //    {
    //        bool isExsist = await _roleManager.RoleExistsAsync(role.ToString());
    //        if (!isExsist)
    //        {
    //            await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
    //        }
    //    }
        
    //}
    #endregion
}
