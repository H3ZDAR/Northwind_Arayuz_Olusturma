using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Kullancilar : System.Web.UI.Page
{
    static int _KulID = -1;
    csKullanicilar kul = new csKullanicilar();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            doldur();
        }
     

    }
    protected void btnEkle_Click(object sender, EventArgs e)
    {

        kul.Adi = txtAdi.Text;
        kul.Soyadi = txtSoyadi.Text;
        kul.Tel = txtTel.Text;
        kul.TC = txtTC.Text;
        kul.Sifre = txtSifre.Text;
        kul.GrupID =Convert.ToInt32( drpGruplar.SelectedValue);
        if (btnEkle.Text=="Kaydet")
        {
            kul.KullaniciEkle();
            
        }
        else
        {
            kul.KullaniciID = _KulID;
            kul.KullaniciGuncelle();
        }
      
        
        doldur();

      

    }

    void doldur()
    {

        rptKullanicilar.DataSource = kul.Kullancilar();
        rptKullanicilar.DataBind();
        kul.dropDoldur(drpGruplar, "GrupAdi", "GrupID");
    
    }
    protected void rptKullanicilar_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Sec" && e.CommandArgument != "")
        {

           _KulID = Convert.ToInt32(e.CommandArgument.ToString());
            kul.KullaniciID = _KulID;
            DataTable dtb = new DataTable();

            dtb = kul.KullaniciBilgiIdyeGore();

            txtAdi.Text=dtb.Rows[0][2].ToString();
            txtSoyadi.Text = dtb.Rows[0][3].ToString();
            txtTC.Text = dtb.Rows[0][5].ToString();
            txtTel.Text = dtb.Rows[0][4].ToString();
            txtSifre.Text = dtb.Rows[0][6].ToString();

            drpGruplar.SelectedValue = dtb.Rows[0][1].ToString();

            btnEkle.Text = "Güncelle";

        }
    }
}