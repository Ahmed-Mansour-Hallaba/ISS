using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


public class Sql_Con
{
    public SqlConnection sql = new SqlConnection(@"Data Source=.;Initial Catalog=v9.2;Integrated Security=True");
    public Sql_Con() { sql.Open(); }

    public System.Data.ConnectionState getsql()
    {
        return sql.State;
    }
    public void sqlOpen()
    {
        sql.Open();
    }
    public void sqlClose()
    {
        sql.Close();
    }


}
