using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient; 

namespace E_Plantation.Models
{
    public class clsGradeCode
    {
        public string KodeTipeGrade { get; set; }
        public string TipeGrade { get; set; }
    }
    public class clsGradeCodeDB
    {
        string constr = _DBConnection.SCCOFFICE;
        public List<clsGradeCode> List()
        {
            List<clsGradeCode> modelList = new List<clsGradeCode>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string q = "sp_GradeCode_GetList";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    clsGradeCode model = new clsGradeCode();
                    model.KodeTipeGrade = rd["KodeTipeGrade"].ToString();
                    model.TipeGrade = rd["TipeGrade"].ToString();

                    modelList.Add(model);
                }
                con.Close();
                return modelList;
            }
        }
    }
}