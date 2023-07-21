using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;


namespace E_Plantation.Models
{ 
    public class clsSetVariable
    {
        public int HargaBeras { get; set; }
    }


    public class clsSetVariableDB
    {
        string constr = _DBConnection.SCC;

        public List<clsSetVariable> List()
        {
            List<clsSetVariable> modelList = new List<clsSetVariable>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string q = "sp_SetVariable_GetList";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    clsSetVariable model = new clsSetVariable();
                    model.HargaBeras = Convert.ToInt32(rd["HargaBeras"].ToString()); 

                    modelList.Add(model);
                }
                con.Close();
                return modelList;
            }
        }
    }
}