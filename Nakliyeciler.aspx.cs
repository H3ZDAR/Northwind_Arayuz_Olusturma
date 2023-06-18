using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Nakliyeciler : System.Web.UI.Page
{
    static string _NakliyeID = string.Empty;
    csNakliyeciler nak = new csNakliyeciler();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            doldur();
            //btnTemizle.Visible = false;
            //nak.dropDoldur(ddlUlke, "Country", "CustomerID", "SP_MusteriListesi");

            //ListItem emptyItemM = new ListItem("Ülke Seç", "");
            //ddlUlke.Items.Insert(0, emptyItemM);
        }
    }


    protected void btnEkle_Click(object sender, EventArgs e)
    {
        
        nak.CompanyName = txtSirketAdi.Text;
        nak.Phone = txtTelefon.Text;


        if (btnEkle.Text == "Kaydet")
        {
            nak.NakliyeciEkle();

        }
        else
        {

            nak.ShipperID = _NakliyeID;
            nak.NakliyeciGuncelle();

        }


        doldur();



    }


    void doldur()
    {

        rptNakliyeciler.DataSource = nak.Nakliyeciler();
        rptNakliyeciler.DataBind();

    }
    protected void btnTemizle_Click(object sender, EventArgs e)
    {
        Temizle();
    }

    void Temizle()
    {
        
        txtSirketAdi.Text = "";
        txtTelefon.Text = "";
        

        btnTemizle.Text = "Temizle";
        btnTemizle.Visible = false;
        btnEkle.Text = "Ekle";
    }


    protected void rptNakliyeciler_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Sec" && e.CommandArgument != "")
        {

            _NakliyeID = e.CommandArgument.ToString();

            nak.ShipperID = _NakliyeID;

            DataTable dtb = new DataTable();

            dtb = nak.NakliyeciBilgiIdyeGore();
            
            txtSirketAdi.Text = dtb.Rows[0][1].ToString();
            txtTelefon.Text = dtb.Rows[0][2].ToString();
           
            btnTemizle.Visible = true;

            btnEkle.Text = "Güncelle";

        }

        if (e.CommandName == "Sil" && e.CommandArgument != "")
        {

            _NakliyeID = e.CommandArgument.ToString();

            _NakliyeID = e.CommandArgument.ToString();
            nak.ShipperID = _NakliyeID;
            nak.NakliyeciSil();
            doldur();
        }





    }
   
    protected void btnAra_Click(object sender, EventArgs e)
    {
        string aramaKelimesi = txtArama.Text;

        DataTable dtb = nak.NakliyeciListesiAra(aramaKelimesi);

        rptNakliyeciler.DataSource = dtb;
        rptNakliyeciler.DataBind();

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
