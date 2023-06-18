using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;

/// <summary>
/// Summary description for csBaglanti
/// </summary>
public class csBaglanti
{
	public csBaglanti()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public SqlConnection con()
    {

        SqlConnection scon = new SqlConnection(@"Data Source=DESKTOP-CTV28SK\SQLEXPRESS; Initial Catalog=Northwind;Trusted_Connection=True;");

        return scon;
    }
}