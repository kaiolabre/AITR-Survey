<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextboxQuestionControl.ascx.cs" Inherits="AITR_Survey.TextboxQuestionControl" %>
<div style="background: linear-gradient(to right, #023C3D, #047879); padding:20px; margin:0px; padding:15px 60px;" >
    
    <asp:Label ID="questionLabel" runat="server" Text="Label" Font-Size="60px" Font-Bold="False" ForeColor="White"></asp:Label>
</div>   
<div style="margin:50px 0px 50px 200px; padding:20px; border-left:2px solid #999999;">
  
<p>
    <asp:TextBox ID="questionTextBox" runat="server" Width="500px" style="color:#404040; font-size:25px;"></asp:TextBox>
</p> 
</div>

