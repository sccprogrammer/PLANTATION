using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Plantation.Models;


namespace E_Plantation.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult SideMenu()
        {
            //string UserId = Session["LogUserID"].ToString();
            string UserId = "";
            clsMenuDb db = new clsMenuDb();
            List<clsMenu> menus = db.ListMenu(UserId).ToList();
            return PartialView("_SideBar", menus);
        } 
    }

 
}