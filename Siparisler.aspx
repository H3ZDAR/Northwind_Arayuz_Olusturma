<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Siparisler.aspx.cs" Inherits="Siparisler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="row">
              <div class="col-md-12">
                <div class="x_panel">
                <div class="x_title">
                    <h2>Sipariş Ekleme Paneli</h2>
                  
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                    
                      <div class="col-md-6 col-sm-6 mb-3">
                          <asp:DropDownList ID="ddlMusteriID" runat="server" placeholder="Müşteri ID" class="form-control" OnSelectedIndexChanged="ddlMusteriID_SelectedIndexChanged" AutoPostBack="True">
                              <asp:ListItem Value="#">Müşteri Seç</asp:ListItem>
 						</asp:DropDownList>
					  </div>
                      <div class="col-md-6 col-sm-6 mb-3">
						 <asp:DropDownList ID="ddlPersonelID" runat="server"  placeholder="Personel ID" class="form-control">
                            <asp:ListItem Value="#">Personel Seç</asp:ListItem>
 						</asp:DropDownList>
					  </div>     
                      <div class="col-md-6 col-sm-6 ">
                          <div class="input-group">
                            <asp:TextBox ID="txtSatisTarihi" runat="server" CssClass="form-control" placeholder="Satış tarihi"></asp:TextBox>
                              <span class="input-group-btn" style="position: relative; z-index: 9999!important;" CssClass="custom-calendar">
                                <asp:ImageButton ID="ImgDateSatis" runat="server" ImageUrl="images/weekend.png" AlternateText="Select Date" OnClick="ImgDateSatis_Click" Height="35px" ImageAlign="AbsBottom" />  
                                  <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Visible="false" BackColor="#EDEDED" CssClass="custom-calendar"></asp:Calendar>
                              </span>
                          </div>
                    </div>
                      <div class="col-md-6 col-sm-6 ">
                          <div class="input-group">
                            <asp:TextBox ID="txtOdemeTarihi" runat="server" CssClass="form-control" placeholder="Ödeme tarihi"></asp:TextBox>
                              <span class="input-group-btn" style="position: relative; z-index: 9999!important;" CssClass="custom-calendar pull-left">
                                <asp:ImageButton ID="ImgDateOdeme" runat="server" ImageUrl="images/weekend.png" AlternateText="Select Date" OnClick="ImgDateOdeme_Click" Height="35px" />
                                  <asp:Calendar Align="Right" ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged" Visible="true" BackColor="#EDEDED" CssClass="custom-calendar "  ></asp:Calendar>
                              </span>
                          </div>
                    </div>
                      <div class="col-md-6 col-sm-6 ">
                          <div class="input-group">
                            <asp:TextBox ID="txtSevkTarihi" runat="server" CssClass="form-control" placeholder="Sevk Tarihi"></asp:TextBox>
                              <span class="input-group-btn" style="position: relative; z-index: 9998!important;">
                                <asp:ImageButton ID="ImgDateSevk" runat="server" ImageUrl="images/weekend.png" AlternateText="Select Date" OnClick="ImgDateSevk_Click" Height="35px" />
                                  <asp:Calendar ID="Calendar3" runat="server" OnSelectionChanged="Calendar3_SelectionChanged" Visible="false" BackColor="#EDEDED" CssClass="custom-calendar"></asp:Calendar>
                              </span>
                          </div>
                    </div>
                    
                      <div class="col-md-6 col-sm-6 mb-3">
						 <asp:DropDownList ID="ddlShipVia" runat="server"  placeholder="Şuradan Gönder" class="form-control">
                            <asp:ListItem Value="#">Şuradan Gönder</asp:ListItem>
 						</asp:DropDownList>
					  </div>
                      <div class="col-md-6 col-sm-6 mb-3">
                          <asp:TextBox ID="txtNakliyeUcreti" runat="server" class="form-control " placeholder="Nakliye Ücreti"></asp:TextBox>
                      </div>
                      <div class="col-md-6 col-sm-6 mb-3">
                          <asp:TextBox ID="txtSevkAdi" class="form-control" runat="server" placeholder="Sevk Adı"></asp:TextBox>
                      </div>

                      <div class="col-md-6 col-sm-6 mb-3">
                          <asp:TextBox ID="txtSevkAdresi" runat="server" class="form-control" placeholder="Sevk Adresi" TextMode="MultiLine" Rows="3"></asp:TextBox>
                      </div>
                      <div class="col-md-6 col-sm-6 mb-3">
                          <asp:TextBox ID="txtSevkSehri" class="form-control" runat="server" placeholder="Sevk Şehri"></asp:TextBox>
                      </div>
                      <div class="col-md-6 col-sm-6 mb-3">
                          <asp:TextBox ID="txtSevkBolgesi" runat="server" class="form-control " placeholder="Sevk Bölgesi"></asp:TextBox>
                      </div>
                      <div class="col-md-6 col-sm-6 mb-3">
                          <asp:TextBox ID="txtSevkPostaKodu" class="form-control" runat="server" placeholder="Sevk Posta Kodu"></asp:TextBox>
                      </div>
                      <div class="col-md-6 col-sm-6 mb-3">
                          <asp:TextBox ID="txtSevkUlkesi" class="form-control" runat="server" placeholder="Sevk Ülkesi"></asp:TextBox>
                      </div>
                      <div class="ln_solid"></div>
                      <div class="form-group row">
                        <div class="col-md-6 col-sm-9 ">
                            <asp:Button ID="Button3" runat="server" Text="Temizle" class="btn btn-dark btn-block" OnClick="btnEkle_Click" />
                        </div>
                          <div class="col-md-6 col-sm-9 ">
                            <asp:Button ID="btnEkle" runat="server" Text="Kaydet" class="btn btn-danger btn-block" OnClick="btnEkle_Click" />
                        </div>
                      </div>

                 
                  </div>
                </div>                  
                  <br />

              </div>
        <div class="col-md-12 col-sm-9  ">
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

              <div class="col-md-12 ">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Sipariş Listesi</h2>
                  
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                      <table class="table">
                      <thead>
                        <tr>
                            <th>ID</th>
                            <th>Müşteri ID</th>
                            <th>Personel ID</th>
                            <th>Satış Tarihi</th>
                            <th>Ödeme tarihi</th>
                            <th>Sevk Tarihi</th>
                            <th>ShipVia</th>
                            <th>Nakliye Ücreti</th>
                            <th>Sevk Adı</th>
                            <th>Sevk Adresi</th>
                            <th>Sevk Şehri</th>
                            <th>Sevk Bölgesi</th>
                            <th>Sevk Posta Kodu</th>
                            <th>Sevk Ülkesi</th>
                            
                            <th>İşlemler</th>
                        </tr>
                      </thead>
                          <tbody>
                          <asp:Repeater ID="rptSiparisler" runat="server" OnItemCommand="rptSiparisler_ItemCommand">
                              <ItemTemplate> 
                                    <tr>
                                        
                                          <th scope="row"><%#Eval("OrderID") %></th>
                                          <td><%#Eval("CustomerID") %></td>
                                          <td><%#Eval("EmployeeID") %></td>
                                          <td><%#Eval("OrderDate") %></td>
                                          <td><%#Eval("RequiredDate") %></td>
                                          <td><%#Eval("ShippedDate") %></td>
                                          <td><%#Eval("ShipVia") %>TL</td>
                                          <td><%#Eval("Freight") %> </td>
                                          <td><%#Eval("ShipName") %></td>
                                          <td><%#Eval("ShipAddress") %></td>
                                          <td><%#Eval("ShipCity") %></td>
                                          <td><%#Eval("ShipRegion") %></td>
                                          <td><%#Eval("ShipPostalCode") %></td>
                                          <td><%#Eval("ShipCountry") %></td>
                             
                                         <td>
                                              <asp:LinkButton ID="lnkbtn"  class="btn btn-success btn-sm" CommandName="Sec" CommandArgument='<%#Eval("OrderID") %>'  runat="server">Güncelle</asp:LinkButton>
                                         </td>
                                         <td>
                                              <asp:LinkButton ID="LinkButton2"  class="btn btn-danger btn-sm" CommandName="Sil" CommandArgument='<%#Eval("OrderID") %>'  runat="server">Sil</asp:LinkButton>
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

