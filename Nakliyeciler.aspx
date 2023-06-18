<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Nakliyeciler.aspx.cs" Inherits="Nakliyeciler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Nakliyeci Ekleme Paneli</h2>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <div class="col-md-6 col-sm-6 mb-3">
                        <asp:TextBox ID="txtSirketAdi" runat="server" class="form-control" placeholder="Şirket Adı"></asp:TextBox>
                    </div>
                    <div class="col-md-6 col-sm-6 mb-3">
                        <asp:TextBox ID="txtTelefon" runat="server" class="form-control" placeholder="Telefon"></asp:TextBox>
                    </div>
                    <div class="ln_solid"></div>
                    <div class="form-group row">
                        <div class="col-md-6 col- mb-3">
                            <asp:Button ID="btnTemizle" runat="server" Text="Temizle" class="btn btn-dark btn-block" OnClick="btnTemizle_Click" />
                        </div>
                        <div class="col-md-6 col- mb-3">
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
        <div class="col-md-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Nakliyeci Listesi</h2>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <table class="table">
                        <thead>
                            <tr>
                                <th>Nakliyeci No</th>
                                <th>Şirket Adı</th>
                                <th>Telefon</th>
                                <th>İşlemler</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptNakliyeciler" runat="server" OnItemCommand="rptNakliyeciler_ItemCommand">
                                <ItemTemplate> 
                                    <tr>
                                        <th scope="row"><%#Eval("ShipperID") %></th>
                                        <td><%#Eval("CompanyName") %></td>
                                        <td><%#Eval("Phone") %></td>
                                        <td>
                                            <asp:LinkButton ID="lnkbtn" class="btn btn-success btn-sm" CommandName="Sec" CommandArgument='<%#Eval("ShipperID") %>' runat="server">Güncelle</asp:LinkButton>
                                             <asp:LinkButton ID="LinkButton2" class="btn btn-danger btn-sm" CommandName="Sil" CommandArgument='<%#Eval("ShipperID") %>' runat="server">Sil</asp:LinkButton>
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
