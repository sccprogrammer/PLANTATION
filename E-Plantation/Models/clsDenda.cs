using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace E_Plantation.Models
{

    public class clsDenda
    {
        public int IdDenda { get; set; }
        public string TipeDenda { get; set; }
        public string BiayaDenda { get; set; }
        public string KeteranganDenda { get; set; }
        public string StatusDenda { get; set; }
    }


    public class clsDendaDB
    {
        string constr = _DBConnection.SCC;
        public List<clsDenda> List()
        {
            List<clsDenda> modelList = new List<clsDenda>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string q = "sp_Denda_GetList";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    clsDenda model = new clsDenda();
                    model.IdDenda = Convert.ToInt32(rd["IdDenda"].ToString());
                    model.TipeDenda = rd["TipeDenda"].ToString();
                    model.BiayaDenda = rd["BiayaDenda"].ToString();
                    model.KeteranganDenda = rd["KeteranganDenda"].ToString();
                    model.StatusDenda = rd["StatusDenda"].ToString();

                    modelList.Add(model);
                }
                con.Close();
                return modelList;
            }
        }

        //public int Insert(clsMSDepartment model, string userlogin)
        public int Insert(clsDenda model)
        {
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_Denda_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("TipeDenda", model.TipeDenda);
                cmd.Parameters.AddWithValue("BiayaDenda", model.BiayaDenda);
                cmd.Parameters.AddWithValue("KeteranganDenda", model.KeteranganDenda);
                cmd.Parameters.AddWithValue("StatusDenda", model.StatusDenda);

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
        public int Update(clsDenda model)
        {
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_Denda_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdDenda", model.IdDenda);
                cmd.Parameters.AddWithValue("TipeDenda", model.TipeDenda);
                cmd.Parameters.AddWithValue("BiayaDenda", model.BiayaDenda);
                cmd.Parameters.AddWithValue("KeteranganDenda", model.KeteranganDenda);
                cmd.Parameters.AddWithValue("StatusDenda", model.StatusDenda);

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
        public int Delete(string IdDenda)
        {
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_Denda_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdDenda", IdDenda);

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
    }
}