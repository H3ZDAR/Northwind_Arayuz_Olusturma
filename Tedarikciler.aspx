<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Tedarikciler.aspx.cs" Inherits="Tedarikciler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Tedarikçi Ekleme Paneli</h2>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <div class="col-md-6 col-sm-6 mb-3">
                        <asp:TextBox ID="txtSupplierID" runat="server" class="form-control" placeholder="Müşteri No"></asp:TextBox>
                    </div>
                    <div class="col-md-6 col-sm-6 mb-3">
                        <asp:TextBox ID="txtSirketAdi" runat="server" class="form-control" placeholder="Şirket Adı"></asp:TextBox>
                    </div>
                    <div class="col-md-6 col-sm-6 mb-3">
                        <asp:TextBox ID="txtMusteriAdi" class="form-control" runat="server" placeholder="Müşteri Adı"></asp:TextBox>
                    </div>
                    <div class="col-md-6 col-sm-6 mb-3">
                        <asp:TextBox ID="txtMusteriUnvani" runat="server" class="form-control" placeholder="Müşteri Unvanı"></asp:TextBox>
                    </div>
                    <div class="col-md-6 col-sm-6 mb-3">
                        <asp:TextBox ID="txtAdres" class="form-control" runat="server" placeholder="Adres" TextMode="MultiLine" Rows="5"></asp:TextBox>
                    </div>
                    <div class="col-md-6 col-sm-6 mb-3">
                        <asp:TextBox ID="txtSehir" runat="server" class="form-control " placeholder="Şehir"></asp:TextBox>
                    </div>
                    <div class="col-md-6 col-sm-6 mb-3">
                        <asp:TextBox ID="txtBolge" class="form-control" runat="server" placeholder="Bölge"></asp:TextBox>
                    </div>
                    <div class="col-md-6 col-sm-6 mb-3">
                        <asp:TextBox ID="txtPostaKodu" runat="server" class="form-control" placeholder="Posta Kodu"></asp:TextBox>
                    </div>
                    <div class="col-md-6 col-sm-6 mb-3">
                        <asp:DropDownList ID="ddlUlke" runat="server"  placeholder="Bölge" class="form-control">
							<asp:ListItem Value="#">Ülke Seçiniz</asp:ListItem>
							<asp:ListItem Value="VI">ABD Virgin Adaları</asp:ListItem>
							<asp:ListItem Value="AF">Afganistan</asp:ListItem>
							<asp:ListItem Value="AX">Aland Adaları</asp:ListItem>
							<asp:ListItem Value="DE">Almanya</asp:ListItem>
							<asp:ListItem Value="US">Amerika Birleşik Devletleri</asp:ListItem>
							<asp:ListItem Value="UM">Amerika Birleşik Devletleri Küçük Dış Adaları</asp:ListItem>
							<asp:ListItem Value="AS">Amerikan Samoası</asp:ListItem>
							<asp:ListItem Value="AD">Andora</asp:ListItem>
							<asp:ListItem Value="AO">Angola</asp:ListItem>
							<asp:ListItem Value="AI">Anguilla</asp:ListItem>
							<asp:ListItem Value="AQ">Antarktika</asp:ListItem>
							<asp:ListItem Value="AG">Antigua ve Barbuda</asp:ListItem>
							<asp:ListItem Value="AR">Arjantin</asp:ListItem>
							<asp:ListItem Value="AL">Arnavutluk</asp:ListItem>
							<asp:ListItem Value="AW">Aruba</asp:ListItem>
							<asp:ListItem Value="QU">Avrupa Birliği</asp:ListItem>
							<asp:ListItem Value="AU">Avustralya</asp:ListItem>
							<asp:ListItem Value="AT">Avusturya</asp:ListItem>
							<asp:ListItem Value="AZ">Azerbaycan</asp:ListItem>
							<asp:ListItem Value="BS">Bahamalar</asp:ListItem>
							<asp:ListItem Value="BH">Bahreyn</asp:ListItem>
							<asp:ListItem Value="BD">Bangladeş</asp:ListItem>
							<asp:ListItem Value="BB">Barbados</asp:ListItem>
							<asp:ListItem Value="EH">Batı Sahara</asp:ListItem>
							<asp:ListItem Value="BZ">Belize</asp:ListItem>
							<asp:ListItem Value="BE">Belçika</asp:ListItem>
							<asp:ListItem Value="BJ">Benin</asp:ListItem>
							<asp:ListItem Value="BM">Bermuda</asp:ListItem>
							<asp:ListItem Value="BY">Beyaz Rusya</asp:ListItem>
							<asp:ListItem Value="BT">Bhutan</asp:ListItem>
							<asp:ListItem Value="ZZ">Bilinmeyen veya Geçersiz Bölge</asp:ListItem>
							<asp:ListItem Value="AE">Birleşik Arap Emirlikleri</asp:ListItem>
							<asp:ListItem Value="GB">Birleşik Krallık</asp:ListItem>
							<asp:ListItem Value="BO">Bolivya</asp:ListItem>
							<asp:ListItem Value="BA">Bosna Hersek</asp:ListItem>
							<asp:ListItem Value="BW">Botsvana</asp:ListItem>
							<asp:ListItem Value="BV">Bouvet Adası</asp:ListItem>
							<asp:ListItem Value="BR">Brezilya</asp:ListItem>
							<asp:ListItem Value="BN">Brunei</asp:ListItem>
							<asp:ListItem Value="BG">Bulgaristan</asp:ListItem>
							<asp:ListItem Value="BF">Burkina Faso</asp:ListItem>
							<asp:ListItem Value="BI">Burundi</asp:ListItem>
							<asp:ListItem Value="CV">Cape Verde</asp:ListItem>
							<asp:ListItem Value="GI">Cebelitarık</asp:ListItem>
							<asp:ListItem Value="DZ">Cezayir</asp:ListItem>
							<asp:ListItem Value="CX">Christmas Adası</asp:ListItem>
							<asp:ListItem Value="DJ">Cibuti</asp:ListItem>
							<asp:ListItem Value="CC">Cocos Adaları</asp:ListItem>
							<asp:ListItem Value="CK">Cook Adaları</asp:ListItem>
							<asp:ListItem Value="TD">Çad</asp:ListItem>
							<asp:ListItem Value="CZ">Çek Cumhuriyeti</asp:ListItem>
							<asp:ListItem Value="CN">Çin</asp:ListItem>
							<asp:ListItem Value="DK">Danimarka</asp:ListItem>
							<asp:ListItem Value="DM">Dominik</asp:ListItem>
							<asp:ListItem Value="DO">Dominik Cumhuriyeti</asp:ListItem>
							<asp:ListItem Value="TL">Doğu Timor</asp:ListItem>
							<asp:ListItem Value="EC">Ekvator</asp:ListItem>
							<asp:ListItem Value="GQ">Ekvator Ginesi</asp:ListItem>
							<asp:ListItem Value="SV">El Salvador</asp:ListItem>
							<asp:ListItem Value="ID">Endonezya</asp:ListItem>
							<asp:ListItem Value="ER">Eritre</asp:ListItem>
							<asp:ListItem Value="AM">Ermenistan</asp:ListItem>
							<asp:ListItem Value="EE">Estonya</asp:ListItem>
							<asp:ListItem Value="ET">Etiyopya</asp:ListItem>
							<asp:ListItem Value="FK">Falkland Adaları (Malvinalar)</asp:ListItem>
							<asp:ListItem Value="FO">Faroe Adaları</asp:ListItem>
							<asp:ListItem Value="MA">Fas</asp:ListItem>
							<asp:ListItem Value="FJ">Fiji</asp:ListItem>
							<asp:ListItem Value="CI">Fildişi Sahilleri</asp:ListItem>
							<asp:ListItem Value="PH">Filipinler</asp:ListItem>
							<asp:ListItem Value="PS">Filistin Bölgesi</asp:ListItem>
							<asp:ListItem Value="FI">Finlandiya</asp:ListItem>
							<asp:ListItem Value="FR">Fransa</asp:ListItem>
							<asp:ListItem Value="GF">Fransız Guyanası</asp:ListItem>
							<asp:ListItem Value="TF">Fransız Güney Bölgeleri</asp:ListItem>
							<asp:ListItem Value="PF">Fransız Polinezyası</asp:ListItem>
							<asp:ListItem Value="GA">Gabon</asp:ListItem>
							<asp:ListItem Value="GM">Gambia</asp:ListItem>
							<asp:ListItem Value="GH">Gana</asp:ListItem>
							<asp:ListItem Value="GN">Gine</asp:ListItem>
							<asp:ListItem Value="GW">Gine-Bissau</asp:ListItem>
							<asp:ListItem Value="GD">Granada</asp:ListItem>
							<asp:ListItem Value="GL">Grönland</asp:ListItem>
							<asp:ListItem Value="GP">Guadeloupe</asp:ListItem>
							<asp:ListItem Value="GU">Guam</asp:ListItem>
							<asp:ListItem Value="GT">Guatemala</asp:ListItem>
							<asp:ListItem Value="GG">Guernsey</asp:ListItem>
							<asp:ListItem Value="GY">Guyana</asp:ListItem>
							<asp:ListItem Value="ZA">Güney Afrika</asp:ListItem>
							<asp:ListItem Value="GS">Güney Georgia ve Güney Sandwich Adaları</asp:ListItem>
							<asp:ListItem Value="KR">Güney Kore</asp:ListItem>
							<asp:ListItem Value="CY">Güney Kıbrıs Rum Kesimi</asp:ListItem>
							<asp:ListItem Value="GE">Gürcistan</asp:ListItem>
							<asp:ListItem Value="HT">Haiti</asp:ListItem>
							<asp:ListItem Value="HM">Heard Adası ve McDonald Adaları</asp:ListItem>
							<asp:ListItem Value="IN">Hindistan</asp:ListItem>
							<asp:ListItem Value="IO">Hint Okyanusu İngiliz Bölgesi</asp:ListItem>
							<asp:ListItem Value="NL">Hollanda</asp:ListItem>
							<asp:ListItem Value="AN">Hollanda Antilleri</asp:ListItem>
							<asp:ListItem Value="HN">Honduras</asp:ListItem>
							<asp:ListItem Value="HK">Hong Kong SAR - Çin</asp:ListItem>
							<asp:ListItem Value="HR">Hırvatistan</asp:ListItem>
							<asp:ListItem Value="IQ">Irak</asp:ListItem>
							<asp:ListItem Value="VG">İngiliz Virgin Adaları</asp:ListItem>
							<asp:ListItem Value="IR">İran</asp:ListItem>
							<asp:ListItem Value="IE">İrlanda</asp:ListItem>
							<asp:ListItem Value="ES">İspanya</asp:ListItem>
							<asp:ListItem Value="IL">İsrail</asp:ListItem>
							<asp:ListItem Value="SE">İsveç</asp:ListItem>
							<asp:ListItem Value="CH">İsviçre</asp:ListItem>
							<asp:ListItem Value="IT">İtalya</asp:ListItem>
							<asp:ListItem Value="IS">İzlanda</asp:ListItem>
							<asp:ListItem Value="JM">Jamaika</asp:ListItem>
							<asp:ListItem Value="JP">Japonya</asp:ListItem>
							<asp:ListItem Value="JE">Jersey</asp:ListItem>
							<asp:ListItem Value="KH">Kamboçya</asp:ListItem>
							<asp:ListItem Value="CM">Kamerun</asp:ListItem>
							<asp:ListItem Value="CA">Kanada</asp:ListItem>
							<asp:ListItem Value="ME">Karadağ</asp:ListItem>
							<asp:ListItem Value="QA">Katar</asp:ListItem>
							<asp:ListItem Value="KY">Kayman Adaları</asp:ListItem>
							<asp:ListItem Value="KZ">Kazakistan</asp:ListItem>
							<asp:ListItem Value="KE">Kenya</asp:ListItem>
							<asp:ListItem Value="KI">Kiribati</asp:ListItem>
							<asp:ListItem Value="CO">Kolombiya</asp:ListItem>
							<asp:ListItem Value="KM">Komorlar</asp:ListItem>
							<asp:ListItem Value="CG">Kongo</asp:ListItem>
							<asp:ListItem Value="CD">Kongo Demokratik Cumhuriyeti</asp:ListItem>
							<asp:ListItem Value="CR">Kosta Rika</asp:ListItem>
							<asp:ListItem Value="KW">Kuveyt</asp:ListItem>
							<asp:ListItem Value="KP">Kuzey Kore</asp:ListItem>
							<asp:ListItem Value="MP">Kuzey Mariana Adaları</asp:ListItem>
							<asp:ListItem Value="CU">Küba</asp:ListItem>
							<asp:ListItem Value="KG">Kırgızistan</asp:ListItem>
							<asp:ListItem Value="LA">Laos</asp:ListItem>
							<asp:ListItem Value="LS">Lesotho</asp:ListItem>
							<asp:ListItem Value="LV">Letonya</asp:ListItem>
							<asp:ListItem Value="LR">Liberya</asp:ListItem>
							<asp:ListItem Value="LY">Libya</asp:ListItem>
							<asp:ListItem Value="LI">Liechtenstein</asp:ListItem>
							<asp:ListItem Value="LT">Litvanya</asp:ListItem>
							<asp:ListItem Value="LB">Lübnan</asp:ListItem>
							<asp:ListItem Value="LU">Lüksemburg</asp:ListItem>
							<asp:ListItem Value="HU">Macaristan</asp:ListItem>
							<asp:ListItem Value="MG">Madagaskar</asp:ListItem>
							<asp:ListItem Value="MO">Makao S.A.R. Çin</asp:ListItem>
							<asp:ListItem Value="MK">Makedonya</asp:ListItem>
							<asp:ListItem Value="MW">Malavi</asp:ListItem>
							<asp:ListItem Value="MV">Maldivler</asp:ListItem>
							<asp:ListItem Value="MY">Malezya</asp:ListItem>
							<asp:ListItem Value="ML">Mali</asp:ListItem>
							<asp:ListItem Value="MT">Malta</asp:ListItem>
							<asp:ListItem Value="IM">Man Adası</asp:ListItem>
							<asp:ListItem Value="MH">Marshall Adaları</asp:ListItem>
							<asp:ListItem Value="MQ">Martinik</asp:ListItem>
							<asp:ListItem Value="MU">Mauritius</asp:ListItem>
							<asp:ListItem Value="YT">Mayotte</asp:ListItem>
							<asp:ListItem Value="MX">Meksika</asp:ListItem>
							<asp:ListItem Value="FM">Mikronezya Federal Eyaletleri</asp:ListItem>
							<asp:ListItem Value="MD">Moldovya Cumhuriyeti</asp:ListItem>
							<asp:ListItem Value="MC">Monako</asp:ListItem>
							<asp:ListItem Value="MS">Montserrat</asp:ListItem>
							<asp:ListItem Value="MR">Moritanya</asp:ListItem>
							<asp:ListItem Value="MZ">Mozambik</asp:ListItem>
							<asp:ListItem Value="MN">Moğolistan</asp:ListItem>
							<asp:ListItem Value="MM">Myanmar</asp:ListItem>
							<asp:ListItem Value="EG">Mısır</asp:ListItem>
							<asp:ListItem Value="NA">Namibya</asp:ListItem>
							<asp:ListItem Value="NR">Nauru</asp:ListItem>
							<asp:ListItem Value="NP">Nepal</asp:ListItem>
							<asp:ListItem Value="NE">Nijer</asp:ListItem>
							<asp:ListItem Value="NG">Nijerya</asp:ListItem>
							<asp:ListItem Value="NI">Nikaragua</asp:ListItem>
							<asp:ListItem Value="NU">Niue</asp:ListItem>
							<asp:ListItem Value="NF">Norfolk Adası</asp:ListItem>
							<asp:ListItem Value="NO">Norveç</asp:ListItem>
							<asp:ListItem Value="CF">Orta Afrika Cumhuriyeti</asp:ListItem>
							<asp:ListItem Value="UZ">Özbekistan</asp:ListItem>
							<asp:ListItem Value="PK">Pakistan</asp:ListItem>
							<asp:ListItem Value="PW">Palau</asp:ListItem>
							<asp:ListItem Value="PA">Panama</asp:ListItem>
							<asp:ListItem Value="PG">Papua Yeni Gine</asp:ListItem>
							<asp:ListItem Value="PY">Paraguay</asp:ListItem>
							<asp:ListItem Value="PE">Peru</asp:ListItem>
							<asp:ListItem Value="PN">Pitcairn</asp:ListItem>
							<asp:ListItem Value="PL">Polonya</asp:ListItem>
							<asp:ListItem Value="PT">Portekiz</asp:ListItem>
							<asp:ListItem Value="PR">Porto Riko</asp:ListItem>
							<asp:ListItem Value="RE">Reunion</asp:ListItem>
							<asp:ListItem Value="RO">Romanya</asp:ListItem>
							<asp:ListItem Value="RW">Ruanda</asp:ListItem>
							<asp:ListItem Value="RU">Rusya Federasyonu</asp:ListItem>
							<asp:ListItem Value="SH">Saint Helena</asp:ListItem>
							<asp:ListItem Value="KN">Saint Kitts ve Nevis</asp:ListItem>
							<asp:ListItem Value="LC">Saint Lucia</asp:ListItem>
							<asp:ListItem Value="PM">Saint Pierre ve Miquelon</asp:ListItem>
							<asp:ListItem Value="VC">Saint Vincent ve Grenadinler</asp:ListItem>
							<asp:ListItem Value="WS">Samoa</asp:ListItem>
							<asp:ListItem Value="SM">San Marino</asp:ListItem>
							<asp:ListItem Value="ST">Sao Tome ve Principe</asp:ListItem>
							<asp:ListItem Value="SN">Senegal</asp:ListItem>
							<asp:ListItem Value="SC">Seyşeller</asp:ListItem>
							<asp:ListItem Value="SL">Sierra Leone</asp:ListItem>
							<asp:ListItem Value="SG">Singapur</asp:ListItem>
							<asp:ListItem Value="SK">Slovakya</asp:ListItem>
							<asp:ListItem Value="SI">Slovenya</asp:ListItem>
							<asp:ListItem Value="SB">Solomon Adaları</asp:ListItem>
							<asp:ListItem Value="SO">Somali</asp:ListItem>
							<asp:ListItem Value="LK">Sri Lanka</asp:ListItem>
							<asp:ListItem Value="SD">Sudan</asp:ListItem>
							<asp:ListItem Value="SR">Surinam</asp:ListItem>
							<asp:ListItem Value="SY">Suriye</asp:ListItem>
							<asp:ListItem Value="SA">Suudi Arabistan</asp:ListItem>
							<asp:ListItem Value="SJ">Svalbard ve Jan Mayen</asp:ListItem>
							<asp:ListItem Value="SZ">Svaziland</asp:ListItem>
							<asp:ListItem Value="RS">Sırbistan</asp:ListItem>
							<asp:ListItem Value="CS">Sırbistan-Karadağ</asp:ListItem>
							<asp:ListItem Value="CL">Şili</asp:ListItem>
							<asp:ListItem Value="TJ">Tacikistan</asp:ListItem>
							<asp:ListItem Value="TZ">Tanzanya</asp:ListItem>
							<asp:ListItem Value="TH">Tayland</asp:ListItem>
							<asp:ListItem Value="TW">Tayvan</asp:ListItem>
							<asp:ListItem Value="TG">Togo</asp:ListItem>
							<asp:ListItem Value="TK">Tokelau</asp:ListItem>
							<asp:ListItem Value="TO">Tonga</asp:ListItem>
							<asp:ListItem Value="TT">Trinidad ve Tobago</asp:ListItem>
							<asp:ListItem Value="TN">Tunus</asp:ListItem>
							<asp:ListItem Value="TC">Turks ve Caicos Adaları</asp:ListItem>
							<asp:ListItem Value="TV">Tuvalu</asp:ListItem>
							<asp:ListItem Value="TR">Türkiye</asp:ListItem>
							<asp:ListItem Value="TM">Türkmenistan</asp:ListItem>
							<asp:ListItem Value="UG">Uganda</asp:ListItem>
							<asp:ListItem Value="UA">Ukrayna</asp:ListItem>
							<asp:ListItem Value="OM">Umman</asp:ListItem>
							<asp:ListItem Value="UY">Uruguay</asp:ListItem>
							<asp:ListItem Value="QO">Uzak Okyanusya</asp:ListItem>
							<asp:ListItem Value="JO">Ürdün</asp:ListItem>
							<asp:ListItem Value="VU">Vanuatu</asp:ListItem>
							<asp:ListItem Value="VA">Vatikan</asp:ListItem>
							<asp:ListItem Value="VE">Venezuela</asp:ListItem>
							<asp:ListItem Value="VN">Vietnam</asp:ListItem>
							<asp:ListItem Value="WF">Wallis ve Futuna</asp:ListItem>
							<asp:ListItem Value="YE">Yemen</asp:ListItem>
							<asp:ListItem Value="NC">Yeni Kaledonya</asp:ListItem>
							<asp:ListItem Value="NZ">Yeni Zelanda</asp:ListItem>
							<asp:ListItem Value="GR">Yunanistan</asp:ListItem>
							<asp:ListItem Value="ZM">Zambiya</asp:ListItem>
							<asp:ListItem Value="ZW">Zimbabve</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-6 col-sm-6 mb-3">
                        <asp:TextBox ID="txtTelefon" runat="server" class="form-control " placeholder="Telefon"></asp:TextBox>
                    </div>
                    <div class="col-md-6 col-sm-6 mb-3">
                        <asp:TextBox ID="txtFaks" class="form-control" runat="server" placeholder="Faks"></asp:TextBox>
                    </div>
                    <div class="col-md-6 col-sm-6 mb-3">
                        <asp:TextBox ID="txtAnaSayfa" class="form-control" runat="server" placeholder="Ana Sayfa"></asp:TextBox>
                    </div>
                    <div class="ln_solid"></div>
                    <div class="form-group row">
                        <div class="col-md-6 col-sm-9">
                            <asp:Button ID="btnTemizle" runat="server" Text="Temizle" class="btn btn-dark btn-block" OnClick="btnTemizle_Click" />
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
        <div class="col-md-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Tedarikçi Listesi</h2>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <table class="table">
                        <thead>
                            <tr>
                                <th>Tedarikçi No</th>
                                <th>Şirket Adı</th>
                                <th>Müşteri Adı</th>
                                <th>Müşteri Unvanı</th>
                                <th>Adres</th>
                                <th>Şehir</th>
                                <th>Bölge</th>
                                <th>Posta Kodu</th>
                                <th>Ülke</th>
                                <th>Telefon</th>
                                <th>Faks</th>
                                <%--<th>Ana Sayfa</th>--%>
                                <th>İşlemler</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptTedarikciler" runat="server" OnItemCommand="rptTedarikciler_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <th scope="row"><%#Eval("SupplierID") %></th>
                                        <td><%#Eval("CompanyName") %></td>
                                        <td><%#Eval("ContactName") %></td>
                                        <td><%#Eval("ContactTitle") %></td>
                                        <td><%#Eval("Address") %></td>
                                        <td><%#Eval("City") %></td>
                                        <td><%#Eval("Region") %></td>
                                        <td><%#Eval("PostalCode") %></td>
                                        <td><%#Eval("Country") %></td>
                                        <td><%#Eval("Phone") %></td>
                                        <td><%#Eval("Fax") %></td>
                                        <%--<td><%#Eval("HomePage") %></td>--%>
                                        <td>
                                            <asp:LinkButton ID="lnkbtn" class="btn btn-success btn-sm" CommandName="Sec" CommandArgument='<%#Eval("SupplierID") %>' runat="server">Güncelle</asp:LinkButton>
                                            
											<asp:LinkButton ID="LinkButton2" class="btn btn-danger btn-sm" CommandName="Sil" CommandArgument='<%#Eval("SupplierID") %>' runat="server">Sil</asp:LinkButton>
                                        
                                            
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
