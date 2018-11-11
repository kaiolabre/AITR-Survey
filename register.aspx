<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="AITR_Survey.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AITR Survey</title>
    <link rel="stylesheet" href="styles.css"/>
</head>
<body>
    <header>
        <div class="header-left">
            <a href="index.aspx"><img src="logo.png"/></a>

        </div>
        <div class="header-right">
            <img src="login-icon.png"/>
            <a href="loginPage.aspx">Login
            </a>
        </div>        
    </header>
    <main class="index-main">
       <div class="centralise">
            <div class="register-header">
                <h1>Register</h1>
                <a href="index.aspx"><img src=""/></a>
            </div>
            
           
            <form id="registerForm" runat="server">
                <div class="main-content">
                    <div class="form-label">
                        <asp:Label ID="firstNameLabel" runat="server" Text="Given Names:"></asp:Label>
                    </div>
                        <asp:TextBox ID="firstNameTextBox" runat="server" Class="form-textbox"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator
                            ID="firstNameRequiredFieldValidator"
                            runat="server" Display="Dynamic"
                            ErrorMessage="*First Name is required!" ControlToValidate="firstNameTextBox" ForeColor="White" Font-Size="X-Small" Class="validator"></asp:RequiredFieldValidator>
                    <br />

                    <div class="form-label">
                        <asp:Label ID="lastNameLabel" runat="server" Text="Last Name:"></asp:Label>
                    </div>
                    <asp:TextBox CssClass="form-textbox" ID="lastNameTextBox" runat="server"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator
                            ID="lastNameRequiredFieldValidator"
                            runat="server" Display="Dynamic"
                            ErrorMessage="*Last Name is required!" ControlToValidate="lastNameTextBox" ForeColor="White" Font-Size="X-Small" Font-Underline="False" Class="validator"></asp:RequiredFieldValidator>
                        <br />

                    <div class="form-label">
                        <asp:Label ID="mobilephoneLabel" runat="server" Text="Mobile Phone:"></asp:Label>

                    </div>
                    <asp:TextBox class="form-textbox" ID="mobilephoneTextBox" runat="server"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator
                            ID="mobilephoneRequiredFieldValidator"
                            runat="server" Display="Dynamic"
                            ErrorMessage="*Mobile Phone is required!" ControlToValidate="mobilephoneTextBox" ForeColor="White" Font-Size="X-Small" Class="validator"></asp:RequiredFieldValidator>
                    
                    <br />

                    <div class="form-label">
                        <asp:Label ID="dobLabel" runat="server" Text="Date of Birth:"></asp:Label>

                    </div>
                    <asp:TextBox class="form-textbox" ID="dateofbirthTextBox" runat="server" placeholder="(DD/MM/YY)"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1"
                            runat="server" Display="Dynamic"
                            ErrorMessage="*Date of birth is required!" ControlToValidate="dateofbirthTextBox" ForeColor="White" Font-Size="X-Small" Class="validator"></asp:RequiredFieldValidator>
                    <asp:RangeValidator
                        ID="DateRangeValidator" 
                        runat="server" 
                        ErrorMessage="*Data must be a valid format (DD/MM/YY) and between 1900 and today." 
                        Display="Dynamic" 
                        Type="Date" 
                        MaximumValue="19/04/2018"
                        MinimumValue="01/01/1900"
                        ForeColor="white" 
                        ControlToValidate="dateofbirthTextBox" Font-Size="X-Small" Class="validator"
                        ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"></asp:RangeValidator>
                    </div>
                    
                <div class="buttons" >
                    <asp:Button ID="anonymousButton" CssClass="anonymousButton" runat="server" Text="I want to be anonymous" CausesValidation="False" BackColor="#047879" BorderColor="#047879" BorderStyle="None" BorderWidth="0" Font-Underline="True" ForeColor="White" OnClick="anonymousButton_Click"/>
                    <asp:Button ID="registerButton" CssClass="registerButton" runat="server" Text="Take The Survey >" BackColor="White" BorderColor="White" BorderStyle="None" Font-Bold="True" Font-Size="17" ForeColor="#00A8AA" onClick="registerButton_Click"/>
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
