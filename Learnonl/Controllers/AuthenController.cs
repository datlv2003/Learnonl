using Learnonl.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Learnonl.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace Learnonl.Controllers
{
    public class AuthenController : Controller
    {
        private readonly LearnonlContext? _context;
        public AuthenController(LearnonlContext context)
        {
            _context = context;
        }
        #region Login
        // GET: /Authen/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Authen/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Models.Login model, bool rememberMe)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra thông tin đăng nhập từ cơ sở dữ liệu
                var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Username == model.Username && a.Password == model.Password);

                if (/*model.Username != null && model.Password != null*/account != null)
                {
                    if (model.Username != account.Username || model.Password != account.Password)
                    {
                        // Nếu thông tin đăng nhập không chính xác, trả về thông báo lỗi
                        TempData["ErrorMessage"] = "Invalid username or password";
                    }
                    else
                    {

                        // Thực hiện đăng nhập, có thể sử dụng session hoặc cookie để lưu trạng thái đăng nhập
                        // Lưu thông tin đăng nhập vào Session
                        HttpContext.Session.SetString("UserId", account.UserId.ToString());
                        HttpContext.Session.SetString("Username", account.Username);
                        var userRole = await _context.Accounts
                          .Where(a => a.Username == model.Username && a.Password == model.Password)
                          .Select(a => a.UserRole)
                          .FirstOrDefaultAsync();

                        // Kiểm tra UserRole và lưu trạng thái isAdmin vào Session
                        if (userRole == "Admin")
                        {
                            HttpContext.Session.SetString("UserRole", "Admin");
                        }
                        else if (userRole == "Student")
                        {
                            HttpContext.Session.SetString("UserRole", "Student");
                        }
                        else if (userRole == "Teacher")
                        {
                            HttpContext.Session.SetString("UserRole", "Teacher");
                        }

                        // Tạo claims
                        var claims = new[]
                        {
                            new Claim(ClaimTypes.Name, account.Username)
                        };

                        // Tạo principal
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        // Tạo authentication properties
                        var authProperties = new AuthenticationProperties
                        {
                            IsPersistent = rememberMe, // Xác định liệu có lưu đăng nhập hay không
                            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30) // Thời gian hết hạn của cookie
                        };
                        // Đăng nhập bằng cookie
                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity),
                            authProperties);
                        // Chuyển hướng đến trang chính sau khi đăng nhập thành công
                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid username or password");
            }

            // Nếu thông tin không hợp lệ, hiển thị lại form đăng nhập với thông báo lỗi
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("UserRole");
            // Xóa thông tin đăng nhập khỏi Session
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion
        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Models.Register model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem email đã được sử dụng chưa
                var existingAccount = _context.Accounts.FirstOrDefault(a => a.Email == model.Email);
                if (existingAccount != null)
                {
                    ModelState.AddModelError(string.Empty, "Email has already been used. Please choose another email.");
                    return View(model);
                }

                // Tạo tài khoản mới
                var account = new Account
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password,
                };

                // Thêm tài khoản mới vào cơ sở dữ liệu
                _context.Accounts.Add(account);
                _context.SaveChanges();

                // Đăng ký thành công, chuyển hướng đến trang đăng nhập hoặc trang khác
                return RedirectToAction("Login", "Authen");
            }

            // Nếu model không hợp lệ, hiển thị lại view đăng ký với thông báo lỗi
            return View(model);
        }
        #endregion
    }
}
