using Appliocation.IServices.IUserServices;
using Domain.ViewModels.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Alib.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        #region Services
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion


        [HttpPost("Register")]
        public async Task<IActionResult> Index(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _userService.Register(registerViewModel));
            }

            return Ok(State.Failed);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await _userService.Login(model);
            switch (res)
            {
                case Res.Failde:
                    return NotFound("کاربری با مشخصات وارد شده یافت نشد");
                case Res.WrongPass:
                    return BadRequest("رمز عبور نادرست است");
                case Res.Success:
                    var info = await _userService.GetInfoForLoginByEmail(model.Email);
                    if (info == null)
                    {
                        return NotFound("کاربری با مشخصات وارد شده یافت نشد");
                    }

                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, info.id.ToString()),
                        new Claim(ClaimTypes.Email, info.Email),
                    };

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(principal, new AuthenticationProperties()
                    {
                        IsPersistent = true
                    });

                    return Ok("ورود با موفقیت انجام شد");

            }
            return StatusCode(500, "خطای غیرمنتظره");
        }
    }
}
