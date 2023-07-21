using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient; 

namespace E_Plantation.Models
{
    public class clsBlok
    {
        public int IdBlok { get; set; }
        public int IdDivisi { get; set; }
        public string NamaDivisi { get; set; }
        public string AreaBlok { get; set; }
        public string Blok { get; set; }
        public string TahunTanam { get; set; }
        public string LuasHA { get; set; }
        public string JumlahPKK { get; set; }
        public string SPH { get; set; }
    }


    public class clsBlokDB
    {
        string constr = _DBConnection.SCC;
        public List<clsBlok> List()
        {
            List<clsBlok> modelList = new List<clsBlok>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string q = "sp_Blok_GetList";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.CommandType = CommandType.StoredProcedure; 
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    clsBlok model = new clsBlok();
                    model.IdBlok = Convert.ToInt32(rd["IdBlok"].ToString());
                    model.IdDivisi = Convert.ToInt32(rd["IdDivisi"].ToString());
                    model.NamaDivisi = rd["NamaDivisi"].ToString();
                    model.AreaBlok = rd["AreaBlok"].ToString();
                    model.Blok = rd["Blok"].ToString();
                    model.TahunTanam = rd["TahunTanam"].ToString();
                    model.LuasHA = rd["LuasHA"].ToString();
                    model.JumlahPKK = rd["JumlahPKK"].ToString();
                    model.SPH = rd["SPH"].ToString();

                    modelList.Add(model);
                }
                con.Close();
                return modelList;
            }
        }
        
        //public int Insert(clsMSDepartment model, string userlogin)
        public int Insert(clsBlok model)
        {
             int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_Blok_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure; 
                cmd.Parameters.AddWithValue("IdDivisi", model.IdDivisi);
                cmd.Parameters.AddWithValue("AreaBlok", model.AreaBlok);
                cmd.Parameters.AddWithValue("Blok", model.Blok);
                cmd.Parameters.AddWithValue("TahunTanam", model.TahunTanam);
                cmd.Parameters.AddWithValue("LuasHA", model.LuasHA); 
                cmd.Parameters.AddWithValue("JumlahPKK", model.JumlahPKK); 
                cmd.Parameters.AddWithValue("SPH", model.SPH); 

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
        public int Update(clsBlok model)
        {
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_Blok_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdBlok", model.IdBlok);
                cmd.Parameters.AddWithValue("IdDivisi", model.IdDivisi);
                cmd.Parameters.AddWithValue("AreaBlok", model.AreaBlok);
                cmd.Parameters.AddWithValue("Blok", model.Blok);
                cmd.Parameters.AddWithValue("TahunTanam", model.TahunTanam);
                cmd.Parameters.AddWithValue("LuasHA", model.LuasHA);
                cmd.Parameters.AddWithValue("JumlahPKK", model.JumlahPKK);
                cmd.Parameters.AddWithValue("SPH", model.SPH);

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
        public int Delete(string IdBlok)
        {
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_Blok_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IDBLOK", IdBlok);

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }


    }
}