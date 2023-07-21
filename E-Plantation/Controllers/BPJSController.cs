using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Plantation.Models;


namespace E_Plantation.Controllers
{
    public class BPJSController : Controller
    {
        // GET: BPJS
        clsBPJSDB udb = new clsBPJSDB(); 
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        //[JsonAuthorize]
        public JsonResult GetList()
        {

            List<clsBPJS> BPJS = udb.List();

            var jsonResult = Json(BPJS, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpGet]
        public JsonResult GetDataByCode(clsBPJS model)
        {
            var BPJS = udb.List().Find(x => x.IDBPJS.Equals(model.IDBPJS));
            string value = string.Empty;
            value = JsonConvert.SerializeObject(BPJS, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });


            var jsonResult = Json(value, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        //public JsonResult InsertData(clsBPJS model)
        public JsonResult InsertData(clsBPJS model)
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
        //public JsonResult InsertData(clsBPJS model)
        public JsonResult UpdateData(clsBPJS model)
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
        public JsonResult DeleteData(string IdBPJS)
        {
            try
            {

                //int result = udb.Insert(model, Session["LogUserID"].ToString());
                int result = udb.Delete(IdBPJS); 
                 
                return Json(new { Status = true, Message = "" });


            }
            catch (Exception ex)
            {
                return Json(new { Status = false, Message = ex.Message });
            }
        }

    }
}