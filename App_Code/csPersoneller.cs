using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlTypes;
using System.Drawing;
using System.Net;

public class csPersoneller
{
    csBaglanti bag = new csBaglanti();

    public int EmployeeID { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Title { get; set; }
    public string TitleOfCourtesy { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime HireDate { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string HomePhone { get; set; }
    public string Extension { get; set; }
    public byte[] PictureBytes { get; set; }
    public string Photo { get; set; }
    public string Notes { get; set; }
    public int ReportsTo { get; set; }
    public string PhotoPath { get; set; }

    public csPersoneller()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int PersonelEkle()
    {
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_PersonelEkle";

        cmd.Parameters.AddWithValue("LastName", LastName);
        cmd.Parameters.AddWithValue("FirstName", FirstName);
        cmd.Parameters.AddWithValue("Title", Title);
        cmd.Parameters.AddWithValue("TitleOfCourtesy", TitleOfCourtesy);
        cmd.Parameters.AddWithValue("BirthDate", new SqlDateTime(DateTime.Today));
        cmd.Parameters.AddWithValue("HireDate", HireDate);
        cmd.Parameters.AddWithValue("Address", Address);
        cmd.Parameters.AddWithValue("City", City);
        cmd.Parameters.AddWithValue("Region", Region);
        cmd.Parameters.AddWithValue("PostalCode", PostalCode);
        cmd.Parameters.AddWithValue("Country", Country);
        cmd.Parameters.AddWithValue("HomePhone", HomePhone);
        cmd.Parameters.AddWithValue("Extension", Extension);
        cmd.Parameters.AddWithValue("Photo", PictureBytes);
        cmd.Parameters.AddWithValue("Notes", Notes);
        cmd.Parameters.AddWithValue("ReportsTo", ReportsTo);

        cmd.ExecuteNonQuery();
        con.Close();
        return 1;
    }

    public int PersonelGuncelle()
    {
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_PersonelGuncelle";

        cmd.Parameters.AddWithValue("EmployeeID", EmployeeID);
        cmd.Parameters.AddWithValue("LastName", LastName);
        cmd.Parameters.AddWithValue("FirstName", FirstName);
        cmd.Parameters.AddWithValue("Title", Title);
        cmd.Parameters.AddWithValue("TitleOfCourtesy", TitleOfCourtesy);
        cmd.Parameters.AddWithValue("BirthDate", new SqlDateTime(DateTime.Today));
        cmd.Parameters.AddWithValue("HireDate", HireDate);
        cmd.Parameters.AddWithValue("Address", Address);
        cmd.Parameters.AddWithValue("City", City);
        cmd.Parameters.AddWithValue("Region", Region);
        cmd.Parameters.AddWithValue("PostalCode", PostalCode);
        // @Country parametresinin değerini kontrol et
        if (string.IsNullOrEmpty(Country))
        {
            cmd.Parameters.AddWithValue("@Country", DBNull.Value);
        }
        else
        {
            cmd.Parameters.AddWithValue("@Country", Country);
        }
        cmd.Parameters.AddWithValue("HomePhone", HomePhone);
        cmd.Parameters.AddWithValue("Extension", Extension);
        //cmd.Parameters.AddWithValue("Photo", PictureBytes);
        cmd.Parameters.AddWithValue("Notes", Notes);
        //cmd.Parameters.AddWithValue("ReportsTo", ReportsTo);

        cmd.ExecuteNonQuery();
        con.Close();
        return 1;
    }

    public int PersonelSil()
    {
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_PersonelSil";
        cmd.Parameters.AddWithValue("EmployeeID", EmployeeID);

        cmd.ExecuteNonQuery();
        con.Close();
        return 1;
    }

    public DataTable Personeller()
    {
        DataTable dtb = new DataTable();
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_PersonelListesi";
        SqlDataAdapter adap = new SqlDataAdapter(cmd);
        adap.Fill(dtb);
        con.Close();
        return dtb;
    }

    public DataTable PersonelBilgiIdyeGore()
    {
        DataTable dtb = new DataTable();
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "Sp_PersonelBilgi";

        cmd.Parameters.AddWithValue("EmployeeID", EmployeeID);
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

    public DataTable PersonelListesiAra(string aramaKelimesi)
    {
        DataTable dtb = new DataTable();
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_PersonelListesiAra";
        cmd.Parameters.AddWithValue("AramaKelimesi", aramaKelimesi);
        SqlDataAdapter adap = new SqlDataAdapter(cmd);
        adap.Fill(dtb);
        con.Close();
        return dtb;
    }
}
