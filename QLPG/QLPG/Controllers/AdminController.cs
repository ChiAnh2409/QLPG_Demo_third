using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace QLPG.Controllers
{
    public class AdminController : Controller
    {
        private List<string> adminNotifications = new List<string>();
        public ActionResult Index()
        {
            // Lấy số thông báo mới từ TempData
            int newNotificationCount = (int)(TempData["NewNotificationCount"] ?? 0);

            // Truyền số thông báo mới cho view
            ViewBag.NewNotificationCount = newNotificationCount;
            return View();
        }
    }

}