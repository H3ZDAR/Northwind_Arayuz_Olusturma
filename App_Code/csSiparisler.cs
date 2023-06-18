using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Data.SqlTypes;
using System.Security.Policy;

/// <summary>
/// Summary description for csSiparisler
/// </summary>
public class csSiparisler
{
    csBaglanti bag = new csBaglanti();
	
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public int EmployeeID { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime RequiredDate { get; set; }
    public DateTime ShippedDate { get; set; }
    public string ShipVia { get; set; }
    public string Freight { get; set; }
    public string ShipName { get; set; }
    public string ShipAddress { get; set; }
    public string ShipCity { get; set; }
    public string ShipRegion { get; set; }
    public int ShipPostalCode { get; set; }
    public string ShipCountry { get; set; }


    public int SiparisEkle()
    {
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_SiparisEkle";
        cmd.Parameters.AddWithValue("CustomerID", CustomerID);
        cmd.Parameters.AddWithValue("EmployeeID", EmployeeID);
        cmd.Parameters.AddWithValue("OrderDate", new SqlDateTime(DateTime.Today));
        cmd.Parameters.AddWithValue("RequiredDate", RequiredDate);
        cmd.Parameters.AddWithValue("ShippedDate", ShippedDate);
        cmd.Parameters.AddWithValue("ShipVia", ShipVia);
        cmd.Parameters.AddWithValue("Freight", Freight);
        cmd.Parameters.AddWithValue("ShipName", ShipName);
        cmd.Parameters.AddWithValue("ShipAddress", ShipAddress);
        cmd.Parameters.AddWithValue("ShipCity", ShipVia);
        cmd.Parameters.AddWithValue("ShipRegion", Freight);
        cmd.Parameters.AddWithValue("ShipPostalCode", ShipName);
        cmd.Parameters.AddWithValue("ShipCountry ", ShipCountry);

        cmd.ExecuteNonQuery();
        con.Close();
        return 1;
    }


public int SiparisGuncelle()
    {
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_SiparisGuncelle";

    //cmd.Parameters.AddWithValue("OrderID", OrderID);
    cmd.Parameters.AddWithValue("CustomerID", CustomerID);
    cmd.Parameters.AddWithValue("EmployeeID", EmployeeID);
    cmd.Parameters.AddWithValue("OrderDate", DateTime.Today); // Geçerli bir tarih değeri
    cmd.Parameters.AddWithValue("RequiredDate", RequiredDate);
    cmd.Parameters.AddWithValue("ShippedDate", ShippedDate);
    cmd.Parameters.AddWithValue("ShipVia", ShipVia);
    cmd.Parameters.AddWithValue("Freight", Freight);
    cmd.Parameters.AddWithValue("ShipName", ShipName);
    cmd.Parameters.AddWithValue("ShipAddress", ShipAddress);
    cmd.Parameters.AddWithValue("ShipCity", ShipVia);
    cmd.Parameters.AddWithValue("ShipRegion", Freight);
    cmd.Parameters.AddWithValue("ShipPostalCode", ShipName);
    cmd.Parameters.AddWithValue("ShipCountry ", ShipCountry);

    cmd.ExecuteNonQuery();
        con.Close();
        return 1;

    }

    public DataTable Siparisler()
    {
        DataTable dtb = new DataTable();
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_SiparisListesi";
        SqlDataAdapter adap = new SqlDataAdapter(cmd);
        adap.Fill(dtb);
        con.Close();
        return dtb;

    }

    public DataTable SiparisBilgiIdyeGore()
    {
        DataTable dtb = new DataTable();
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "sp_yenisiparisbilgi";

        cmd.Parameters.AddWithValue("@Orid", OrderID);
        SqlDataAdapter adap = new SqlDataAdapter(cmd);
        adap.Fill(dtb);
        con.Close();
        return dtb;
    
    }

    public void dropDoldur(DropDownList ddr, string DisplayMemeber, string ValueMemeber)
    {

        DataTable dtb = new DataTable();
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_GrupListesi";
        SqlDataAdapter adap = new SqlDataAdapter(cmd);
        adap.Fill(dtb);

        con.Close();
        ddr.DataSource = dtb;
        
        ddr.DataTextField = DisplayMemeber;
        ddr.DataValueField = ValueMemeber;
        ddr.DataBind();

    }
    public DataTable SiparisListesiAra(string aramaKelimesi)
    {
        DataTable dtb = new DataTable();
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_SiparisListesiAra";
        cmd.Parameters.AddWithValue("AramaKelimesi", aramaKelimesi);
        SqlDataAdapter adap = new SqlDataAdapter(cmd);
        adap.Fill(dtb);
        con.Close();
        return dtb;
    }

}