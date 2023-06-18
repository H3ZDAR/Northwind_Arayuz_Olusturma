<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Urunler.aspx.cs" Inherits="Urunler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="rowrow">
        <div class="col-md-12 col-sm-9">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Ürün Ekleme Paneli</h2>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <br>
                    <div class="col-md-6 col-sm-6 mb-3">
                        <asp:TextBox ID="txtUrunAdi" runat="server" class="form-control" placeholder="Ürün Adı"></asp:TextBox>
                    </div>
                    <div class="col-md-6 col-sm-6 mb-3">
                        <asp:DropDownList ID="ddlTedarikciID" runat="server" placeholder="Bölge" class="form-control" AutoPostBack="True">
                            <asp:ListItem Value="#">Tedarikçi Seçiniz</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-6 col-sm-6 mb-3">
                        <asp:DropDownList ID="ddlKategoriID" runat="server" placeholder="Bölge" class="form-control" AutoPostBack="True">
                            <asp:ListItem Value="#">Kategori Seçiniz</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-6 col-sm-6 mb-3">
                        <asp:TextBox ID="txtBirimdekiMiktar" class="form-control" runat="server" placeholder="Birimdeki Miktar"></asp:TextBox>
                    </div>
                    <div class="col-md-6 col-sm-6 mb-3">
                        <asp:TextBox ID="txtBirimFiyati" runat="server" class="form-control" placeholder="Birim Fiyatı"></asp:TextBox>
                    </div>
                    <div class="col-md-6 col-sm-6 mb-3 ">
                        <asp:TextBox ID="txtHedefStokDuzeyi" class="form-control" runat="server" placeholder="Hedef Stok Duzeyi"></asp:TextBox>
                    </div>
                    <div class="col-md-6 col-sm-6 mb-3">
                        <asp:TextBox ID="txtYeniSatis" class="form-control" runat="server" placeholder="Yeni Satis"></asp:TextBox>
                    </div>
                    <div class="col-md-6 col-sm-6 mb-3">
                        <asp:TextBox ID="txtEnAzYenidenSatisMikatari" runat="server" class="form-control" placeholder="En Az Yeniden Satıs Mikatarı"></asp:TextBox>
                    </div>
                    <div class="col-md-6 col-sm-6 mb-3">
                        <asp:DropDownList ID="ddlSonlandi" runat="server" placeholder="Bölge" class="form-control">
                            <asp:ListItem Value="#">Durumu Seçiniz</asp:ListItem>
                            <asp:ListItem Value="True">True</asp:ListItem>
                            <asp:ListItem Value="False">False</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="ln_solid"></div>
                    <div class="form-group row">
                        <div class="col-md-6 col-sm-9 ">
                            <asp:Button ID="Button3" runat="server" Text="Temizle" class="btn btn-dark btn-block" OnClick="btnEkle_Click" />
                        </div>
                        <div class="col-md-6 col-sm-9 ">
                            <asp:Button ID="btnEkle" runat="server" Text="Kaydet" class="btn btn-success btn-block" OnClick="btnEkle_Click" />
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
                        <div class="col-md-10 col-sm-6 mb-3 ">
                            <asp:TextBox ID="txtArama" runat="server" class="form-control" placeholder=""></asp:TextBox>
                        </div>
                        <div class="col-md-2 col-sm-9 ">
                            <asp:Button ID="btnAra" runat="server" Text="Ara" class="btn btn-secondary btn-block" OnClick="btnAra_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-12 col-sm-9">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Ürün Listesi</h2>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <table class="table">
                        <thead>
                            <tr>
                                <th>Ürün No</th>
                                <th>Ürü Adı</th>
                                <th>Tedarikçi Adı</th>
                                <th>Kategori Adı</th>
                                <th>Birimdeki Miktar</th>
                                <th>Birim Fiyatı</th>
                                <th>Hedef Stok Düzeyi</th>
                                <th>Yeni Satış</th>
                                <th>En Az Yeniden Satıs Mikatarı</th>
                                <th>Sonlandı</th>
                                <th>İşlemler</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptUrunler" runat="server" OnItemCommand="rptUrunler_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("ProductID") %></td>
                                        <td><%#Eval("ProductName") %></td>
                                        <td><%#Eval("SupplierID") %></td>
                                        <td><%#Eval("CategoryID") %></td>
                                        <td><%#Eval("QuantityPerUnit") %></td>
                                        <td><%#Eval("UnitPrice") %> $</td>
                                        <td><%#Eval("UnitsInStock") %></td>
                                        <td><%#Eval("UnitsOnOrder") %></td>
                                        <td><%#Eval("ReorderLevel") %></td>
                                        <td><%#Eval("Discontinued") %></td>
                                        <td>
                                            <asp:LinkButton ID="lnkbtn" class="btn btn-success btn-sm" CommandName="Sec" CommandArgument='<%#Eval("ProductID") %>' runat="server">Güncelle</asp:LinkButton>
                                            <asp:LinkButton ID="Lnkbtnsil" class="btn btn-danger btn-sm" CommandName="Sil" CommandArgument='<%#Eval("ProductID") %>' runat="server">Sil</asp:LinkButton>
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
