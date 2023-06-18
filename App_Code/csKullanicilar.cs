using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for csKullaniclar
/// </summary>
public class csKullanicilar
{
    csBaglanti bag = new csBaglanti();
	public csKullanicilar()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public string Adi { get; set; }
    public string Soyadi { get; set; }
    public string Tel { get; set; }
    public string TC { get; set; }
    public string Sifre { get; set; }
    public int KullaniciID { get; set; }
    public int GrupID { get; set; }


    public int KullaniciEkle()
    {
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_KullanciEkle";
        cmd.Parameters.AddWithValue("GrupID", GrupID);
        cmd.Parameters.AddWithValue("Adi",Adi);
        cmd.Parameters.AddWithValue("Soyadi", Soyadi);
        cmd.Parameters.AddWithValue("Tel", Tel);
        cmd.Parameters.AddWithValue("TC", TC);
        cmd.Parameters.AddWithValue("Sifre",Sifre);
         cmd.Parameters.AddWithValue("IslemYapanKullaniciID", 1);
        cmd.Parameters.AddWithValue("@IslemYapanKullaniciIP","127.0.0.1");
        cmd.ExecuteNonQuery();
        con.Close();
        return 1;



        
    
    
    
    }

    public int KullaniciGuncelle()
    {
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_KullaniciGuncelle";
        cmd.Parameters.AddWithValue("KullaniciID", KullaniciID);
        cmd.Parameters.AddWithValue("GrupID", GrupID);
        cmd.Parameters.AddWithValue("Adi", Adi);
        cmd.Parameters.AddWithValue("Soyadi", Soyadi);
        cmd.Parameters.AddWithValue("Tel", Tel);
        cmd.Parameters.AddWithValue("TC", TC);
        cmd.Parameters.AddWithValue("Sifre", Sifre);
        cmd.Parameters.AddWithValue("IslemYapanKullaniciID", 1);
        cmd.Parameters.AddWithValue("@IslemYapanKullaniciIP", "127.0.0.1");
        cmd.ExecuteNonQuery();
        con.Close();
        return 1;







    }
    


    public DataTable Kullancilar()
    {
        DataTable dtb = new DataTable();
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_KullaniciListesi";
        SqlDataAdapter adap = new SqlDataAdapter(cmd);
        adap.Fill(dtb);
        con.Close();
        return dtb;

    
    }

    public DataTable KullaniciBilgiIdyeGore()
    {
        DataTable dtb = new DataTable();
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "Sp_KullaniciBilgi";

        cmd.Parameters.AddWithValue("KullaniciID",KullaniciID);
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












}