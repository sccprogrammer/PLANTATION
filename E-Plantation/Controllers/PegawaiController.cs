using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Plantation.Models;

namespace E_Plantation.Controllers
{
    public class PegawaiController : Controller
    {
        clsPegawaiDB udb = new clsPegawaiDB();
        // GET: Pegawai
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        //[JsonAuthorize]
        public JsonResult GetList()
        {

            List<clsPegawai> Pegawai = udb.List();

            var jsonResult = Json(Pegawai, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

    }
}