using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace E_Plantation.Models
{
    public class clsHariLibur
    {
        public int IdHariLibur { get; set; }
        public int IdHK { get; set; }
        public string TglHariLibur { get; set; }
        public string Keterangan { get; set; } 
        public string CreateUser { get; set; } 
    }




    public class clsHariLiburDB
    {
        string constr = _DBConnection.SCC;
        public List<clsHariLibur> List(clsHariLibur modelData)
        {
            List<clsHariLibur> modelList = new List<clsHariLibur>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string q = "sp_HariLibur_GetList";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdHK", modelData.IdHK);
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    clsHariLibur model = new clsHariLibur();
                    model.IdHK = Convert.ToInt32(rd["IdHK"].ToString());
                    model.TglHariLibur = Convert.ToDateTime(rd["TglHariLibur"].ToString()).ToString("dd/MM/yyyy");
                    model.Keterangan = rd["Keterangan"].ToString();

                    modelList.Add(model);
                }
                con.Close();
                return modelList;
            }
        }
        //public int Insert(clsMSDepartment model, string userlogin)
        public int Insert(clsHariLibur model)
        {
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_HariLibur_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdHK", model.IdHK);
                cmd.Parameters.AddWithValue("TglHariLibur", model.TglHariLibur);
                cmd.Parameters.AddWithValue("Keterangan", model.Keterangan);
                cmd.Parameters.AddWithValue("CREATEUSER", "");

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
        public int Update(clsHariLibur model)
        {
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_HariLibur_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdHariLibur", model.IdHariLibur);
                cmd.Parameters.AddWithValue("IdHK", model.IdHK);
                cmd.Parameters.AddWithValue("TglHariLibur", model.TglHariLibur);
                cmd.Parameters.AddWithValue("Keterangan", model.Keterangan);
                cmd.Parameters.AddWithValue("CREATEUSER", "");

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
        public int Delete(string IdHariLibur)
        {
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_HariLibur_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdHariLibur", IdHariLibur);

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
    }
}