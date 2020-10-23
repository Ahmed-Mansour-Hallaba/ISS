using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
public class SqlMethods : Sql_Con
{

    public object sqlExecute(string procName, string parameters)
    {
        return new SqlCommand("exec " + procName + " " + parameters + "", sql).ExecuteScalar();
    }
    public object sqlExecute(string query)
    {
        return (new SqlCommand("" + query + "", sql).ExecuteScalar());
    }

    public object query(string query)
    {
        return new SqlCommand("" + query + "", sql).ExecuteScalar();
    }
    public SqlCommand command(string query)
    {
        SqlCommand cmd = new SqlCommand(query, sql);
        return cmd;
    }
    public SqlDataAdapter sqlDataAdapter(string procName, string parameters)
    {
        SqlDataAdapter t = new SqlDataAdapter("exec " + procName + " " + parameters + "", sql);

        return t;
    }
}
