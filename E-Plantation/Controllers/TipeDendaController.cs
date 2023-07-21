using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Plantation.Models;

namespace E_Plantation.Controllers
{
    public class TipeDendaController : Controller
    {
        // GET: TipeDenda
        clsTipeDendaDB udb = new clsTipeDendaDB();
        // GET: TipeDenda
        public ActionResult Index()
        {


            return View();
        }

        [HttpGet]
        //[JsonAuthorize]
        public JsonResult GetList()
        {

            List<clsTipeDenda> TipeDenda = udb.List();

            var jsonResult = Json(TipeDenda, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpGet]
        public JsonResult GetDataByCode(clsTipeDenda model)
        {
            var TipeDenda = udb.List().Find(x => x.IdTipeDenda.Equals(model.IdTipeDenda));
            string value = string.Empty;
            value = JsonConvert.SerializeObject(TipeDenda, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });


            var jsonResult = Json(value, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        //public JsonResult InsertData(clsTipeDenda model)
        public JsonResult InsertData(clsTipeDenda model)
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
        //public JsonResult InsertData(clsTipeDenda model)
        public JsonResult UpdateData(clsTipeDenda model)
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
        public JsonResult DeleteData(string IdTipeDenda)
        {
            try
            {

                //int result = udb.Insert(model, Session["LogUserID"].ToString());
                int result = udb.Delete(IdTipeDenda);

                return Json(new { Status = true, Message = "" });

            }
            catch (Exception ex)
            {
                return Json(new { Status = false, Message = ex.Message });
            }
        }


    }
}