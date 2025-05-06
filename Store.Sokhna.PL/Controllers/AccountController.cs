using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json;
using Store.Sokhna.BLL.Interfaces;
using Store.Sokhna.DAL.Models;
using Store.Sokhna.PL.HelperClasses;
using Store.Sokhna.PL.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Store.Sokhna.PL.Controllers
{
	
	public class AccountController : Controller
	{
		private readonly IUnitofWork _UnitofWork;
		private readonly UserManager<ApplicationUser> _UserManager;
		private readonly SignInManager<ApplicationUser> _SignInManager;
		private readonly RoleManager<IdentityRole> _RoleManager;
		
		public AccountController(IUnitofWork unitofWork,
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager,
			RoleManager<IdentityRole> roleManager)
		{
			_UnitofWork = unitofWork;
			_UserManager = userManager;
			_SignInManager = signInManager;
			_RoleManager = roleManager;
		}
		#region Sign up
		[HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SignUp(SignUpViewModel model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var emps = await _UnitofWork.usersRepository.GetUnDeletedUsersBySSN(model.Serial);
					if (emps is not null)
					{
						var user = await _UserManager.FindByNameAsync(model.UserName);
						if (user is null)
						{
							user = await _UserManager.FindByEmailAsync(model.Email);
							if (user is null)
							{
								user = new ApplicationUser()
								{
									UserName = model.UserName,
									Email = model.Email,
									FullName = emps.FullName,
									Role = emps.Job,
									Serial = model.Serial,
									PhoneNumber = emps.Phone,
								};
								var Result = await _UserManager.CreateAsync(user, model.Password);
								//var Role = new IdentityRole()
								//{
								//	Name = emps.Job
								//};
								//await _RoleManager.CreateAsync(Role);
								if (Result.Succeeded)
								{
									return RedirectToAction("LogIn");
								}
								foreach (var error in Result.Errors)
								{
									ModelState.AddModelError(string.Empty, error.Description);
								}
							}
						}
						ModelState.AddModelError(string.Empty, "هذا الحساب موجود بالفعل");
					}
					else
						ModelState.AddModelError(string.Empty, "لا يمكنك تسجيل حساب اتصل بمدير الشركه");
				}
				catch (Exception ex)
				{
					ModelState.AddModelError(string.Empty, ex.Message);
				}
			}
			return View(model);
		}
		#endregion

		#region Log in
		[HttpGet]
		public IActionResult LogIn()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> LogIn(LogInViewModel model)
		{
			if (ModelState.IsValid)
			{
				try
				{ 
                    var user = await _UserManager.FindByNameAsync(model.UserName);
					if (user != null)
					{
                        var emps = await _UnitofWork.usersRepository.GetUnDeletedUsersBySSN(user.Serial);
						if (emps.Deleted == "F")
						{
							var flag = await _UserManager.CheckPasswordAsync(user, model.Password);
							if (flag)
							{
								var Result = await _SignInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
								if (Result.Succeeded)
								{
									var emp= await _UnitofWork.usersRepository.GetBySSN(user.Serial);
									string UserRole = JsonConvert.SerializeObject(emp.Job);
									string UserSSN = JsonConvert.SerializeObject(user.Serial);
									string UserFullName = JsonConvert.SerializeObject(user.FullName);
									Response.Cookies.Append("UserRole", UserRole);
									Response.Cookies.Append("UserSerial", UserSSN);
									Response.Cookies.Append("UserFullName", UserFullName);
									TempData["Role"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserRole"]);
									TempData["SSN"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserSerial"]);
									TempData["FullName"] = JsonConvert.DeserializeObject<string>(Request.Cookies["UserFullName"]);
									if (emp.Job == "Financial Manager")
                                        return RedirectToAction("Index", "Financials");
                                    else
										return RedirectToAction("Index", "Home");
								}
							}
						}
						else
                            ModelState.AddModelError(string.Empty, "هذا المستخدم محظور");
                    }
				}
				catch (Exception ex)
				{
					ModelState.AddModelError(string.Empty, ex.Message);
				}
				ModelState.AddModelError(string.Empty, "خطأ في التسجيل");
			}	
			return View(model);
		}
		#endregion

		#region Sign out
		public new async Task<IActionResult> SignOut()
		{
			await _SignInManager.SignOutAsync();
			return RedirectToAction("LogIn", "Account");
		}
        #endregion

        #region forget password
        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }
		[HttpPost]
		public async Task<IActionResult> SendResetPasswordUrl(ForgetPasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user=await _UserManager.FindByEmailAsync(model.Email);
				if (user is not null)
				{
                    var emps = await _UnitofWork.usersRepository.GetUnDeletedUsersBySSN(user.Serial);
					if (emps.Deleted == "F")
					{
						var token = await _UserManager.GeneratePasswordResetTokenAsync(user);
						var url = Url.Action("ResetPassword", "Account", new { email = model.Email, token = token }, Request.Scheme);
						var email = new EmailSend()
						{
							To = model.Email,
							Title = "Reset Password From El-salah",
							Body = url
						};
						EmailSettings.SendEmailTo(email);
						return RedirectToAction(nameof(CheckYourInbox));
                    }
                    else
                        ModelState.AddModelError(string.Empty, "هذا المستخدم محظور");
                }
				ModelState.AddModelError(string.Empty, "خطأ في العمليه ,اعد مره اخري");
			}
			return View(model);
		}

		[HttpGet]
		public IActionResult CheckYourInbox()
		{
			return View();
		}
		[HttpGet]
		public IActionResult ResetPassword(string email,string token)
		{
			TempData["email"] = email;
			TempData["token"] = token;
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				var email = TempData["email"] as string;
				var token = TempData["token"] as string;
				var user=await _UserManager.FindByEmailAsync(email);
				if (user != null)
				{
					var Result=await _UserManager.ResetPasswordAsync(user,token,model.Password);
					if (Result.Succeeded)
					{
						return RedirectToAction(nameof(SignIn));
					}
				}

			}
			ModelState.AddModelError(string.Empty, "خطأ في العمليه ,اعد مره اخري");
			return View(model);
		}
		#endregion
	}
}
