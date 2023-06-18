using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

public class csKategoriler
{
    csBaglanti bag = new csBaglanti();

    public int CategoryID { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
    public byte[] PictureBytes { get; set; }
    public string Picture { get; set; }

    public csKategoriler()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int KategoriEkle()
    {
        using (SqlConnection con = bag.con())
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_KategoriEkle";
            cmd.Parameters.AddWithValue("@CategoryName", CategoryName);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Picture", PictureBytes);

            return cmd.ExecuteNonQuery();
        }
    }

    public int KategoriGuncelle()
    {
        using (SqlConnection con = bag.con())
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_KategoriGuncelle";
            cmd.Parameters.AddWithValue("categoryId", CategoryID);
            cmd.Parameters.AddWithValue("CategoryName", CategoryName);
            cmd.Parameters.AddWithValue("description", Description);
            cmd.Parameters.AddWithValue("Picture", PictureBytes);

            return cmd.ExecuteNonQuery();
        }
    }

    public int KategoriSil()
    {
        using (SqlConnection con = bag.con())
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Kategorisil";
            cmd.Parameters.AddWithValue("CategoryId", CategoryID);

            return cmd.ExecuteNonQuery();
        }
    }

    public DataTable KategoriListesi()
    {
        DataTable dtb = new DataTable();
        using (SqlConnection con = bag.con())
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_KategoriListesi";
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(dtb);
        }
        return dtb;
    }

    public DataTable KategoriBilgiIdyeGore()
    {
        DataTable dtb = new DataTable();
        using (SqlConnection con = bag.con())
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_KategoriBilgi";
            cmd.Parameters.AddWithValue("CategoryId", CategoryID);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(dtb);
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
        }

        ddr.DataSource = dtb;
        ddr.DataTextField = DisplayMemeber;
        ddr.DataValueField = ValueMemeber;
        ddr.DataBind();
    }

    public DataTable KategoriListesiAra(string aramaKelimesi)
    {
        DataTable dtb = new DataTable();
        using (SqlConnection con = bag.con())
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_KategoriListesiAra";
            cmd.Parameters.AddWithValue("AramaKelimesi", aramaKelimesi);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(dtb);
        }
        return dtb;
    }
}
