using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Plantation.Models;

namespace E_Plantation.Controllers
{
    public class DendaController : Controller
    {
        // GET: Denda
        clsDendaDB udb = new clsDendaDB();
        // GET: Denda
        public ActionResult Index()
        {


            return View();
        }

        [HttpGet]
        //[JsonAuthorize]
        public JsonResult GetList()
        {

            List<clsDenda> Denda = udb.List();

            var jsonResult = Json(Denda, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpGet]
        public JsonResult GetDataByCode(clsDenda model)
        {
            var Denda = udb.List().Find(x => x.IdDenda.Equals(model.IdDenda));
            string value = string.Empty;
            value = JsonConvert.SerializeObject(Denda, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });


            var jsonResult = Json(value, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        //public JsonResult InsertData(clsDenda model)
        public JsonResult InsertData(clsDenda model)
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
        //public JsonResult InsertData(clsDenda model)
        public JsonResult UpdateData(clsDenda model)
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
        public JsonResult DeleteData(string IdDenda)
        {
            try
            {

                //int result = udb.Insert(model, Session["LogUserID"].ToString());
                int result = udb.Delete(IdDenda);

                return Json(new { Status = true, Message = "" });

            }
            catch (Exception ex)
            {
                return Json(new { Status = false, Message = ex.Message });
            }
        }


    }
}