using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace E_Plantation.Models
{
    public class clsPegawai
    {
        public string NIK { get; set; }
        public string NamaLengkap { get; set; }
        public string Level { get; set; }
        public string Departemen { get; set; }
        public string Jabatan { get; set; }
        public string TglMasuK{ get; set; }
    }
    public class clsPegawaiDB
    {
        string constr = _DBConnection.SCCOFFICE;
        public List<clsPegawai> List()
        {
            List<clsPegawai> modelList = new List<clsPegawai>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string q = "sp_Employee_GetList";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    clsPegawai model = new clsPegawai();
                    model.NIK = rd["NIK"].ToString();
                    model.NamaLengkap = rd["NamaLengkap"].ToString();
                    model.Level = rd["Level"].ToString();
                    model.Departemen = rd["Departemen"].ToString();
                    model.Jabatan = rd["Jabatan"].ToString();
                    model.TglMasuK = Convert.ToDateTime(rd["TglMasuK"].ToString()).ToString("dd/MM/yyyy");

                    modelList.Add(model);
                }
                con.Close();
                return modelList;
            }
        }
    }
}