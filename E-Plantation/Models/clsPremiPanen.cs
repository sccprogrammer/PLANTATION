using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;


namespace E_Plantation.Models
{
    public class clsPremiPanen
    {
        public string KodePremiPanen { get; set; }
        public string Divisi { get; set; }
        public string TahunTanam { get; set; }
        public int BTHariBiasa { get; set; }
        public int BTHariJumat { get; set; }
        public int HLebihBasis { get; set; }
        public int HKurangBasis { get; set; }
        public string CreateUser { get; set; }
    }
    public class clsPremiPanenDB
    {
        string constr = _DBConnection.SCC;

        public List<clsPremiPanen> List()
        {
            List<clsPremiPanen> modelList = new List<clsPremiPanen>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string q = "sp_PremiPanen_GetList";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    clsPremiPanen model = new clsPremiPanen();
                    model.KodePremiPanen = rd["KodePremiPanen"].ToString();
                    model.Divisi = rd["Divisi"].ToString();
                    model.TahunTanam = rd["TahunTanam"].ToString();
                    model.BTHariBiasa = Convert.ToInt32(rd["BTHariBiasa"].ToString());
                    model.BTHariJumat = Convert.ToInt32(rd["BTHariJumat"].ToString());
                    model.HLebihBasis = Convert.ToInt32(rd["HLebihBasis"].ToString());
                    model.HKurangBasis = Convert.ToInt32(rd["HKurangBasis"].ToString());
                    model.CreateUser = rd["CreateUser"].ToString();

                    modelList.Add(model);
                }
                con.Close();
                return modelList;
            }
        }
        //public int Insert(clsMSDepartment model, string userlogin)
        public int Insert(clsPremiPanen model)
        {
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_PremiPanen_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("KodePremiPanen", model.KodePremiPanen);
                cmd.Parameters.AddWithValue("Divisi", model.Divisi); 
                cmd.Parameters.AddWithValue("TahunTanam", model.TahunTanam);
                cmd.Parameters.AddWithValue("BTHariBiasa", model.BTHariBiasa);
                cmd.Parameters.AddWithValue("BTHariJumat", model.BTHariJumat);
                cmd.Parameters.AddWithValue("HLebihBasis", model.HLebihBasis);
                cmd.Parameters.AddWithValue("HkurangBasis", model.HKurangBasis);
                cmd.Parameters.AddWithValue("CREATEUSER", "");

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
        public int Update(clsPremiPanen model)
        {
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_PremiPanen_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("KodePremiPanen", model.KodePremiPanen);
                cmd.Parameters.AddWithValue("Divisi", model.Divisi);
                cmd.Parameters.AddWithValue("TahunTanam", model.TahunTanam);
                cmd.Parameters.AddWithValue("BTHariBiasa", model.BTHariBiasa);
                cmd.Parameters.AddWithValue("BTHariJumat", model.BTHariJumat);
                cmd.Parameters.AddWithValue("HLebihBasis", model.HLebihBasis);
                cmd.Parameters.AddWithValue("HkurangBasis", model.HKurangBasis);
                cmd.Parameters.AddWithValue("CREATEUSER", "");

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }
        public int Delete(string KodePremiPanen)
        {
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_PremiPanen_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("KodePremiPanen", KodePremiPanen);

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }

    }
}