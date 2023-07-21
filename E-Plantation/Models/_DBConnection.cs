using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace E_Plantation.Models
{
    public class _DBConnection
    {
        public static string SCC = (ConfigurationManager.ConnectionStrings["PLAConnectionString"].ConnectionString);
        public static string SCCOFFICE = (ConfigurationManager.ConnectionStrings["OFFConnectionString"].ConnectionString);
    }
}