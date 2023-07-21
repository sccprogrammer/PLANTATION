using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Plantation.Models;


namespace E_Plantation.Controllers
{
    public class HariLiburController : Controller
    {
        clsHariLiburDB udb = new clsHariLiburDB();
        // GET: HariLibur
        public ActionResult Index()
        {


            return View();
        }

        [HttpGet]
        //[JsonAuthorize]
        public JsonResult GetList(clsHariLibur model)
        {

            List<clsHariLibur> HL = udb.List(model);

            var jsonResult = Json(HL, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpGet]
        public JsonResult GetDataByCode(clsHariLibur model)
        {
            var HL = udb.List(model).Find(x => x.IdHariLibur.Equals(model.IdHariLibur));
            string value = string.Empty;
            value = JsonConvert.SerializeObject(HL, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });


            var jsonResult = Json(value, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        //public JsonResult InsertData(clsHariLibur model)
        public JsonResult InsertData(clsHariLibur model)
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
        //public JsonResult InsertData(clsHariLibur model)
        public JsonResult UpdateData(clsHariLibur model)
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
        public JsonResult DeleteData(string IdHariLibur)
        {
            try
            {

                //int result = udb.Insert(model, Session["LogUserID"].ToString());
                int result = udb.Delete(IdHariLibur);

                return Json(new { Status = true, Message = "" });

            }
            catch (Exception ex)
            {
                return Json(new { Status = false, Message = ex.Message });
            }
        }
    }
}