using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Personeller : System.Web.UI.Page
{
    static int _PersID = -1;
    csPersoneller pers = new csPersoneller();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Calendar1.Visible = false;
            Calendar2.Visible = false;
           
            doldur();

        }
    }

    protected void btnEkle_Click(object sender, EventArgs e)
    {
        pers.LastName = txtSoyadi.Text;
        pers.FirstName = txtAdi.Text;
        pers.Title = txtUnvan.Text;
        pers.TitleOfCourtesy = txtUnvanEki.Text;
        //pers.BirthDate = Convert.ToDateTime(txtDogumTarihi.Text);
        string tarih = txtDogumTarihi.Text;
        
        tarih = tarih + " 00:00:00.000";
        DateTime a = Convert.ToDateTime(tarih);
        pers.BirthDate = Convert.ToDateTime(a);

        string tarihh = txtIseBaslamaTarihi.Text;
        tarihh.Replace('.', '/');
        tarihh = tarihh + " 00:00:00.000";

        pers.HireDate = Convert.ToDateTime(tarihh);
        //pers.HireDate = Convert.ToDateTime(txtIseBaslamaTarihi.Text);



        


        
        pers.Address = txtAdres.Text;
        pers.City = txtSehir.Text;
        pers.Region = txtBolge.Text;
        pers.PostalCode = txtPostaKodu.Text;
        
        pers.Country = ddlCountry.SelectedValue;

        pers.HomePhone = txtEvTelefonu.Text;
        pers.Extension = txtExtension.Text;
        //pers.PhotoPath = fileFotograf.FileName;


        
        if (txtResim.HasFile)
        {
            // Dosya yükleme işlemleri
            string filename = Path.GetFileName(txtResim.FileName);
            string contentType = txtResim.PostedFile.ContentType;

            // Dosya içeriğini byte dizisi olarak al
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(txtResim.PostedFile.InputStream))
            {
                fileBytes = br.ReadBytes(txtResim.PostedFile.ContentLength);
            }

            // Resmi "images" klasörüne kaydet
            string imagePath = Server.MapPath("~/images/") + filename;
            txtResim.SaveAs(imagePath);

            // Veritabanına kaydet

            pers.PictureBytes = fileBytes;
        }


        pers.Notes = txtNotlar.Text;
        int reportsTo;
        if (int.TryParse(txtBagliCalistigiKisi.Text, out reportsTo))
        {
            pers.ReportsTo = reportsTo;
        }
        else
        {
            // Hatalı tam sayı formatı durumunda yapılacak işlemler
            // Örneğin, kullanıcıya hatalı formatı bildirme veya varsayılan bir değer atama
        }


        if (btnEkle.Text == "Kaydet")
        {
            pers.PersonelEkle();
        }
        else
        {
            pers.EmployeeID = _PersID;
            pers.PersonelGuncelle();
        }

        doldur();
    }


    protected void ImgDogumTarihi_Click(object sender, ImageClickEventArgs e)
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
    protected void ImgIseBaslamaTarihi_Click(object sender, ImageClickEventArgs e)
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

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        txtDogumTarihi.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
        Calendar1.Visible = false;


    }
    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        txtIseBaslamaTarihi.Text = Calendar2.SelectedDate.ToString("dd/MM/yyyy");
        Calendar2.Visible = false;


    }

    void doldur()
    {
        rptPersoneller.DataSource = pers.Personeller();
        rptPersoneller.DataBind();
    }

    protected void rptPersoneller_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Sec" && e.CommandArgument != null)
        {
            _PersID = Convert.ToInt32(e.CommandArgument);

            pers.EmployeeID = _PersID;

            DataTable dtb = new DataTable();
            dtb = pers.PersonelBilgiIdyeGore();

            if (dtb.Rows.Count > 0)
            {
                txtAdi.Text = dtb.Rows[0]["FirstName"].ToString();
                txtSoyadi.Text = dtb.Rows[0]["LastName"].ToString();
                txtUnvan.Text = dtb.Rows[0]["Title"].ToString();
                txtUnvanEki.Text = dtb.Rows[0]["TitleOfCourtesy"].ToString();
                txtDogumTarihi.Text = Convert.ToDateTime(dtb.Rows[0]["BirthDate"].ToString()).ToShortDateString();
                txtIseBaslamaTarihi.Text = Convert.ToDateTime(dtb.Rows[0]["HireDate"].ToString()).ToShortDateString();
                txtAdres.Text = dtb.Rows[0]["Address"].ToString();
                txtSehir.Text = dtb.Rows[0]["City"].ToString();
                txtBolge.Text = dtb.Rows[0]["Region"].ToString();
                txtPostaKodu.Text = dtb.Rows[0]["PostalCode"].ToString();
                ddlCountry.SelectedValue = dtb.Rows[0][8].ToString();
                txtEvTelefonu.Text = dtb.Rows[0]["HomePhone"].ToString();
                txtExtension.Text = dtb.Rows[0]["Extension"].ToString();
                //txtFotograf.FileName = dtb.Rows[0]["PhotoPath"].ToString();
                txtNotlar.Text = dtb.Rows[0]["Notes"].ToString();
                txtBagliCalistigiKisi.Text = dtb.Rows[0]["ReportsTo"].ToString();

                btnEkle.Text = "Güncelle";
            }
        }

        if (e.CommandName == "Sil" && e.CommandArgument != null)
        {
            _PersID = Convert.ToInt32(e.CommandArgument);
            pers.EmployeeID = _PersID;
            pers.PersonelSil();
            doldur();
        }
    }
   
    protected void btnAra_Click(object sender, EventArgs e)
    {
        string aramaKelimesi = txtArama.Text;

        DataTable dtb = pers.PersonelListesiAra(aramaKelimesi);

        rptPersoneller.DataSource = dtb;
        rptPersoneller.DataBind();

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
