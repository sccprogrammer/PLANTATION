using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Plantation.Models;

namespace E_Plantation.Controllers
{
    public class ActivityController : Controller
    {
        // GET: Activity
        clsActivityDB udb = new clsActivityDB();
        // GET: Activity
        public ActionResult Index()
        {


            return View();
        }

        [HttpGet]
        //[JsonAuthorize]
        public JsonResult GetList()
        {

            List<clsActivity> Activity = udb.List();

            var jsonResult = Json(Activity, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpGet]
        public JsonResult GetDataByCode(clsActivity model)
        {
            var Activity = udb.List().Find(x => x.IdActivity.Equals(model.IdActivity));
            string value = string.Empty;
            value = JsonConvert.SerializeObject(Activity, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });


            var jsonResult = Json(value, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        //public JsonResult InsertData(clsActivity model)
        public JsonResult InsertData(clsActivity model)
        {
            try
            {

                //int result = udb.Insert(model, Session["LogUserID"].ToString());
                int result = udb.Insert(model);

                return Json(new { Status = true, Message = "" });


            }
            catch (Exception ex)
            {
                return Json(new { Status = false, Message = ex.Message });
            }
        }
        [HttpPost]
        //public JsonResult InsertData(clsActivity model)
        public JsonResult UpdateData(clsActivity model)
        {
            try
            {

                //int result = udb.Insert(model, Session["LogUserID"].ToString());
                int result = udb.Update(model);


                return Json(new { Status = true, Message = "" });


            }
            catch (Exception ex)
            {
                return Json(new { Status = false, Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult DeleteData(string IdActivity)
        {
            try
            {

                //int result = udb.Insert(model, Session["LogUserID"].ToString());
                int result = udb.Delete(IdActivity);

                return Json(new { Status = true, Message = "" });

            }
            catch (Exception ex)
            {
                return Json(new { Status = false, Message = ex.Message });
            }
        }


    }
}