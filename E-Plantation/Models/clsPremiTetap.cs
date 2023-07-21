using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace E_Plantation.Models
{
    public class clsPremiTetap
    {
        public int IdPremiTetap { get; set; }
        public string GroupPremi { get; set; }
        public string NamaPremi { get; set; }
        public string Keterangan { get; set; }
        public string CreateUser { get; set; }
    }



    public class clsPremiTetapDB
    {
        string constr = _DBConnection.SCC;

        public List<clsPremiTetap> List()
        {
            List<clsPremiTetap> modelList = new List<clsPremiTetap>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string q = "sp_PremiTetap_GetList";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    clsPremiTetap model = new clsPremiTetap();
                    model.IdPremiTetap = Convert.ToInt32(rd["IdPremiTetap"].ToString()); 
                    model.GroupPremi = rd["GroupPremi"].ToString();
                    model.NamaPremi = rd["NamaPremi"].ToString();
                    model.Keterangan = rd["Keterangan"].ToString(); 
                    model.CreateUser = rd["CreateUser"].ToString();

                    modelList.Add(model);
                }
                con.Close();
                return modelList;
            }
        }
        //public int Insert(clsMSDepartment model, string userlogin)
        public int Insert(clsPremiTetap model)
        {
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_PremiTetap_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure; 
                cmd.Parameters.AddWithValue("GroupPremi", model.GroupPremi);
                cmd.Parameters.AddWithValue("NamaPremi", model.NamaPremi);
                cmd.Parameters.AddWithValue("Keterangan", model.Keterangan); 
                cmd.Parameters.AddWithValue("CREATEUSER", "");

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
        public int Update(clsPremiTetap model)
        {
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_PremiTetap_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdPremiTetap", model.IdPremiTetap);
                cmd.Parameters.AddWithValue("GroupPremi", model.GroupPremi);
                cmd.Parameters.AddWithValue("NamaPremi", model.NamaPremi);
                cmd.Parameters.AddWithValue("Keterangan", model.Keterangan);
                cmd.Parameters.AddWithValue("CREATEUSER", "");

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
        public int Delete(string IdPremiTetap)
        {
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_PremiTetap_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdPremiTetap", IdPremiTetap);

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }

    }

}