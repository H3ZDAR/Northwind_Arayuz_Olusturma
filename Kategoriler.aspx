<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Kategoriler.aspx.cs" Inherits="Kategoriler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="txtara" runat="server" class="form-control" placeholder=""></asp:TextBox>

    <div class="row g-4">
        <div class="col-md-12 col-sm-9">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Kategori Ekleme Paneli</h2>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <div class="col-md-6 col-sm-6 mb-3">
                        <asp:TextBox ID="txtKategoriAdi" runat="server" class="form-control" placeholder="Kategori Adı"></asp:TextBox>
                    </div>
                    <div class="col-md-6 col-sm-6 mb-3">
                        <span class="input-group-btn">
                            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                            <asp:FileUpload ID="txtResim" class="form-control" type="FileUpload" runat="server" placeholder=""></asp:FileUpload>
                        </span>
                    </div>
                    <div class="col-md-6 col-sm-6 mb-3">
                        <asp:TextBox ID="txtAciklama" class="form-control" runat="server" placeholder="Açıklama" TextMode="MultiLine" Rows="1"></asp:TextBox>
                    </div>
                    <div class="ln_solid"></div>
                    <div class="form-group row">
                        <div class="col-md-6 col-sm-9">
                            <asp:Button ID="btnTemizle" runat="server" Text="Temizle" class="btn btn-dark btn-block" OnClick="btnEkle_Click" />
                        </div>
                        <div class="col-md-6 col-sm-9">
                            <asp:Button ID="btnEkle" runat="server" Text="Kaydet" class="btn btn-danger btn-block" OnClick="btnEkle_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-md-12 col-sm-9">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Arama Yap</h2>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <div class="form-group row">
                        <div class="col-md-10 col-sm-6 mb-3">
                            <asp:TextBox ID="txtArama" runat="server" class="form-control" placeholder=""></asp:TextBox>
                        </div>
                        <div class="col-md-2 col-sm-9">
                            <asp:Button ID="btnAra" runat="server" Text="Ara" class="btn btn-secondary btn-block" OnClick="btnAra_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-md-12 col-sm-9">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Kategori Listesi</h2>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <table class="table">
                        <thead>
                            <tr>
                                <th>Kategori No</th>
                                <th>Kategori Adı</th>
                                <th>Açıklama</th>
                                <th>Resim</th>
                                <th>İşlemler</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptKategoriler" runat="server" OnItemCommand="rptKategoriler_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <th scope="row"><%#Eval("CategoryID") %></th>
                                        <td><%#Eval("CategoryName") %></td>
                                        <td><%#Eval("Description") %></td>
                                        <td>
                                            <img src='<%# "data:image;base64," + Convert.ToBase64String((byte[])Eval("Picture")) %>' alt='Resim' style='max-width: 40px; max-height: 40px;' />
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="lnkbtn" class="btn btn-success btn-sm" CommandName="Sec" CommandArgument='<%#Eval("CategoryID") %>' runat="server">Güncelle</asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton1" class="btn btn-danger btn-sm" CommandName="Sil" CommandArgument='<%#Eval("CategoryID") %>' runat="server">Sil</asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <asp:Label ID="lblMesaj" runat="server" CssClass="error-message" Visible="false"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <style>
    .error-message {
        color: #333333;
        font-weight: bold;
        text-align: center;
        font-size: 14px;
        margin: 0 auto;
        display: block;
    }
</style>
</asp:Content>


