using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Plantation.Models;


namespace E_Plantation.Controllers
{
    public class PremiTetapController : Controller
    {
        clsPremiTetapDB udb = new clsPremiTetapDB();
        // GET: HariKerja
        public ActionResult Index()
        {


            return View();
        }

        [HttpGet]
        //[JsonAuthorize]
        public JsonResult GetList()
        {

            List<clsPremiTetap> PremiTetap = udb.List();

            var jsonResult = Json(PremiTetap, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpGet]
        public JsonResult GetDataByCode(clsPremiTetap model)
        {
            var HK = udb.List().Find(x => x.IdPremiTetap.Equals(model.IdPremiTetap));
            string value = string.Empty;
            value = JsonConvert.SerializeObject(HK, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });


            var jsonResult = Json(value, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        //public JsonResult InsertData(clsPremiTetap model)
        public JsonResult InsertData(clsPremiTetap model)
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
        //public JsonResult InsertData(clsPremiTetap model)
        public JsonResult UpdateData(clsPremiTetap model)
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
        public JsonResult DeleteData(string IdPremiTetap)
        {
            try
            {

                //int result = udb.Insert(model, Session["LogUserID"].ToString());
                int result = udb.Delete(IdPremiTetap);

                return Json(new { Status = true, Message = "" });

            }
            catch (Exception ex)
            {
                return Json(new { Status = false, Message = ex.Message });
            }
        }

    }
}