using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using spsModel.DAO;
using Label = System.Web.UI.WebControls.Label;

/// <summary>
/// Author: Paul Stuart
/// Date Created: 1/09/2021
/// </summary>

namespace spsModel
{
    public static class DAO_SPS
    {

        // Generic Query Handler ---------------------------------------------------
        public static SqlCommand ExecuteQuery(string query)
        {         
            using (SqlConnection con = DAOConnection.GetSQLConnectLocal())
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return null;
        }

        // Retrieve Table Data, use this for in-memory retrieval of a Single Table in a Database, any query can run through this ---------------------------------------------------
        public static DataTable GetDataTableRecord(string query)
        {
            using (SqlConnection con = DAOConnection.GetSQLConnectLocal())
            {
             SqlCommand cmd = con.CreateCommand();
             con.Open();
             cmd.CommandType = CommandType.Text;
             cmd.CommandText = query;
             cmd.ExecuteNonQuery();
             DataTable dt = new DataTable();
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             da.Fill(dt);
             con.Close();
             return dt;
            }         
        }

        // Retrieve Single Cell Value as String ---------------------------------------------------
        public static string  GetDataSingleValue(string query)
        {
            string returnString;
            using (SqlConnection con = DAOConnection.GetSQLConnectLocal())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                returnString = cmd.ExecuteScalar().ToString();            
                con.Close();
                return returnString;
            }
        }

         // Data Display to the Grid View, can use for any query and any gridview, applicable to Web Controls ---------------------------------------------------
         public static void DisplayGVData(string query, GridView gridView)
        {
            using (SqlConnection con = DAOConnection.GetSQLConnectLocal())
            {
                SqlCommand cmd = con.CreateCommand();
                con.Open(); 
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                gridView.DataSource = dt;
                gridView.DataBind();
                con.Close();
            }
        }

        // Return a Full DataSet Object from the Database, this has multiple Tables and is much bigger than DataTable ---------------------------------------------------
        public static DataSet GetDataSet(string query) // **** HAVE NOT TESTED YET MIGHT NOT WORK **//
        {         
            using (SqlConnection con = DAOConnection.GetSQLConnectLocal())
            {
                SqlCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
                return ds;
            }
        }

      

       







    }
}
