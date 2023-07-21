using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Plantation.Models;

namespace E_Plantation.Controllers
{
    public class CatuBerasController : Controller
    {
        clsCatuBerasDB udb = new clsCatuBerasDB();
        clsHargaBerasDB udbHargaBeras = new clsHargaBerasDB();
        clsMartialDB udbMartial = new clsMartialDB();
        // GET: CatuBeras
        public ActionResult Index()
        {


            return View();
        }
        [HttpGet]
        //[JsonAuthorize]
        public JsonResult GetListHargaBeras()
        {

            List<clsHargaBeras> HargaBeras = udbHargaBeras.List();

            var jsonResult = Json(HargaBeras, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        [HttpGet]
        //[JsonAuthorize]
        public JsonResult GetListMartial()
        {

            List<clsMartial> Martial = udbMartial.List();

            var jsonResult = Json(Martial, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        [HttpGet]
        //[JsonAuthorize]
        public JsonResult GetList(clsCatuBeras model)
        {

            List<clsCatuBeras> CatuBeras = udb.List(model);

            var jsonResult = Json(CatuBeras, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpGet]
        public JsonResult GetDataByCode(clsCatuBeras model)
        {
            var CatuBeras = udb.List(model).Find(x => x.IdCatuBeras.Equals(model.IdCatuBeras));
            string value = string.Empty;
            value = JsonConvert.SerializeObject(CatuBeras, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });


            var jsonResult = Json(value, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        //public JsonResult InsertData(clsCatuBeras model)
        public JsonResult InsertData(clsCatuBeras model)
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
        //public JsonResult InsertData(clsCatuBeras model)
        public JsonResult UpdateData(clsCatuBeras model)
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
        public JsonResult DeleteData(string IdCatuBeras)
        {
            try
            {

                //int result = udb.Insert(model, Session["LogUserID"].ToString());
                int result = udb.Delete(IdCatuBeras);

                return Json(new { Status = true, Message = "" });

            }
            catch (Exception ex)
            {
                return Json(new { Status = false, Message = ex.Message });
            }
        }


    }
}