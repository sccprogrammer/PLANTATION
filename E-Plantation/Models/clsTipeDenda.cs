using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration; 

namespace E_Plantation.Models
{
    public class clsTipeDenda
    {
        public int IdTipeDenda { get; set; }
        public string TipeDenda { get; set; } 
    }


    public class clsTipeDendaDB
    {
        string constr = _DBConnection.SCC;
        public List<clsTipeDenda> List()
        { 
            List<clsTipeDenda> modelList = new List<clsTipeDenda>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string q = "sp_TipeDenda_GetList";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    clsTipeDenda model = new clsTipeDenda();
                    model.IdTipeDenda = Convert.ToInt32(rd["IdTipeDenda"].ToString());
                    model.TipeDenda = rd["TipeDenda"].ToString(); 

                    modelList.Add(model);
                }
                con.Close();
                return modelList;
            }
        }

        //public int Insert(clsMSDepartment model, string userlogin)
        public int Insert(clsTipeDenda model)
        { 
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_TipeDenda_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("TipeDenda", model.TipeDenda); 

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
        public int Update(clsTipeDenda model)
        { 
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_TipeDenda_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdTipeDenda", model.IdTipeDenda);
                cmd.Parameters.AddWithValue("TipeDenda", model.TipeDenda); 

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
        public int Delete(string IdTipeDenda)
        {  
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_TipeDenda_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdTipeDenda", IdTipeDenda);

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
    }
}