using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Plantation.Models;


namespace E_Plantation.Controllers
{
    public class SetVariableController : Controller
    {
        // GET: TipeDenda
        clsSetVariableDB udb = new clsSetVariableDB();
     

        [HttpGet]
        //[JsonAuthorize]
        public JsonResult GetList()
        {

            List<clsSetVariable> SetVariable = udb.List();

            var jsonResult = Json(SetVariable, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}