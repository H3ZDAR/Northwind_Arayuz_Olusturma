using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Musteriler : System.Web.UI.Page
{
    static string _MustID = string.Empty;
    csMusteriler must = new csMusteriler();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            doldur();
            btnTemizle.Visible = false;
            must.dropDoldur(ddlUlke, "Country", "CustomerID", "SP_MusteriListesi");

            ListItem emptyItemM = new ListItem("Ülke Seç", "");
            ddlUlke.Items.Insert(0, emptyItemM);
        }
    }

    protected void btnEkle_Click(object sender, EventArgs e)
    {
        must.CustomerID = txtCustomerID.Text;
        must.CompanyName = txtSirketAdi.Text;
        must.ContactName = txtMusteriAdi.Text;
        must.ContactTitle = txtMusteriUnvani.Text;
        must.Address = txtAdres.Text;
        must.City = txtSehir.Text;
        must.Region = txtBolge.Text;
        must.PostalCode = txtPostaKodu.Text;
        must.Country = ddlUlke.SelectedValue;
        must.Phone = txtTelefon.Text;
        must.Fax = txtFaks.Text;

        if (btnEkle.Text == "Kaydet")
        {
            must.MusteriEkle();
        }
        else
        {
            must.CustomerID = _MustID;
            must.MusteriGuncelle();
        }

        doldur();
    }

    void doldur()
    {
        rptMusteriler.DataSource = must.Musteriler();
        rptMusteriler.DataBind();
    }

    protected void btnTemizle_Click(object sender, EventArgs e)
    {
        Temizle();
    }

    void Temizle()
    {
        txtCustomerID.Text = "";
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

        btnTemizle.Text = "Temizle";
        btnTemizle.Visible = false;
        btnEkle.Text = "Ekle";
    }

    protected void rptMusteriler_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Sec" && e.CommandArgument != "")
        {
            _MustID = e.CommandArgument.ToString();
            must.CustomerID = _MustID;

            DataTable dtb = new DataTable();
            dtb = must.MusteriBilgiIdyeGore();
            txtCustomerID.Text = dtb.Rows[0][0].ToString();
            txtSirketAdi.Text = dtb.Rows[0][1].ToString();
            txtMusteriAdi.Text = dtb.Rows[0][2].ToString();
            txtMusteriUnvani.Text = dtb.Rows[0][3].ToString();
            txtAdres.Text = dtb.Rows[0][4].ToString();
            txtSehir.Text = dtb.Rows[0][5].ToString();
            txtBolge.Text = dtb.Rows[0][6].ToString();
            txtPostaKodu.Text = dtb.Rows[0][7].ToString();

            ddlUlke.ClearSelection();
            if (ddlUlke.Items.FindByValue(dtb.Rows[0][8].ToString()) != null)
            {
                ddlUlke.Items.FindByValue(dtb.Rows[0][8].ToString()).Selected = true;
            }
            else
            {
                ddlUlke.SelectedIndex = 0;
            }

            txtTelefon.Text = dtb.Rows[0][9].ToString();
            txtFaks.Text = dtb.Rows[0][10].ToString();
            btnTemizle.Visible = true;
            btnEkle.Text = "Güncelle";
        }

        if (e.CommandName == "Sil" && e.CommandArgument != "")
        {
            _MustID = e.CommandArgument.ToString();
            must.CustomerID = _MustID;
            must.MusteriSil();
            doldur();
        }
    }
    protected void btnAra_Click(object sender, EventArgs e)
    {
        string aramaKelimesi = txtArama.Text;

        DataTable dtb = must.MusteriListesiAra(aramaKelimesi);

        rptMusteriler.DataSource = dtb;
        rptMusteriler.DataBind();

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

