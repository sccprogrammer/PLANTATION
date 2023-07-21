using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace E_Plantation.Models
{
    public class clsMartial
    {
        public int IdMartial{ get; set; }
        public string KodeMartial { get; set; }
        public string NamaMartial { get; set; }
    }

    public class clsMartialDB
    {
        string constr = _DBConnection.SCCOFFICE;

        public List<clsMartial> List()
        {
            List<clsMartial> modelList = new List<clsMartial>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string q = "sp_MartialStatus_GetList";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    clsMartial model = new clsMartial();
                    model.IdMartial = Convert.ToInt32(rd["IdMartial"].ToString());
                    model.KodeMartial = rd["KodeMartial"].ToString();
                    model.NamaMartial = rd["NamaMartial"].ToString();

                    modelList.Add(model);
                }
                con.Close();
                return modelList;
            }
        }
    }
}