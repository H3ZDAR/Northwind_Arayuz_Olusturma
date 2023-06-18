using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Tedarikciler : System.Web.UI.Page
{
    int _TedID = -1;
    csTedarikciler ted = new csTedarikciler();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            doldur();
            btnTemizle.Visible = false;
            ted.dropDoldur(ddlUlke, "Country", "SupplierID", "SP_TedarikciListesi");

            ListItem emptyItemM = new ListItem("Ülke Seç", "");
            ddlUlke.Items.Insert(0, emptyItemM);
        }
    }

    protected void btnEkle_Click(object sender, EventArgs e)
    {
        ted.SupplierID = -1; // Veya başka bir geçersiz bir değer atayın
        ted.CompanyName = txtSirketAdi.Text;
        ted.ContactName = txtMusteriAdi.Text;
        ted.ContactTitle = txtMusteriUnvani.Text;
        ted.Address = txtAdres.Text;
        ted.City = txtSehir.Text;
        ted.Region = txtBolge.Text;
        int postalCode;
        bool isPostalCodeValid = int.TryParse(txtPostaKodu.Text, out postalCode);

        if (isPostalCodeValid)
        {
            ted.PostalCode = postalCode;
        }
        else
        {
            // Hata durumuyla ilgili işlemler
        }

        ted.Country = ddlUlke.SelectedValue;
        ted.Phone = txtTelefon.Text;
        ted.Fax = txtFaks.Text;
        ted.HomePage = txtAnaSayfa.Text;

        if (btnEkle.Text == "Kaydet")
        {
            ted.TedarikciEkle();
        }
        else
        {
            ted.SupplierID = _TedID;
            ted.TedarikciGuncelle();
        }

        doldur();
    }

    void doldur()
    {
        rptTedarikciler.DataSource = ted.Tedarikciler();
        rptTedarikciler.DataBind();
    }

    protected void btnTemizle_Click(object sender, EventArgs e)
    {
        Temizle();
    }

    void Temizle()
    {
        txtSupplierID.Text = "";
        txtSirketAdi.Text = "";
        txtMusteriAdi.Text = "";
        txtMusteriUnvani.Text = "";
        txtAdres.Text = "";
        txtSehir.Text = "";
        txtBolge.Text = "";
        txtPostaKodu.Text = "";
        ddlUlke.SelectedIndex = 0;
        txtTelefon.Text = "";
        txtFaks.Text = "";
        txtAnaSayfa.Text = "";

        btnTemizle.Text = "Temizle";
        btnTemizle.Visible = false;
        btnEkle.Text = "Ekle";
    }

    protected void rptTedarikciler_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Sec" && e.CommandArgument != "")
        {
            _TedID = int.Parse(e.CommandArgument.ToString());
            ted.SupplierID = _TedID;

            DataTable dtb = new DataTable();
            dtb = ted.TedarikciBilgiIdyeGore();

            txtSupplierID.Text = dtb.Rows[0][0].ToString();
            txtSirketAdi.Text = dtb.Rows[0][1].ToString();
            txtMusteriAdi.Text = dtb.Rows[0][2].ToString();
            txtMusteriUnvani.Text = dtb.Rows[0][3].ToString();
            txtAdres.Text = dtb.Rows[0][4].ToString();
            txtSehir.Text = dtb.Rows[0][5].ToString();
            txtBolge.Text = dtb.Rows[0][6].ToString();
            txtPostaKodu.Text = dtb.Rows[0][7].ToString();
            ddlUlke.ClearSelection(); // Mevcut seçimi temizler
            if (ddlUlke.Items.FindByValue(dtb.Rows[0][8].ToString()) != null)
            {
                ddlUlke.ClearSelection(); // Mevcut seçimi temizler
                ddlUlke.Items.FindByValue(dtb.Rows[0]["ddlUlke"].ToString()).Selected = true; // Geçerli değeri seçer
            }
            else
            {
                ddlUlke.SelectedIndex = 0; // Varsayılan olarak ilk öğeyi seçer
            }

            txtTelefon.Text = dtb.Rows[0][9].ToString();
            txtFaks.Text = dtb.Rows[0][10].ToString();
            txtAnaSayfa.Text = dtb.Rows[0][11].ToString();
            btnTemizle.Visible = true;
            btnEkle.Text = "Güncelle";
        }

        if (e.CommandName == "Sil" && e.CommandArgument != "")
        {
            _TedID = int.Parse(e.CommandArgument.ToString());
            ted.SupplierID = _TedID;
            ted.TedarikciSil();
            doldur();
        }
    }
   
    protected void btnAra_Click(object sender, EventArgs e)
    {
        string aramaKelimesi = txtArama.Text;

        DataTable dtb = ted.TedarikciListesiAra(aramaKelimesi);

        rptTedarikciler.DataSource = dtb;
        rptTedarikciler.DataBind();

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

