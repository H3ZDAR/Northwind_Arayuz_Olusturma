<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Kullancilar.aspx.cs" Inherits="Kullancilar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="row">
              <div class="col-md-6 ">
                <div class="x_panel">
                <div class="x_title">
                    <h2>Kullanıcı Ekleme Paneli</h2>
                  
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                    <br>
                  
                      <div class="col-md-6 col-sm-6">

                          <asp:TextBox ID="txtAdi" runat="server" class="form-control" placeholder="Ad"></asp:TextBox>
                        
                      
                      </div>

                      <div class="col-md-6 col-sm-6">
                          <asp:TextBox ID="txtSoyadi" class="form-control" runat="server" placeholder="Soyad"></asp:TextBox>
                       
                     
                      </div>

                      <div class="col-md-6 col-sm-6 ">
                          <asp:TextBox ID="txtTel" runat="server" class="form-control" placeholder="Telefon no"></asp:TextBox>
                      
                        
                     
                      </div>

                      <div class="col-md-6 col-sm-6  ">
                          <asp:TextBox ID="txtTC" class="form-control" runat="server" placeholder="TC"></asp:TextBox>


                      </div>
                       <div class="col-md-6 col-sm-6">
                          <asp:TextBox ID="txtSifre" runat="server" class="form-control " placeholder="Şifre"></asp:TextBox>
                      
                        
                  
                      </div>

                        <div class="col-md-6 col-sm-6">
                          
                            <asp:DropDownList ID="drpGruplar" class="form-control " runat="server"></asp:DropDownList>
                        
                  
                      </div>


                    
                      <div class="ln_solid"></div>
                      <div class="form-group row">
                        <div class="col-md-9 col-sm-9  offset-md-3">
                            <asp:Button ID="btnEkle" runat="server" Text="Kaydet" class="btn btn-success" OnClick="btnEkle_Click" />
                         
                        </div>
                      </div>

                 
                  </div>
                </div>

               

           


              </div>

              <div class="col-md-6 ">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Kullanıcı Listesi</h2>
                  
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                  

                      <table class="table">
                      <thead>
                        <tr>
                            <th>ID</th>
                            <th>Grubu</th>
                          
                          <th>Adi</th>
                          <th>Soyadi</th>
                          <th>Tel</th>
                            <th>TC</th>
                            
                            <th>İşlemler</th>
                        </tr>
                      </thead>
                          <tbody>
                          <asp:Repeater ID="rptKullanicilar" runat="server" OnItemCommand="rptKullanicilar_ItemCommand">
                              <ItemTemplate>


                                  
                        <tr>
                          <th scope="row"><%#Eval("KullaniciID") %></th>
                            <td><%#Eval("GrupAdi") %></td>
                          <td><%#Eval("Adi") %></td>
                          <td><%#Eval("Soyadi") %></td>
                          <td><%#Eval("Tel") %></td>
                             <td><%#Eval("TC") %></td>
                            
                          <td>
                              <asp:LinkButton ID="lnkbtn"  class="btn btn-success btn-sm" CommandName="Sec" CommandArgument='<%#Eval("KullaniciID") %>'  runat="server">Seç</asp:LinkButton>
                             
                          </td>
                        </tr>
                              </ItemTemplate>


                          </asp:Repeater>
                              </tbody>
                    </table>


                  </div>
                </div>
              </div>


              
            </div>

</asp:Content>

