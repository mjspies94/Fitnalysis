<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Fitnalysis || Workout Tracker and Analyzer</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/Custom.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
            <a class="nav-link" href="#">Workouts</a>
          </li>
           <li class="nav-item">
            <a class="nav-link" href="#">Exercises</a>
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
        
            <center>
                <h1> F I T N A L Y S I S </h1>
            
            
                <asp:Label ID="nameLabel" runat="server"></asp:Label>
                 <br />
                <br />
            &nbsp;&nbsp;&nbsp;<asp:Button ID="newWorkoutButton" runat="server" Text="New Workout" Width="175px" BackColor="#343A40" BorderStyle="None" ForeColor="White" PostBackUrl="~/NewWorkout.aspx" />
                 &nbsp;
            <asp:Button ID="newExerciseButton" runat="server" Text="New Exercise" Width="175px" BackColor="#343A40" BorderStyle="None" ForeColor="White" OnClick="newExerciseButton_Click" PostBackUrl="~/Register.aspx" />
                 </center>
                <br />
            
               
                <asp:Image ID="Image1" runat="server" Height="200px" Width="25%" />
                <asp:Label ID="bodyStatsLabel" runat="server"></asp:Label>
                <br />
                <br />
            <asp:Label ID="Label1" runat="server" Text="Chest:" Font-Size="X-Large"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Shoulder"  Font-Size="X-Large"></asp:Label>
            :<br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Arms"  Font-Size="X-Large"></asp:Label>
            :<br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Back"  Font-Size="X-Large"></asp:Label>
            :<br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Legs:"  Font-Size="X-Large"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Cardio:"  Font-Size="X-Large"></asp:Label>
                <br />
          
      </div>
            </main>
    </div>
    
    
 </form>


</body>
</html>
