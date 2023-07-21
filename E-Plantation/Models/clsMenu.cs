using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace E_Plantation.Models
{
    public class clsMenu
    {
        public int idMenu { get; set; }
        public string NamaMenu { get; set; }
        public string KeteranganMenu{ get; set; }
        public string GrupMenu{ get; set; }
        public int StatusAkses { get; set; }
        public int StatusUpdate{ get; set; }
        public int StatusSpesial { get; set; }
        public string MenuLink { get; set; }
    }

    public class clsMenuDb
    {
        string constr = _DBConnection.SCC;
        public IEnumerable<clsMenu> ListMenu(string UserId)
        { 
            List<clsMenu> Menus = new List<clsMenu>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_ListMenu", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("UserID", UserId);
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    clsMenu Menu = new clsMenu();
                    Menu.idMenu = Convert.ToInt16(rd["IDMENU"]);
                    Menu.NamaMenu = rd["NAMAMENU"].ToString();
                    Menu.KeteranganMenu = rd["KETERANGANMENU"].ToString();
                    Menu.MenuLink = rd["MENULINK"].ToString();
                    Menu.GrupMenu = rd["GRUPMENU"].ToString();

                    Menu.StatusAkses = Convert.ToInt16(rd["STATUSAKSES"]);
                    Menu.StatusUpdate = Convert.ToInt16(rd["STATUSUPDATE"]);
                    Menu.StatusSpesial = Convert.ToInt16(rd["STATUSSPESIAL"]);
                    Menus.Add(Menu);
                }
                con.Close();
                return Menus;
            }
        }


    }
}