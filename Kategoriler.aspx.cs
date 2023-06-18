using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Kategoriler : System.Web.UI.Page
{
    static int _CategoryID = -1;
    csKategoriler kate = new csKategoriler();

    protected void Page_Load(object sender, EventArgs e)
    {
        doldur();
    }

    protected void btnEkle_Click(object sender, EventArgs e)
    {
        csKategoriler kate = new csKategoriler(); // csKategoriler sınıfının bir örneğini oluşturun
        kate.CategoryName = txtKategoriAdi.Text;
        kate.Description = txtAciklama.Text;

        if (txtResim.HasFile)
        {
            string filename = Path.GetFileName(txtResim.FileName);
            string contentType = txtResim.PostedFile.ContentType;

            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(txtResim.PostedFile.InputStream))
            {
                fileBytes = br.ReadBytes(txtResim.PostedFile.ContentLength);
            }

            string imagePath = Server.MapPath("~/images/") + filename;
            txtResim.SaveAs(imagePath);

            kate.PictureBytes = fileBytes;
        }

        if (btnEkle.Text != "Güncelle")
        {
            int result = kate.KategoriEkle(); 
        }
        else
        {
            kate.CategoryID = _CategoryID;
            int result = kate.KategoriEkle();
        }

        doldur();
    }

    void doldur()
    {
        rptKategoriler.DataSource = kate.KategoriListesi();
        rptKategoriler.DataBind();
    }

    protected void btnTemizle_Click(object sender, EventArgs e)
    {
        Temizle();
    }

    void Temizle()
    {
        txtKategoriAdi.Text = "";
        txtAciklama.Text = "";
        txtResim.Attributes.Clear();

        btnTemizle.Text = "Temizle";
        btnTemizle.Visible = false;
        btnEkle.Text = "Ekle";
    }

    protected void rptKategoriler_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Sec" && e.CommandArgument != "")
        {
            _CategoryID = Convert.ToInt32(e.CommandArgument.ToString());
            kate.CategoryID = _CategoryID;

            DataTable dtb = new DataTable();
            dtb = kate.KategoriBilgiIdyeGore();

            txtKategoriAdi.Text = dtb.Rows[0][1].ToString();
            txtAciklama.Text = dtb.Rows[0][2].ToString();
            //txtResim.FileUpload = dtb.Rows[0]["PhotoPath"].ToString();

            btnEkle.Text = "Güncelle";
        }

        if (e.CommandName == "Sil" && e.CommandArgument != "")
        {
            _CategoryID = Convert.ToInt32(e.CommandArgument.ToString());
            kate.CategoryID = _CategoryID;
            kate.KategoriSil();
            doldur();
        }
    }



    protected void btnAra_Click(object sender, EventArgs e)
    {
        string aramaKelimesi = txtArama.Text;

        DataTable dtb = kate.KategoriListesiAra(aramaKelimesi);

        rptKategoriler.DataSource = dtb;
        rptKategoriler.DataBind();

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
