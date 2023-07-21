using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace E_Plantation.Models
{
    public class clsCatuBeras
    {
        public int IdCatuBeras { get; set; }
        public string Tahun { get; set; }
        public string StatusMartial { get; set; }
        public string HargaBeras { get; set; }
        public string Pekerja { get; set; }
        public string Tanggungan { get; set; }
        public string Total { get; set; }
        public string NilaiHarga { get; set; }
    }

    public class clsCatuBerasDB
    {
        string constr = _DBConnection.SCC;

        public List<clsCatuBeras> List(clsCatuBeras modelData)
        {
            List<clsCatuBeras> modelList = new List<clsCatuBeras>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string q = "sp_CatuBeras_GetList";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Tahun", modelData.Tahun);
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    clsCatuBeras model = new clsCatuBeras();
                    model.IdCatuBeras = Convert.ToInt32(rd["IdCatuBeras"].ToString());
                    model.Tahun = rd["Tahun"].ToString();
                    model.StatusMartial = rd["STATUSMARTIAL"].ToString();
                    model.HargaBeras = rd["HargaBeras"].ToString();
                    model.Pekerja = rd["Pekerja"].ToString();
                    model.Tanggungan = rd["Tanggungan"].ToString();
                    model.Total = rd["Total"].ToString();
                    model.NilaiHarga = rd["NilaiHarga"].ToString();

                    modelList.Add(model);
                }
                con.Close();
                return modelList;
            }
        }
        //public int Insert(clsMSDepartment model, string userlogin)
        public int Insert(clsCatuBeras model)
        {
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_CatuBeras_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Tahun", model.Tahun);
                cmd.Parameters.AddWithValue("StatusMartial", model.StatusMartial);
                cmd.Parameters.AddWithValue("HargaBeras", model.HargaBeras);
                cmd.Parameters.AddWithValue("Pekerja", model.Pekerja);
                cmd.Parameters.AddWithValue("Tanggungan", model.Tanggungan);  
                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
        public int Update(clsCatuBeras model)
        {
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_CatuBeras_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdCatuBeras", model.IdCatuBeras);
                cmd.Parameters.AddWithValue("Tahun", model.Tahun);
                cmd.Parameters.AddWithValue("StatusMartial", model.StatusMartial);
                cmd.Parameters.AddWithValue("HargaBeras", model.HargaBeras);
                cmd.Parameters.AddWithValue("Pekerja", model.Pekerja);
                cmd.Parameters.AddWithValue("Tanggungan", model.Tanggungan); 

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
        public int Delete(string IdCatuBeras)
        {
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_CatuBeras_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdCatuBeras", IdCatuBeras);

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
    }
}