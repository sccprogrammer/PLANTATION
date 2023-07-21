using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace E_Plantation.Models
{
    public class clsBPJS
    {
        public int IDBPJS { get; set; }
        public string ItemBPJS { get; set; }
        public string Karyawan { get; set; }
        public string Perusahaan { get; set; }
        public string Total { get; set; }
        public string CreateUser { get; set; }
    }


    public class clsBPJSDB
    {
        string constr = _DBConnection.SCC;

        public List<clsBPJS> List()
        {
            List<clsBPJS> modelList = new List<clsBPJS>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string q = "sp_BPJS_GetList";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.CommandType = CommandType.StoredProcedure; 
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    clsBPJS model = new clsBPJS();
                    model.IDBPJS = Convert.ToInt32(rd["IDBPJS"].ToString());
                    model.ItemBPJS = rd["ItemBPJS"].ToString();
                    model.Karyawan = rd["Karyawan"].ToString();
                    model.Perusahaan = rd["Perusahaan"].ToString();
                    model.Total = rd["Total"].ToString(); 

                    modelList.Add(model);
                }
                con.Close();
                return modelList;
            }
        }
        //public int Insert(clsMSDepartment model, string userlogin)
        public int Insert(clsBPJS model)
        {
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_BPJS_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ITEMBPJS", model.ItemBPJS);
                cmd.Parameters.AddWithValue("KARYAWAN", model.Karyawan);
                cmd.Parameters.AddWithValue("PERUSAHAAN", model.Perusahaan);
                cmd.Parameters.AddWithValue("CREATEUSER", "");

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
        public int Update(clsBPJS model)
        {
             int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_BPJS_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IDBPJS", model.IDBPJS);
                cmd.Parameters.AddWithValue("ITEMBPJS", model.ItemBPJS);
                cmd.Parameters.AddWithValue("KARYAWAN", model.Karyawan);
                cmd.Parameters.AddWithValue("PERUSAHAAN", model.Perusahaan);
                cmd.Parameters.AddWithValue("CREATEUSER", "");

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
        public int Delete(string IdBPJS)
        {
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_BPJS_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IDBPJS", IdBPJS);

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }

    }
}