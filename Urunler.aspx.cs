using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Urunler : System.Web.UI.Page
{
    static int _UrunID = -1;
    csUrunler urun = new csUrunler();
    csKategoriler Droplist = new csKategoriler();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Droplist.dropDoldur(ddlTedarikciID, "CompanyName", "SupplierID", "SP_TedarikciListesi");
            Droplist.dropDoldur(ddlKategoriID, "CategoryName", "CategoryID", "SP_Kategorilistesi");

            ListItem emptyItemM = new ListItem("Tedarikçi Seç", "");
            ddlTedarikciID.Items.Insert(0, emptyItemM);

            ListItem emptyItemP = new ListItem("Kategori Seç", "");
            ddlKategoriID.Items.Insert(0, emptyItemP);
            doldur();
        }
    }

    protected void btnEkle_Click(object sender, EventArgs e)
    {
        urun.ProductName = txtUrunAdi.Text;
        int supplierID;
        int categoryID;

        if (int.TryParse(ddlTedarikciID.SelectedValue, out supplierID))
        {
            urun.SupplierID = supplierID;
        }

        if (int.TryParse(ddlKategoriID.SelectedValue, out categoryID))
        {
            urun.CategoryID = categoryID;
        }
        urun.QuantityPerUnit = txtBirimdekiMiktar.Text;
        urun.UnitPrice = txtBirimFiyati.Text;
        urun.UnitsInStock = txtHedefStokDuzeyi.Text;
        urun.UnitsOnOrder = txtYeniSatis.Text;
        urun.ReorderLevel = txtEnAzYenidenSatisMikatari.Text;
       
        urun.Discontinued = ddlSonlandi.SelectedValue;


        if (btnEkle.Text == "Kaydet")
        {
            urun.UrunEkle();
        }
        else
        {
            urun.ProductID = _UrunID;
            urun.UrunGuncelle();
        }

        doldur();
    }


    void doldur()
    {
        rptUrunler.DataSource = urun.Urunler();
        rptUrunler.DataBind();
    }

    protected void rptUrunler_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Sec" && e.CommandArgument != null)
        {
            _UrunID = Convert.ToInt32(e.CommandArgument);

            urun.ProductID = _UrunID;

            DataTable dtb = new DataTable();
            dtb = urun.UrunBilgiIdyeGore();

            if (dtb.Rows.Count > 0)
            {
                txtUrunAdi.Text = dtb.Rows[0][1].ToString();
                ddlTedarikciID.SelectedValue = dtb.Rows[0][2].ToString();
                ddlKategoriID.SelectedValue = dtb.Rows[0][3].ToString();
                txtBirimdekiMiktar.Text = dtb.Rows[0][4].ToString();
                txtBirimFiyati.Text = dtb.Rows[0][5].ToString();
                txtHedefStokDuzeyi.Text = dtb.Rows[0][6].ToString();
                txtYeniSatis.Text = dtb.Rows[0][7].ToString();
                txtEnAzYenidenSatisMikatari.Text = dtb.Rows[0][8].ToString();

                ddlSonlandi.ClearSelection();

                if (ddlSonlandi.Items.FindByValue(dtb.Rows[0][9].ToString()) != null)
                {
                    ddlSonlandi.Items.FindByValue(dtb.Rows[0][9].ToString()).Selected = true;
                }
                else
                {
                    ddlSonlandi.SelectedIndex = 0;
                }



                btnEkle.Text = "Güncelle";
            }
        }

        if (e.CommandName == "Sil" && e.CommandArgument != null)
        {
            _UrunID = Convert.ToInt32(e.CommandArgument);
            urun.ProductID = _UrunID;
            urun.UrunSil();
            doldur();
        }
    }
    
    protected void btnAra_Click(object sender, EventArgs e)
    {
        string aramaKelimesi = txtArama.Text;

        DataTable dtb = urun.UrunListesiAra(aramaKelimesi);

        rptUrunler.DataSource = dtb;
        rptUrunler.DataBind();

        if (dtb.Rows.Count == 0)
        {
            lblMesaj.Text = "Aradığınız Sonuç Bulunamadı.";
            lblMesaj.Visible = true;
        }
        else
        {
            lblMesaj.Visible = false;
        }
    }
}
