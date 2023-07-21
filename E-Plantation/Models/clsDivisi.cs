using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace E_Plantation.Models
{
    public class clsDivisi
    {
        public int IdDivisi { get; set; }
        public string NamaDivisi { get; set; }
        public string NoUrutDivisi { get; set; }
    }

    public class clsDivisiDB
    {
        string constr = _DBConnection.SCC;

        public List<clsDivisi> List()
        {
            List<clsDivisi> modelList = new List<clsDivisi>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string q = "sp_Divisi_GetList";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.CommandType = CommandType.StoredProcedure; 
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    clsDivisi model = new clsDivisi();
                    model.IdDivisi = Convert.ToInt32(rd["IdDivisi"].ToString());
                    model.NamaDivisi = rd["NamaDivisi"].ToString();
                    model.NoUrutDivisi =  rd["NoUrutDivisi"].ToString();

                    modelList.Add(model);
                }
                con.Close();
                return modelList;
            }
        }
        //public int Insert(clsMSDepartment model, string userlogin)
        public int Insert(clsDivisi model)
        {
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_Divisi_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure; 
                cmd.Parameters.AddWithValue("NAMADIVISI", model.NamaDivisi);
                cmd.Parameters.AddWithValue("NOURUTDIVISI", model.NoUrutDivisi); 

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
        public int Update(clsDivisi model)
        {
           int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_Divisi_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IDDIVISI", model.IdDivisi);
                cmd.Parameters.AddWithValue("NAMADIVISI", model.NamaDivisi);
                cmd.Parameters.AddWithValue("NOURUTDivisi", model.NoUrutDivisi); 

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
        public int Delete(string IdDivisi)
        {
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_Divisi_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IDDIVISI", IdDivisi);

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
    }
} 