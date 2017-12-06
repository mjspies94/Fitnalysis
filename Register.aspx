<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Fitnalysis || Workout Tracker and Analyzer</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <div>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-md navbar-dark fixed-top bg-dark">
      <a class="navbar-brand" href="#">Fitnalysis</a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarCollapse" aria-controls="navbarCollapse" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarCollapse">
        <ul class="navbar-nav mr-auto">
          <li class="nav-item active">
            <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="#">Link</a>
          </li>
          <li class="nav-item">
            <a class="nav-link disabled" href="#">Disabled</a>
          </li>
        </ul>
      </div>
    </nav>
   </div>
    <br />
    <br />

    <div>
        <main role="main" class="container">
        <div class="jumbotron">
        
           
                <h1> F I T N A L Y S I S </h1>
           
                <br />
            <asp:Label ID="usrLabel" runat="server" Text="First Name:"></asp:Label>

            &nbsp;&nbsp;&nbsp;
                <br />
&nbsp; &nbsp;
            <asp:TextBox ID="firstNameTextBox" runat="server" Width="167px"></asp:TextBox>

            &nbsp;
                <asp:Label ID="fnameLabel" runat="server"></asp:Label>

            <br />

            <br />
            <asp:Label ID="passLabel" runat="server" Text="Last Name:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="lastNameTextBox" runat="server" Width="167px"></asp:TextBox>
                &nbsp;
                <asp:Label ID="lnameLabel" runat="server"></asp:Label>
                <br />
                <br />
            <asp:Label ID="usrLabel0" runat="server" Text="Email:"></asp:Label>

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="emailTextBox" runat="server" Width="167px"></asp:TextBox>
                &nbsp;
                <asp:Label ID="emailLabel" runat="server"></asp:Label>
                <br />
                <br />
            <asp:Label ID="usrLabel1" runat="server" Text="Username:"></asp:Label>

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="usernameTextBox" runat="server" Width="167px"></asp:TextBox>
                &nbsp;
                <asp:Label ID="usernameLabel" runat="server"></asp:Label>
                <br />
                <br />
            <asp:Label ID="usrLabel2" runat="server" Text="Password:"></asp:Label>

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="passwordTextBox" runat="server" Width="167px"></asp:TextBox>
                &nbsp;
                <asp:Label ID="passwordLabel" runat="server"></asp:Label>
                <br />
                <br />
            <asp:Label ID="usrLabel3" runat="server" Text="Retype Password:"></asp:Label>

            &nbsp;<br />
                &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="retypePassTextBox" runat="server" Width="167px"></asp:TextBox>
            &nbsp;
                <br />
                <br />
            <asp:Label ID="usrLabel4" runat="server" Text="Profile Picture:"></asp:Label>

                <br />
&nbsp;&nbsp;&nbsp;
                <asp:FileUpload ID="pictureFileUpload" runat="server" />
            &nbsp;&nbsp;
                <asp:Label ID="imgUploadLabel" runat="server"></asp:Label>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="loginButton" runat="server" Text="Create Profile" Width="175px" BackColor="#343A40" BorderStyle="None" ForeColor="White" OnClick="loginButton_Click"></asp:Button>
            &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="errLabel" runat="server"></asp:Label>
            &nbsp;
                <asp:Label ID="emailSentLabel" runat="server"></asp:Label>
                <br />
                <br />
            <br />
            <br />
   
        
      </div>
    </div>
    
    </main>
 </form>
</body>
</html>
