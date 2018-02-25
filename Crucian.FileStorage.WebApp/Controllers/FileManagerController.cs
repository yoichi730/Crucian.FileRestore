using Crucian.FileStorage.CORE;
using Crucian.FileStorage.DB;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Crucian.FileStorage.WebApp.Controllers
{
    public class FileManagerController : Controller
    {
        [Authorize]
        public ActionResult Index(User Account)
        {
            var FileManager = new FileManager();

            ViewBag.UserName = Account.Name;

            var UserFiles= FileManager.GetListOfUserFilesByUser(Account);
            
            return View(UserFiles);
        }
    }
}