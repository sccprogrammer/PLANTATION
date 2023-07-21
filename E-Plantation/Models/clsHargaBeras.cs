using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;


namespace E_Plantation.Models
{
    public class clsHargaBeras
    {
        public int HargaBeras { get; set; }
    }
    public class clsHargaBerasDB
    {
        string constr = _DBConnection.SCC;

        public List<clsHargaBeras> List()
        {
            List<clsHargaBeras> modelList = new List<clsHargaBeras>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string q = "sp_HargaBeras_GetList";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.CommandType = CommandType.StoredProcedure; 
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    clsHargaBeras model = new clsHargaBeras();
                    model.HargaBeras = Convert.ToInt32(rd["HargaBeras"].ToString()); 

                    modelList.Add(model);
                }
                con.Close();
                return modelList;
            }
        }
    }
}