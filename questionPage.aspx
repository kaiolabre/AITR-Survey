<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="questionPage.aspx.cs" Inherits="AITR_Survey.questionPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AITR Survey</title>
    <link rel="stylesheet" href="QuestionPageStyle.css"/>
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
    
    <form id="questionForm" runat="server">
        <main class="question-page-main">
            <div class="question-option">
                <asp:PlaceHolder ID="questionPlaceHolder" runat="server"></asp:PlaceHolder>
                <asp:BulletedList ID="selectedAnswerBulletedList" runat="server"></asp:BulletedList>
            </div>
           
             <div class="navigation-buttons">
                <div class="btn-left">
                    <asp:Button ID="Cancel" runat="server" CssClass="blueBtn" Text="Cancel" onClick="Cancel_Click"/>
                </div>
                <div class="btn-right">
                    <asp:Button ID="NextQuestionButton" CssClass="blueBtn" runat="server" Text="Next >" onClick="NextQuestionButton_Click"
                        />
                </div>
            </div>
       
        </main>
                     
    </form>
   
     <footer>
         <p> <a href="contact.aspx">Contact Us</a></p>
        <p> <a href="about.aspx">About Us</a></p>
        <p> <a href="terms.aspx">Terms & Conditions</a></p>
        <br />
        <p>Kaio Labre - 5704</p>
    </footer>
</body>
</html>
