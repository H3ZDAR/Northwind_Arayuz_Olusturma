using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

public class csNakliyeciler
{
    csBaglanti bag = new csBaglanti();

    public string ShipperID { get; set; }
    public string CompanyName { get; set; }
    public string Phone { get; set; }

    public csNakliyeciler()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int NakliyeciEkle()
    {
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_NakliyeciEkle";
        cmd.Parameters.AddWithValue("CompanyName", CompanyName);
        cmd.Parameters.AddWithValue("Phone", Phone);

        int result = cmd.ExecuteNonQuery();

        cmd.Dispose();
        con.Close();

        return result;
    }

    public int NakliyeciGuncelle()
    {
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_NakliyeciGuncelle";
        cmd.Parameters.AddWithValue("@shipperID", ShipperID);
        cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
        cmd.Parameters.AddWithValue("@Phone", Phone);

        cmd.ExecuteNonQuery();
        con.Close();
        return 1;
    }

    public int NakliyeciSil()
    {
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_NakliyeciSil";
        cmd.Parameters.AddWithValue("shipperid", ShipperID);

        cmd.ExecuteNonQuery();
        con.Close();
        return 1;
    }

    public DataTable Nakliyeciler()
    {
        DataTable dtb = new DataTable();
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_NakliyeciListesi";
        SqlDataAdapter adap = new SqlDataAdapter(cmd);
        adap.Fill(dtb);
        con.Close();
        return dtb;
    }

    public DataTable NakliyeciBilgiIdyeGore()
    {
        DataTable dtb = new DataTable();
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("shipperid ", ShipperID);
        cmd.CommandText = "SP_NakliyeciBilgi";
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

    public DataTable NakliyeciListesiAra(string aramaKelimesi)
    {
        DataTable dtb = new DataTable();
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_NakliyeciListesiAra";
        cmd.Parameters.AddWithValue("AramaKelimesi", aramaKelimesi);
        SqlDataAdapter adap = new SqlDataAdapter(cmd);
        adap.Fill(dtb);
        con.Close();
        return dtb;
    }
}
