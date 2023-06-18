using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

public class csMusteriler
{
    csBaglanti bag = new csBaglanti();

    public csMusteriler()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string CustomerID { get; set; }
    public string CompanyName { get; set; }
    public string ContactName { get; set; }
    public string ContactTitle { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }


    public int MusteriEkle()
    {
        using (SqlConnection con = bag.con())
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_MusteriEkle";
            cmd.Parameters.AddWithValue("customerId", CustomerID);
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
                cmd.Parameters.AddWithValue("Country", false);
            }

            cmd.Parameters.AddWithValue("Phone", Phone);
            cmd.Parameters.AddWithValue("Fax", Fax);

            int result = cmd.ExecuteNonQuery();

            cmd.Dispose();
            con.Close();

            return result;
        }
    }

    //public int MusteriGuncelle()
    //{
    //    using (SqlConnection con = bag.con())
    //    {
    //        con.Open();
    //        SqlCommand cmd = con.CreateCommand();
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.CommandText = "SP_MusteriGuncelle";
    //        cmd.Parameters.AddWithValue("customerId", CustomerID);
    //        cmd.Parameters.AddWithValue("CompanyName", CompanyName);
    //        cmd.Parameters.AddWithValue("ContactName", ContactName);
    //        cmd.Parameters.AddWithValue("ContactTitle", ContactTitle);
    //        cmd.Parameters.AddWithValue("Address", Address);
    //        cmd.Parameters.AddWithValue("City", City);
    //        cmd.Parameters.AddWithValue("Region", Region);
    //        cmd.Parameters.AddWithValue("PostalCode", PostalCode);

    //        bool countryValue;
    //        if (bool.TryParse(Country, out countryValue))
    //        {
    //            cmd.Parameters.AddWithValue("Country", countryValue);
    //        }
    //        else
    //        {
    //            // Burada, Country değeri bool türüne dönüştürülemediği için default olarak false değerini atıyoruz.
    //            cmd.Parameters.AddWithValue("Country", false);
    //        }

    //        cmd.Parameters.AddWithValue("Phone", Phone);
    //        cmd.Parameters.AddWithValue("Fax", Fax);

    //        cmd.ExecuteNonQuery();
    //        con.Close();
    //        return 1;
    //    }
    //}
    public int MusteriGuncelle()
    {
        using (SqlConnection con = bag.con())
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_MusteriGuncelle";
            cmd.Parameters.AddWithValue("CustomerID", CustomerID);
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
                cmd.Parameters.AddWithValue("Country", Country);
            }

            cmd.Parameters.AddWithValue("Phone", Phone);
            cmd.Parameters.AddWithValue("Fax", Fax);

            int result = cmd.ExecuteNonQuery();

            cmd.Dispose();
            con.Close();

            return result;
        }
    }


    public int MusteriSil()
    {
        using (SqlConnection con = bag.con())
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_MusteriSil";
            cmd.Parameters.AddWithValue("customerId", CustomerID);

            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
    }

    public DataTable Musteriler()
    {
        DataTable dtb = new DataTable();
        using (SqlConnection con = bag.con())
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_MusteriListesi";
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(dtb);
            con.Close();
        }
        return dtb;
    }

    public DataTable MusteriBilgiIdyeGore()
    {
        DataTable dtb = new DataTable();
        using (SqlConnection con = bag.con())
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerId", CustomerID);
            cmd.CommandText = "Sp_MusteriBilgi";

            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(dtb);
            con.Close();
        }
        return dtb;
    }

    public void dropDoldur(DropDownList ddr, string DisplayMemeber, string ValueMemeber, string sp)
    {
        DataTable dtb = new DataTable();
        using (SqlConnection con = bag.con())
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp;
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(dtb);
            con.Close();
        }
        ddr.DataSource = dtb;
        ddr.DataTextField = DisplayMemeber;
        ddr.DataValueField = ValueMemeber;
        ddr.DataBind();
    }

    public DataTable MusteriListesiAra(string aramaKelimesi)
    {
        DataTable dtb = new DataTable();
        using (SqlConnection con = bag.con())
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_MusteriListesiAra";
            cmd.Parameters.AddWithValue("AramaKelimesi", aramaKelimesi);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(dtb);
            con.Close();
        }
        return dtb;
    }
}
