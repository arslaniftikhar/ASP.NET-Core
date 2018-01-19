using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace WebApplication1.Library.DAL
{
    class DatabaseClass
    {
        public string ConnectionString { get; set; }

        public SqlConnection sqlConnection { get; set; }

        public SqlCommand sqlCommand { get; set; }

        public DatabaseClass()
        {
            this.ConnectionString = "Data Source=DESKTOP-51UD4CL;Initial Catalog=ClassPractice;User Id=sa;Password=abc123";
            sqlConnection = new SqlConnection(this.ConnectionString);
            
        } 
        public void Query(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, this.sqlConnection);
            this.sqlCommand = cmd;
        }
    }
}
