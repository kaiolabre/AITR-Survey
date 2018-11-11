<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="staffPage.aspx.cs" Inherits="AITR_Survey.staffPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AITR Survey</title>
    <link rel="stylesheet" href="StaffPageStyle.css" />
</head>
<body class="staff-body">
    <header>
        <div class="header-left">
            <a href="index.aspx"><img src="logo.png"></img></a>

        </div>
        <div class="header-right">
            <img src="login-icon.png" />
            <a href="loginPage.aspx">Login
            </a>
        </div>        
    </header>
    <section class="staff-header">
        <asp:Label ID="featureLabel" runat="server" Text="Label"></asp:Label><span class="smaller-text">Search for respondents:</span>
    </section>
     <main class="staff-main">       
         <div class="staff-main">
            <form id="searchForm" class="staff-form" runat="server">
                <div class="staff-option">
                    <div class="search-form">
                        
                     
                        <div class="main-content column">
                            <h1>Personalised Search</h1>
                            
                            
                            <div class="row">
                                <div class="staff-label">
                                <asp:Label ID="genderLabel" runat="server" Text="Gender: "></asp:Label>
                                </div>
                                    <asp:TextBox ID="GenderTextBox" runat="server" Class="form-textbox"></asp:TextBox>
                                <br />
                            </div>
                            
                            <asp:RequiredFieldValidator
                                    ID="StateRequiredFieldValidator"
                                    runat="server" Display="Dynamic"
                                    ErrorMessage="*Required!"
                                    ControlToValidate="GenderTextBox" ForeColor="White" Font-Size="X-Small" Class="validator"
                                    ValidationGroup="personalisedSearch"
                                ></asp:RequiredFieldValidator>
                            <br />
                            <div class="row">
                                <div class="staff-label">
                                <asp:Label ID="SuburbLabel" runat="server" Text="Suburb: "></asp:Label>
                                </div>
                                    <asp:TextBox ID="SuburbTextBox" runat="server" Class="form-textbox"></asp:TextBox>
                                <br />
                            </div>
                            
                            <asp:RequiredFieldValidator
                                    ID="SuburbRequiredFieldValidator"
                                    runat="server" Display="Dynamic"
                                    ErrorMessage="*Required!" ControlToValidate="SuburbTextBox" ForeColor="White" Font-Size="X-Small" Class="validator"
                                ValidationGroup="personalisedSearch"></asp:RequiredFieldValidator>
                            <br />
                            <div class="row">
                                <div class="staff-label">
                                <asp:Label ID="BankUsedLabel" runat="server" Text="Bank Used: "></asp:Label>
                                </div>
                                    <asp:TextBox ID="BankUsedTextBox" runat="server" Class="form-textbox"></asp:TextBox>
                                <br />
                            </div>
                            
                            <asp:RequiredFieldValidator
                                    ID="HomePostCodeRequiredFieldValidator"
                                    runat="server" Display="Dynamic"
                                    ErrorMessage="*Required!" ControlToValidate="BankUsedTextBox" ForeColor="White" Font-Size="X-Small" Class="validator"
                                ValidationGroup="personalisedSearch"></asp:RequiredFieldValidator>
                            <br />
                            <div class="row">
                                <div class="staff-label">
                                <asp:Label ID="BankServiceLabel" runat="server" Text="Bank Service: "></asp:Label>
                                </div>
                                    <asp:TextBox ID="BankServiceTextBox" runat="server" Class="form-textbox"></asp:TextBox>
                                <br />
                            </div>
                            
                            <asp:RequiredFieldValidator
                                    ID="EmailRequiredFieldValidator"
                                    runat="server" Display="Dynamic"
                                    ErrorMessage="*Required!" ControlToValidate="BankServiceTextBox" ForeColor="White" Font-Size="X-Small" Class="validator" ValidationGroup="personalisedSearch"></asp:RequiredFieldValidator>
                            <br />
                        </div>
                    
                        <div class="buttons" >
                            <asp:Button ID="searchButton" CssClass="searchButton" runat="server" Text="Search" BackColor="#00A8AA" BorderColor="#00A8AA" BorderStyle="None" Font-Bold="True" Font-Size="12" ForeColor="White" onClick="searchButton_Click" ValidationGroup="personalisedSearch" />
                        </div>
                     </div>
                    <div class="OR-section column">
                        <h1>OR</h1>
                    </div>
                    <div class="see-all column">
                        <h1>See All Respondents</h1>
                        <asp:Button ID="SearchAll" CssClass="searchAllButton" runat="server" Text="Search Them All" onClick="SearchAll_Click"/>
                    </div>
            
                </div>
           
                <div class="results">
                    <h1>Results</h1>
                    <asp:GridView ID="resultsGridView" runat="server"></asp:GridView>
                </div>
            </form>
         </div>
        
    </main>
    <footer>
        <p> <a href="contact.aspx">Contact Us</a></p>
        <p> <a href="about.aspx">About Us</a></p>
        <p> <a href="terms.aspx">Terms & Conditions</a></p>
        <br />
        <p>Kaio Labre - 5704</p>
    </footer>
  </body>
</html>
