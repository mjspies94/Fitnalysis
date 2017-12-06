<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <!--#include file="inc/head.html"-->
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!--#include file="inc/navbar.html"-->
        </div>
        <br />
        <br />
        <main role="main" class="container">
            <div>

                <div class="jumbotron" style="text-align: center">
                    <h1>F I T N A L Y S I S </h1>

                    <br />
                    <asp:Label ID="usrLabel" runat="server" Text="Username:"></asp:Label>

                    &nbsp;
            <asp:TextBox ID="usernameTextBox" runat="server" Width="167px"></asp:TextBox>

                    <br />

                    <br />
                    <asp:Label ID="passLabel" runat="server" Text="Password:"></asp:Label>
                    &nbsp;&nbsp;
            <asp:TextBox ID="passwordTextBox" runat="server" Width="167px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="loginButton" runat="server" Text="Login" Width="175px" BackColor="#343A40" BorderStyle="None" ForeColor="White" OnClick="loginButton_Click"></asp:Button>
                    &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="registerButton" runat="server" Text="Register" Width="175px" BackColor="#343A40" BorderStyle="None" ForeColor="White" PostBackUrl="~/Register.aspx"></asp:Button>
                    <br />
                    <asp:Label ID="errorLabel" runat="server"></asp:Label>
                    <br />

                </div>
            </div>

        </main>
    </form>
</body>
</html>
