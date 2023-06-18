using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

public class csUrunler
{
    csBaglanti bag = new csBaglanti();

    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public int SupplierID { get; set; }
    public int CategoryID { get; set; }
    public string QuantityPerUnit { get; set; }
    public string UnitPrice { get; set; }
    public string UnitsInStock { get; set; }
    public string UnitsOnOrder { get; set; }
    public string ReorderLevel { get; set; }
    public string Discontinued { get; set; }

    public csUrunler()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int UrunEkle()
    {
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_UrunEkle";

        cmd.Parameters.AddWithValue("ProductName", ProductName);
        cmd.Parameters.AddWithValue("SupplierID", SupplierID);
        cmd.Parameters.AddWithValue("CategoryID", CategoryID);
        cmd.Parameters.AddWithValue("QuantityPerUnit", QuantityPerUnit);
        cmd.Parameters.AddWithValue("UnitPrice", UnitPrice);
        cmd.Parameters.AddWithValue("UnitsInStock", UnitsInStock);
        cmd.Parameters.AddWithValue("UnitsOnOrder", UnitsOnOrder);
        cmd.Parameters.AddWithValue("ReorderLevel", ReorderLevel);
        cmd.Parameters.AddWithValue("Discontinued", false);

        cmd.ExecuteNonQuery();
        con.Close();
        return 1;
    }

    public int UrunGuncelle()
    {
        using (SqlConnection con = bag.con())
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_UrunGuncelle";

            //cmd.Parameters.AddWithValue("ProductID", ProductID); // Güncellenmek istenen ürünün ID'si

            // Diğer güncellenecek parametreler
            cmd.Parameters.AddWithValue("ProductName", ProductName);
            cmd.Parameters.AddWithValue("SupplierID", SupplierID);
            cmd.Parameters.AddWithValue("CategoryID", CategoryID);
            cmd.Parameters.AddWithValue("QuantityPerUnit", QuantityPerUnit);
            cmd.Parameters.AddWithValue("UnitPrice", UnitPrice);
            cmd.Parameters.AddWithValue("UnitsInStock", UnitsInStock);
            cmd.Parameters.AddWithValue("UnitsOnOrder", UnitsOnOrder);
            cmd.Parameters.AddWithValue("ReorderLevel", ReorderLevel);
            cmd.Parameters.AddWithValue("Discontinued", false);

            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
    }


    public int UrunSil()
    {
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_UrunSil";
        cmd.Parameters.AddWithValue("ProductID", ProductID);

        cmd.ExecuteNonQuery();
        con.Close();
        return 1;
    }

    public DataTable Urunler()
    {
        DataTable dtb = new DataTable();
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_UrunListesi";
        SqlDataAdapter adap = new SqlDataAdapter(cmd);
        adap.Fill(dtb);
        con.Close();
        return dtb;
    }

    public DataTable UrunBilgiIdyeGore()
    {
        DataTable dtb = new DataTable();
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_UrunBilgi";

        cmd.Parameters.AddWithValue("ProductID", ProductID);
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

    public DataTable UrunListesiAra(string aramaKelimesi)
    {
        DataTable dtb = new DataTable();
        SqlConnection con = bag.con();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_UrunListesiAra";
        cmd.Parameters.AddWithValue("AramaKelimesi", aramaKelimesi);
        SqlDataAdapter adap = new SqlDataAdapter(cmd);
        adap.Fill(dtb);
        con.Close();
        return dtb;
    }
}
