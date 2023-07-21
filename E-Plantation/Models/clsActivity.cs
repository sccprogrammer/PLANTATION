using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace E_Plantation.Models
{ 
    public class clsActivity
    {
        public int IdActivity { get; set; }
        public string AccountGroup { get; set; }
        public string AccountType { get; set; }
        public string AccountName { get; set; }
    }


    public class clsActivityDB
    {
        string constr = _DBConnection.SCC;
        public List<clsActivity> List()
        { 
            List<clsActivity> modelList = new List<clsActivity>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string q = "sp_Activity_GetList";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    clsActivity model = new clsActivity();
                    model.IdActivity = Convert.ToInt32(rd["IdActivity"].ToString());
                    model.AccountGroup = rd["AccountGroup"].ToString();
                    model.AccountType = rd["AccountType"].ToString();
                    model.AccountName = rd["AccountName"].ToString();

                    modelList.Add(model);
                }
                con.Close();
                return modelList;
            }
        }

        //public int Insert(clsMSDepartment model, string userlogin)
        public int Insert(clsActivity model)
        { 
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_Activity_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure; 
                cmd.Parameters.AddWithValue("ACCOUNTGROUP", model.AccountGroup);
                cmd.Parameters.AddWithValue("ACCOUNTTYPE",  model.AccountType);
                cmd.Parameters.AddWithValue("ACCOUNTNAME", model.AccountName);

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
        public int Update(clsActivity model)
        { 
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_Activity_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdActivity", model.IdActivity);
                cmd.Parameters.AddWithValue("AccountGroup", model.AccountGroup);
                cmd.Parameters.AddWithValue("AccountType", model.AccountType);
                cmd.Parameters.AddWithValue("AccountName", model.AccountName);

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
        public int Delete(string IdActivity)
        { 
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_Activity_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdActivity", IdActivity);

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }


    }
}