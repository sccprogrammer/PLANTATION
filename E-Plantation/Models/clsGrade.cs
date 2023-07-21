using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient; 

namespace E_Plantation.Models
{
    public class clsGrade
    {
        public int IdMasterGrade { get; set; }
        public string GradeCode { get; set; }
        public string GajiPokok { get; set; } 
    }


    public class clsGradeDB
    {
        string constr = _DBConnection.SCC;
        public List<clsGrade> List()
        {
            List<clsGrade> modelList = new List<clsGrade>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string q = "sp_Grade_GetList";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    clsGrade model = new clsGrade();
                    model.IdMasterGrade = Convert.ToInt32(rd["IdMasterGrade"].ToString());
                    model.GradeCode = rd["GradeCode"].ToString(); 
                    model.GajiPokok = rd["GajiPokok"].ToString();

                    modelList.Add(model);
                }
                con.Close();
                return modelList;
            }
        }

        //public int Insert(clsMSDepartment model, string userlogin)
        public int Insert(clsGrade model)
        {
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_Grade_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("GradeCode", model.GradeCode);
                cmd.Parameters.AddWithValue("GajiPokok", model.GajiPokok); 

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
        public int Update(clsGrade model)
        {
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_Grade_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdMasterGrade", model.IdMasterGrade);
                cmd.Parameters.AddWithValue("GradeCode", model.GradeCode);
                cmd.Parameters.AddWithValue("GajiPokok", model.GajiPokok);

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
        public int Delete(string IdMasterGrade)
        {
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_Grade_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdMasterGrade", IdMasterGrade);

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }


    }
}