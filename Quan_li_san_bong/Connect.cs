using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Quan_li_san_bong
{
    public class Connect
    {
        private SqlConnection con;
        private string strConnect, strServerName, strDataBaseName;
        private DataSet dataSet;


        public void DbConnection()
        {
            strServerName= "DESKTOP-FNK1E3U";
            strDataBaseName = "quan_li_san_bong_sql";
            strConnect = @"Data Source=DESKTOP-FNK1E3U;Initial Catalog=quan_li_san_bong_sql;Integrated Security=True";
            con= new SqlConnection(strConnect);
            dataSet = new DataSet(strDataBaseName);
            
        }
        public void openConnection()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
        }
        public void closeConnection()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }

        public void disposeConnection()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Dispose();
        }

        public void updateToDataBase(string sql)
        {
            openConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            closeConnection();
        }
        public int getCount(string sql)
        {
            openConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            int count = (int)cmd.ExecuteScalar();
            closeConnection();
            return count;
        }

        public bool checkForExistence(string sql)
        {
            return getCount(sql) > 0 ? true : false;
        }

        public SqlDataAdapter getDataReader(string sql,string table)
        {
            openConnection();
            SqlDataAdapter ada = new SqlDataAdapter(sql, con);
            ada.Fill(dataSet, table);
            closeConnection();
            return ada;
        }

        public DataTable getDataTable(string sql)
        {
            openConnection();
            SqlDataAdapter ada = new SqlDataAdapter(sql, con);
            DataTable da = new DataTable();
            ada.Fill(da);
            closeConnection();
            return da;
        }
        public DataTable getDataTable(string sql, string table)
        {
            openConnection();
            SqlDataAdapter ada = new SqlDataAdapter(sql, con);
            ada.Fill(dataSet, table);
            closeConnection();
            return dataSet.Tables[table];
        }
    }
}
