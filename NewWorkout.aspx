<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewWorkout.aspx.cs" Inherits="NewWorkout" %>

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
        
           
                <h1> &nbsp;<asp:Label ID="workoutNameLabel" runat="server">New Workout</asp:Label>

                    -
            <asp:Label ID="dateLabel" runat="server"></asp:Label>

                </h1>
                <asp:Button ID="Button1" runat="server" PostBackUrl="~/Home.aspx" Text="Button" />
                <br />
            <asp:Label ID="usrLabel" runat="server" Text="Workout Name: "></asp:Label>

            &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="firstNameTextBox" runat="server" Width="167px">New Workout</asp:TextBox>

            &nbsp;&nbsp;&nbsp;&nbsp;
                
                <br />
&nbsp; &nbsp;
            
            &nbsp;&nbsp;
                <br />
                Exercise:&nbsp;&nbsp;
                <asp:DropDownList ID="exercisesDropDownList" runat="server">
                </asp:DropDownList>
&nbsp;&nbsp;
            <asp:Button ID="newWorkoutButton" runat="server" Text="Add New" Width="114px" BackColor="#343A40" BorderStyle="None" ForeColor="White" OnClick="newWorkoutButton_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;<br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <br />
            <asp:Label ID="typeLabel" runat="server" Text="Type:"></asp:Label>

            &nbsp;&nbsp;&nbsp;
                <asp:Button ID="weightsButton" runat="server" Text="Weights" Width="114px" BackColor="#343A40" BorderStyle="None" ForeColor="White" Font-Size="Small" OnClick="weightsButton_Click" />
&nbsp;&nbsp;
                <asp:Button ID="cardioButton" runat="server" Text="Cardio" Width="114px" BackColor="#343A40" BorderStyle="None" ForeColor="White" Font-Size="Small" OnClick="cardioButton_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="exerciseLabel" runat="server" Text="Exercise Name:" Visible="False"></asp:Label>

            &nbsp;
            <asp:TextBox ID="nameTextBox" runat="server" Width="167px" Visible="False"></asp:TextBox>

            &nbsp;&nbsp;
            <asp:Label ID="muscleGroupLabel" runat="server" Text="Muscle Group:" Visible="False"></asp:Label>

            &nbsp;&nbsp;
                <asp:DropDownList ID="muscleGroupDropDownList" runat="server" Visible="False">
                    <asp:ListItem>Chest</asp:ListItem>
                    <asp:ListItem>Shoulders</asp:ListItem>
                    <asp:ListItem>Arms</asp:ListItem>
                    <asp:ListItem>Legs</asp:ListItem>
                    <asp:ListItem>Abs</asp:ListItem>
                    <asp:ListItem>Cardio</asp:ListItem>
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="addNewButton" runat="server" Text="Add" Width="50px" BackColor="#343A40" BorderStyle="None" ForeColor="White" OnClick="addNewButton_Click" Visible="False" />

                <br />
                <br />

                <asp:Label ID="weightLabel" runat="server" Text="Weight:" Visible="False"></asp:Label>

            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="weightTextBox" runat="server" Width="80px" Visible="False"></asp:TextBox>

            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="repsLabel" runat="server" Text="Reps:" Visible="False"></asp:Label>

            &nbsp;<asp:TextBox ID="repsTextBox" runat="server" Width="80px" Visible="False"></asp:TextBox>

                &nbsp;&nbsp;&nbsp;
            <asp:Button ID="addLiftButton" runat="server" Text="Add" Width="50px" BackColor="#343A40" BorderStyle="None" ForeColor="White" OnClick="addLiftButton_Click" Visible="False" />

                <br />
            <asp:Label ID="distanceLabel" runat="server" Text="Distance" Visible="False"></asp:Label>

            &nbsp;&nbsp;
            <asp:TextBox ID="distanceTextBox" runat="server" Width="80px" Visible="False"></asp:TextBox>

            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="timeLabel" runat="server" Text="Time:" Visible="False"></asp:Label>

            &nbsp;
            <asp:TextBox ID="hrTextBox" runat="server" Width="26px" Visible="False">Hr</asp:TextBox>

                :
            <asp:TextBox ID="minTextBox" runat="server" Width="31px" Visible="False">Min</asp:TextBox>

                .<asp:TextBox ID="secTextBox" runat="server" Width="48px" Visible="False">Sec</asp:TextBox>

            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="weightLabel7" runat="server" Text="Calories Burned:" Visible="False"></asp:Label>

            &nbsp;
            <asp:TextBox ID="calTextBox" runat="server" Width="80px" Visible="False"></asp:TextBox>

                &nbsp;&nbsp;&nbsp;
            <asp:Button ID="addCardioButton" runat="server" Text="Add" Width="50px" BackColor="#343A40" BorderStyle="None" ForeColor="White" OnClick="addCardioButton_Click" Visible="False" />

        
            
                <br />
                <br />
            <asp:Button ID="addExerciseButton" runat="server" Text="Add Exercise" Width="150px" BackColor="#343A40" BorderStyle="None" ForeColor="White" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="saveButton" runat="server" Text="Save Workout" Width="150px" BackColor="#343A40" BorderStyle="None" ForeColor="White" OnClick="saveButton_Click" />

            <br />

            <br />
                &nbsp;<asp:Table ID="Table1" runat="server">
                </asp:Table>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                &nbsp;
                <br />
                &nbsp;&nbsp;&nbsp;<br />
            <br />
   
        
      </div>
    </div>
    
    </main>
 </form>
</body>
</html>
