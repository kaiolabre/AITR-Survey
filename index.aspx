<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AITR_Survey.WebForm1" %>

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
                <h1>Welcome!</h1>
            </div>
            <div class="main-content">
                <p>
                    &ensp;&emsp;&emsp;AIT Research (AITR) is a market research company that allows people from the general
    public to register their personal details, buying habits etc. with AITR and then sends these
    respondents to market research jobs, based on the needs of AITR’s clients. 
                </p>
                <br />
                <br />
                <p>
                    &ensp;&emsp;&emsp;AIT Research (AITR) is a market research company that allows people from the general
    public to register their personal details, buying habits etc. with AITR and then sends these
    respondents to market research jobs, based on the needs of AITR’s clients. 
                </p>
            </div>
           <a href="register.aspx">
                <div class="survey-link">
                    Take The Survey >
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
