using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

public class csTedarikciler
{
    csBaglanti bag = new csBaglanti();

    public int SupplierID { get; set; }
    public string CompanyName { get; set; }
    public string ContactName { get; set; }
    public string ContactTitle { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public int PostalCode { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string HomePage { get; set; }

    public csTedarikciler()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int TedarikciEkle()
    {
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_TedarikciEkle";

        cmd.Parameters.AddWithValue("CompanyName", CompanyName);
        cmd.Parameters.AddWithValue("ContactName", ContactName);
        cmd.Parameters.AddWithValue("ContactTitle", ContactTitle);
        cmd.Parameters.AddWithValue("Address", Address);
        cmd.Parameters.AddWithValue("City", City);
        cmd.Parameters.AddWithValue("Region", Region);
        cmd.Parameters.AddWithValue("PostalCode", PostalCode);

        bool countryValue;
        if (bool.TryParse(Country, out countryValue))
        {
            cmd.Parameters.AddWithValue("Country", countryValue);
        }
        else
        {
            cmd.Parameters.AddWithValue("Country", false); // Veya varsayılan bir değer
        }

        cmd.Parameters.AddWithValue("Phone", Phone);
        cmd.Parameters.AddWithValue("Fax", Fax);
        cmd.Parameters.AddWithValue("HomePage", HomePage);

        int result = cmd.ExecuteNonQuery();

        cmd.Dispose();
        con.Close();

        return result;
    }

    public int TedarikciGuncelle()
    {
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_TedarikciGuncelle";

        cmd.Parameters.AddWithValue("SupplierID", SupplierID);
        cmd.Parameters.AddWithValue("CompanyName", CompanyName);
        cmd.Parameters.AddWithValue("ContactName", ContactName);
        cmd.Parameters.AddWithValue("ContactTitle", ContactTitle);
        cmd.Parameters.AddWithValue("Address", Address);
        cmd.Parameters.AddWithValue("City", City);
        cmd.Parameters.AddWithValue("Region", Region);
        cmd.Parameters.AddWithValue("PostalCode", PostalCode.ToString());

        SqlParameter countryParam = new SqlParameter("Country", SqlDbType.Bit);
        bool countryValue;
        if (bool.TryParse(Country, out countryValue))
        {
            countryParam.Value = countryValue;
        }
        else
        {
            countryParam.Value = false; // Veya varsayılan bir değer
        }
        cmd.Parameters.Add(countryParam);

        cmd.Parameters.AddWithValue("Phone", Phone);
        cmd.Parameters.AddWithValue("Fax", Fax);
        cmd.Parameters.AddWithValue("HomePage", HomePage);

        cmd.ExecuteNonQuery();
        con.Close();
        return 1;
    }

    public int TedarikciSil()
    {
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_TedarikciSil";
        cmd.Parameters.AddWithValue("SupplierID", SupplierID);

        cmd.ExecuteNonQuery();
        con.Close();
        return 1;
    }

    public DataTable Tedarikciler()
    {
        DataTable dtb = new DataTable();
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_TedarikciListesi";
        SqlDataAdapter adap = new SqlDataAdapter(cmd);
        adap.Fill(dtb);
        con.Close();
        return dtb;
    }

    public DataTable TedarikciBilgiIdyeGore()
    {
        DataTable dtb = new DataTable();
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "Sp_TedarikciBilgi";

        cmd.Parameters.AddWithValue("SupplierID", SupplierID);
        SqlDataAdapter adap = new SqlDataAdapter(cmd);
        adap.Fill(dtb);
        con.Close();
        return dtb;
    }

    public void dropDoldur(DropDownList ddr, string DisplayMemeber, string ValueMemeber, string sp)
    {
        DataTable dtb = new DataTable();
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = sp;
        SqlDataAdapter adap = new SqlDataAdapter(cmd);
        adap.Fill(dtb);

        con.Close();
        ddr.DataSource = dtb;
        ddr.DataTextField = DisplayMemeber;
        ddr.DataValueField = ValueMemeber;
        ddr.DataBind();
    }

    public DataTable TedarikciListesiAra(string aramaKelimesi)
    {
        DataTable dtb = new DataTable();
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_TedarikciListesiAra";
        cmd.Parameters.AddWithValue("AramaKelimesi", aramaKelimesi);
        SqlDataAdapter adap = new SqlDataAdapter(cmd);
        adap.Fill(dtb);
        con.Close();
        return dtb;
    }
}
