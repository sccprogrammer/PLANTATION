using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace E_Plantation.Models
{
    public class clsHariKerja
    {
        public int IDHK { get; set; }
        public string Tahun { get; set; }
        public string Bulan { get; set; } 
        public string NamaBulan { get; set; }
        public string HariKerja { get; set; }
        public string HariLibur { get; set; }
        public string CreateUser { get; set; }
        public string CreateDate { get; set; }
        public string CreateIP { get; set; }
        public string UpdateUser { get; set; }
        public string UpdateDate { get; set; }
        public string UpdateIP { get; set; }
    }




    public class clsHariKerjaDB
    {
        string constr = _DBConnection.SCC;
        public List<clsHariKerja> List(clsHariKerja modelData)
        {
            List<clsHariKerja> modelList = new List<clsHariKerja>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string q = "sp_HariKerja_GetList";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("TAHUN", modelData.Tahun);
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    clsHariKerja model = new clsHariKerja();
                    model.IDHK = Convert.ToInt32(rd["IDHK"].ToString());
                    model.Tahun = rd["Tahun"].ToString();
                    model.Bulan = rd["Bulan"].ToString();
                    model.NamaBulan = rd["NamaBulan"].ToString();
                    model.HariKerja = rd["HariKerja"].ToString();
                    model.HariLibur = rd["HariLibur"].ToString();

                    modelList.Add(model);
                }
                con.Close();
                return modelList;
            }
        }
        //public int Insert(clsMSDepartment model, string userlogin)
        public int Insert(clsHariKerja model)
        {
             int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_HariKerja_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("TAHUN", model.Tahun);
                cmd.Parameters.AddWithValue("BULAN", model.Bulan);
                cmd.Parameters.AddWithValue("HARIKERJA", model.HariKerja);
                cmd.Parameters.AddWithValue("CREATEUSER", ""); 

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
        public int Update(clsHariKerja model)
        {
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_HariKerja_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IDHK", model.IDHK);
                cmd.Parameters.AddWithValue("TAHUN", model.Tahun);
                cmd.Parameters.AddWithValue("BULAN", model.Bulan);
                cmd.Parameters.AddWithValue("HARIKERJA", model.HariKerja);
                cmd.Parameters.AddWithValue("CREATEUSER", "");

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
        public int Delete(string IdHk)
        {
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_HariKerja_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IDHK", IdHk); 

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
    }
}