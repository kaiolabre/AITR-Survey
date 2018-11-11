<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="endSurveyPage.aspx.cs" Inherits="AITR_Survey.WebForm3" %>

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
            <div class="main-header">
                <h1>THANK YOU!</h1>
            </div>
            <div class="main-content">
                <p>
                    &ensp;&emsp;&emsp;FOR TAKING OUR SURVEY!
            </div>
           <a href="index.aspx">
                <div class="survey-link">
                    GO TO HOME
                </div>
            </a>
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

</html>
