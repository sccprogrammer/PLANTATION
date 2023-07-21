using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Plantation.Models;

using System.IO;
using System.Data;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Microsoft.Office.Interop.Excel;

namespace E_Plantation.Controllers
{
    public class GradeController : Controller
    {
        // GET: Grade
        clsGradeDB udb = new clsGradeDB();
        clsGradeCodeDB udbCode = new clsGradeCodeDB();
        // GET: HariKerja
        public ActionResult Index()
        {


            return View();
        }

        [HttpGet]
        //[JsonAuthorize]
        public JsonResult GetList()
        {

            List<clsGrade> Grade = udb.List();

            var jsonResult = Json(Grade, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpGet]
        public JsonResult GetDataByCode(clsGrade model)
        {
            var Grade = udb.List().Find(x => x.IdMasterGrade.Equals(model.IdMasterGrade));
            string value = string.Empty;
            value = JsonConvert.SerializeObject(Grade, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });


            var jsonResult = Json(value, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpGet]
        //[JsonAuthorize]
        public JsonResult GeKodeGetListCode()
        {

            List<clsGradeCode> Grade = udbCode.List();

            var jsonResult = Json(Grade, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        //public JsonResult InsertData(clsGrade model)
        public JsonResult InsertData(clsGrade model)
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
        //public JsonResult InsertData(clsGrade model)
        public JsonResult UpdateData(clsGrade model)
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
        public JsonResult DeleteData(string IdMasterGrade)
        {
            try
            {

                //int result = udb.Insert(model, Session["LogUserID"].ToString());
                int result = udb.Delete(IdMasterGrade);

                return Json(new { Status = true, Message = "" });

            }
            catch (Exception ex)
            {
                return Json(new { Status = false, Message = ex.Message });
            }
        }
        public ActionResult DownloadGrade()
        {

            if (Session["DownloadExcel_FileManager"] != null)
            {
                byte[] data = Session["DownloadExcel_FileManager"] as byte[];
                return File(data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Master_Grade_" + Convert.ToDateTime(DateTime.Now).ToString("yyyyMMddh-hhmmss") + ".xlsx");
            }
            else
            {
                return new EmptyResult();
            }
        }
        public ActionResult ExportExcelGrade()
        {
            try
            {
                List<clsGrade> ListGrade = udb.List();
                var memoryStream = new MemoryStream();
                using (var excelPackage = new ExcelPackage(memoryStream))
                {
                    ExcelWorksheet ws = excelPackage.Workbook.Worksheets.Add("Sheet1");
                    ws.Cells.Style.Font.Size = 11;


                    ws.Cells["A1"].Value = "MASTER GRADE";
                    ws.Cells["A1:E1"].Merge = true;
                    ws.Cells["A1"].Style.Font.Size = 18;
                    ws.Cells["A1"].Style.Font.Bold = true;


                    ws.Cells["A3"].Value = "KODE GRADE";
                    ws.Cells["A3:B3"].Merge = true;
                    ws.Cells["C3"].Value = "GAJI POKOK";
                    ws.Cells["C3:D3"].Merge = true;
                    ws.Cells["A3:C3"].Style.Font.Bold = true;
                    ExcelRange BorderHead = ws.Cells["A3:D3"];
                    BorderHead.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    BorderHead.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    BorderHead.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    BorderHead.Style.Border.Top.Style = ExcelBorderStyle.Thin;

                    int rowItemDown = 4;
                    for (int looping = 0; looping < ListGrade.Count; looping++)
                    {
                        ws.Cells["A" + rowItemDown].Value = ListGrade[looping].GradeCode;
                        ws.Cells["C" + rowItemDown].Value = ListGrade[looping].GajiPokok;


                        ExcelRange Border = ws.Cells["A" + rowItemDown + ":C" + rowItemDown];
                        Border.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        Border.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        Border.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        Border.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        ExcelRange Merg1 = ws.Cells["A" + rowItemDown + ":B" + rowItemDown];
                        Merg1.Merge = true;
                        ExcelRange Merg2 = ws.Cells["C" + rowItemDown + ":D" + rowItemDown];
                        Merg2.Merge = true;

                        rowItemDown++;
                    }

                    Session["DownloadExcel_FileManager"] = excelPackage.GetAsByteArray();

                    return Json("", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
    }
}