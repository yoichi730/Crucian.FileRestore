using Crucian.FileStorage.CORE;
using Crucian.FileStorage.CORE.Models;
using Crucian.FileStorage.DB;
using Crucian.FileStorage.WebApp.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace Crucian.FileStorage.WebApp.Controllers
{


    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(Account Account)
        {
            var UserManager = new UserManager();

            var user = UserManager.CheckUserByLogin(Account.Login);

            if (Account.Login == user.Login && user.Password == Account.Password)
            {
                FormsAuthentication.SetAuthCookie(Account.Login, true);

                return RedirectToAction("Index", "FileManager", user);
            }

            ViewBag.Message = "Неверный логин-пароль";
            return View();
        }


        [AllowAnonymous]
        public ActionResult Register()
        {
            

            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(Account Account)
        {
            var UserManager = new UserManager();
            
            var NewUser = new User() {  Login=Account.Login,
                                        Password=Account.Password,
                                        BirthDay = Account.BirthDay,
                                        Name = Account.Name,
                                        Role = 1,
                                        Status = 1
                                     };
            var ChekedAccount = UserManager.GetInfoAboutTheAccountByHisLogin(Account.Login);
            if ( NewUser.Login != ChekedAccount.Login )
            {
                UserManager.AddNewUser(NewUser);
                ViewBag.Message = "Регистрация прошла успешно";
                return RedirectToAction("Index", "Account", Account);
            }
            ViewBag.Message = $"пользователь {Account.Login} уже зарегистрирован";

            return View("Register");
        }

    }
}