using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Plantation.Models;

namespace E_Plantation.Controllers
{
    public class MartialController : Controller
    {
        // GET: Martial 
        clsMartialDB udb = new clsMartialDB();
        [HttpGet]
         public JsonResult GetList()
        {

            List<clsMartial> Martial = udb.List();

            var jsonResult = Json(Martial, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

    }
}