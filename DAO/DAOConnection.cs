using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Author: Paul Stuart, Jinghua Zhong, Jaiwei Huang
/// Date Created: 29/10/2021
/// </summary>

namespace spsModel.DAO
{
    public static class DAOConnection
    {
        
        // Local Connection for Development purposes
        public static SqlConnection GetSQLConnectLocal()
        {
             //SqlConnection sqlConnectionLocal = new SqlConnection(@"Data Source=DESKTOP-H28HRIT;Initial Catalog=db_tafebuddy;Integrated Security=True"); // Paul Desktop
              SqlConnection sqlConnectionLocal = new SqlConnection(@"Data Source=DESKTOP-NC7A3T6;Initial Catalog=db_tafebuddy;Integrated Security=True"); // Paul Laptop
           // SqlConnection sqlConnectionLocal = new SqlConnection(@"Data Source=sps2021.database.windows.net;Initial Catalog=db_tafebuddy;User ID=TafeSaSps2021;Password=Tafesa2021;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");// Jiawei Azure
            return sqlConnectionLocal;
        }

        // Live Connection when Deployed
        public static SqlConnection GetSQLConnectServer()
        {
            SqlConnection sqlConnectionServer = new SqlConnection("");
            return sqlConnectionServer;
        }

    }
}
