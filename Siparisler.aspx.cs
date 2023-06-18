using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Siparisler : System.Web.UI.Page
{
    static int _SipID = -1;

    static string _musID = string.Empty;
    csSiparisler sip = new csSiparisler();
    csMusteriler musteriler = new csMusteriler();

    protected void Page_Load(object sender, EventArgs e)
    {

        
        if (!IsPostBack)
        {
            //Calendar1.Visible = false;
            //Calendar2.Visible = false;
            //Calendar3.Visible = false;


            musteriler.dropDoldur(ddlMusteriID, "CompanyName", "CustomerID", "SP_MusteriListesi");
            musteriler.dropDoldur(ddlPersonelID, "LastName", "EmployeeID", "SP_PersonelListesi");
            musteriler.dropDoldur(ddlShipVia, "CompanyName", "ShipperID", "SP_NakliyeciListesi");

            ListItem emptyItemM = new ListItem("Şirket Seç", "");
            ddlMusteriID.Items.Insert(0, emptyItemM);

            ListItem emptyItemP = new ListItem("Personel Seç", "");
            ddlPersonelID.Items.Insert(0, emptyItemP);

            ListItem emptyItemG = new ListItem("Gönderici Seç", "");
            ddlShipVia.Items.Insert(0, emptyItemG);
            Calendar1.Visible = false;
            Calendar2.Visible=false;
            Calendar3.Visible=false;


            doldur();
        }
    }




    
    protected void btnEkle_Click(object sender, EventArgs e)
    {

        sip.CustomerID = ddlMusteriID.SelectedValue;
        sip.EmployeeID= Convert.ToInt32(ddlPersonelID.SelectedValue);
        string tarih = txtSatisTarihi.Text;
       
        tarih = tarih + " 00:00:00.000";

        sip.OrderDate = Convert.ToDateTime(tarih);
        sip.RequiredDate = Convert.ToDateTime(txtOdemeTarihi.Text);
        sip.ShippedDate=Convert.ToDateTime(txtSevkTarihi.Text);
        sip.ShipVia = ddlShipVia.SelectedValue;
        sip.Freight = txtNakliyeUcreti.Text;
        sip.ShipName = txtSevkAdi.Text;
        sip.ShipAddress = txtSevkAdresi.Text;
        sip.ShipCity = txtSevkSehri.Text;
        sip.ShipRegion = txtSevkBolgesi.Text;

        
        int shipPostalCode;
        if (int.TryParse(txtSevkPostaKodu.Text, out shipPostalCode))
        {
            sip.ShipPostalCode = shipPostalCode;
        }
        else
        {
            // Geçersiz posta kodu için hata işleme yapılabilir veya kullanıcıya hata mesajı gösterilebilir.
            return;
        }
        sip.ShipCountry = txtSevkUlkesi.Text;


        if (btnEkle.Text=="Kaydet")
        {
            sip.SiparisEkle();
        }
        else 
        {
            sip.OrderID = _SipID;
            sip.SiparisGuncelle();

        }


    
    }
    void doldur()
    {
        rptSiparisler.DataSource = sip.Siparisler();
        rptSiparisler.DataBind();
    }

    protected void rptSiparisler_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Sec" && e.CommandArgument != "")
        {
            _SipID = Convert.ToInt32(e.CommandArgument.ToString());
            sip.OrderID = _SipID;
            DataTable dtb = new DataTable();

            dtb = sip.SiparisBilgiIdyeGore();

            if (dtb.Rows.Count > 0)
            {
                ddlMusteriID.SelectedValue= dtb.Rows[0]["CustomerID"].ToString();
                ddlPersonelID.SelectedValue = dtb.Rows[0]["EmployeeID"].ToString();
                txtSatisTarihi.Text =Convert.ToDateTime(dtb.Rows[0]["OrderDate"].ToString()).ToShortDateString();
                txtOdemeTarihi.Text = Convert.ToDateTime(dtb.Rows[0]["RequiredDate"].ToString()).ToShortDateString();
                txtSevkTarihi.Text = Convert.ToDateTime(dtb.Rows[0]["ShippedDate"].ToString()).ToShortDateString();
                ddlShipVia.SelectedValue = dtb.Rows[0]["ShipVia"].ToString();
                txtNakliyeUcreti.Text = dtb.Rows[0]["Freight"].ToString();
                txtSevkAdi.Text = dtb.Rows[0]["ShipName"].ToString();
                txtSevkAdresi.Text = dtb.Rows[0]["ShipAddress"].ToString();
                txtSevkSehri.Text = dtb.Rows[0]["ShipCity"].ToString();
                txtSevkBolgesi.Text = dtb.Rows[0]["ShipRegion"].ToString();
                txtSevkPostaKodu.Text = dtb.Rows[0]["ShipPostalCode"].ToString();
                txtSevkUlkesi.Text = dtb.Rows[0]["ShipCountry"].ToString();
            }

            btnEkle.Text = "Güncelle";
        }
    }



    protected void ddlMusteriID_SelectedIndexChanged(object sender, EventArgs e)
    {
        _musID = ddlMusteriID.SelectedValue;
        musteriler.CustomerID = _musID;
        DataTable dtb = new DataTable();

        dtb = musteriler.MusteriBilgiIdyeGore();

        if (dtb.Rows.Count > 0)
        {

            txtSevkAdi.Text = dtb.Rows[0]["CompanyName"].ToString();
            txtSevkAdresi.Text = dtb.Rows[0]["Address"].ToString();
            txtSevkSehri.Text = dtb.Rows[0]["City"].ToString();
            txtSevkBolgesi.Text = dtb.Rows[0]["Region"].ToString();
            txtSevkPostaKodu.Text = dtb.Rows[0]["PostalCode"].ToString();
            txtSevkUlkesi.Text = dtb.Rows[0]["Fax"].ToString();

        }


    }






    protected void ImgDateSatis_Click(object sender, ImageClickEventArgs e)
    {
        if (Calendar1.Visible)
        {
            Calendar1.Visible = false;
        }
        else
        {
            Calendar1.Visible = true;
        }
        Calendar1.Attributes.Add("style", "position:absolute");

    }
    protected void ImgDateOdeme_Click(object sender, ImageClickEventArgs e)
    {
        if (Calendar2.Visible)
        {
            Calendar2.Visible = false;
        }
        else
        {
            Calendar2.Visible = true;
        }
        Calendar2.Attributes.Add("style", "position:absolute");
    }
    protected void ImgDateSevk_Click(object sender, ImageClickEventArgs e)
    {
        if (Calendar3.Visible)
        {
            Calendar3.Visible = false;
        }
        else
        {
            Calendar3.Visible = true;
        }
        Calendar3.Attributes.Add("style", "position:absolute");
    }


    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        txtSatisTarihi.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
        Calendar1.Visible = false;



    }
    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        txtOdemeTarihi.Text = Calendar2.SelectedDate.ToString("dd/MM/yyyy");
        Calendar2.Visible = false;


    }

    protected void Calendar3_SelectionChanged(object sender, EventArgs e)
    {
        txtSevkTarihi.Text = Calendar3.SelectedDate.ToString("dd/MM/yyyy");
        Calendar3.Visible = false;


    }

    protected void btnAra_Click(object sender, EventArgs e)
    {
        string aramaKelimesi = txtArama.Text;

        DataTable dtb = sip.SiparisListesiAra(aramaKelimesi);

        rptSiparisler.DataSource = dtb;
        rptSiparisler.DataBind();

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

