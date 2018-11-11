<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginPage.aspx.cs" Inherits="AITR_Survey.loginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AITR Survey</title>
    <link rel="stylesheet" href="styles.css">
</head>
<body>
    <header>
        <div class="header-left">
            <a href="index.aspx"><img src="logo.png"></img></a>

        </div>
        <div class="header-right">
            <img src="login-icon.png">
            <a href="loginPage.aspx">Login
            </a>
        </div>        
    </header>
    <main class="index-main">
       <div class="centralise">
            <div class="register-header">
                <h1>Staff Login</h1>
                <a href="index.aspx"></a>
            </div>
            
           
            <form id="loginForm" runat="server">
               
                <div class="main-content">
                    <div class="form-label">
                        <asp:Label ID="userNameLabel" runat="server" Text="Username: "></asp:Label>
                    </div>
                        <asp:TextBox ID="usernameTextBox" runat="server" Class="form-textbox"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator
                            ID="usernameRequiredFieldValidator"
                            runat="server" Display="Dynamic"
                            ErrorMessage="*Username is required!" ControlToValidate="usernameTextBox" ForeColor="White" Font-Size="X-Small" Class="validator"></asp:RequiredFieldValidator>
                    <br />

                    <div class="form-label">
                        <asp:Label ID="passwordLabel" runat="server" Text="Password:"></asp:Label>
                    </div>
                    <asp:TextBox CssClass="form-textbox" ID="passwordTextBox" runat="server" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator
                            ID="lastNameRequiredFieldValidator"
                            runat="server" Display="Dynamic"
                            ErrorMessage="*Password is required!" ControlToValidate="passwordTextBox" ForeColor="White" Font-Size="X-Small" Font-Underline="False" Class="validator"></asp:RequiredFieldValidator>
                    <br />
                    <div >
                        
                        <asp:Label ID="errorMsg" runat="server" Text="" style="margin-bottom:10px; color:yellow;"></asp:Label>
                    </div>
                    </div>
                    <br />
                <div class="buttons" >
                    <asp:Button ID="LoginButton" CssClass="registerButton" runat="server" Text="Login" BackColor="White" BorderColor="White" BorderStyle="None" Font-Bold="True" Font-Size="17" ForeColor="#00A8AA" onClick="LoginButton_Click"/>
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
