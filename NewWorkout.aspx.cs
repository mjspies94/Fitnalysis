using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.IO;
using System.Net.Mail;
using System.Activities.Expressions;
using System.Net;
using System.Collections;

public partial class NewWorkout : System.Web.UI.Page
{
    //Get Connection String from Web Config
    private string connectionString = WebConfigurationManager.ConnectionStrings["FitnalysisDatabase"].ConnectionString;

    //Hash table will be used for whether an exercise is cardio or a lift exercise
    private Hashtable isCardioHashTable;

    private string username;
    private string date;
    


    protected void Page_Load(object sender, EventArgs e)
    {
        //If no user is logged on, redirect to login.aspx
        if (Session["USERNAME"] != null)
        {

            if (!IsPostBack)
            {
                //Format the date to save into database
                date = "27/12/2011";
                System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
                dateInfo.ShortDatePattern = "dd/MM/yyyy";
                DateTime validDate = Convert.ToDateTime(date, dateInfo);

                username = Session["USERNAME"].ToString();
                dateLabel.Text = DateTime.Today.ToString();
                populateDropDownList();

            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
       
          
        
    }

    //POPULATE DROP DOWN LIST WITH EXERCISES
    protected void populateDropDownList()
    {
        isCardioHashTable = new Hashtable();
        string selectSQL = "SELECT ExerciseName FROM [ExerciseNames] WHERE Username ='"+username+"'";
        SqlConnection myConnection= new SqlConnection(connectionString); 
        SqlCommand myCommand = new SqlCommand(selectSQL, myConnection);

        try
        {
            myConnection.Open();
            SqlDataReader myReader = myCommand.ExecuteReader();

            string exerciseName;
            while (myReader.Read())
            {
                exerciseName = myReader["ExerciseName"].ToString();
                exercisesDropDownList.Items.Add(exerciseName);
                isCardioHashTable.Add(exerciseName, myReader[])
            }
                
            }
        catch(Exception ex)
        {
            workoutNameLabel.Text = ex.ToString();
        }
        finally
        {
            myCommand.Dispose();
            myConnection.Close();
                
        }
    }

  
    protected void weightsButton_Click(object sender, EventArgs e)
    {
        addLiftButton.Visible = true;
        addCardioButton.Visible = false;

        weightLabel.Visible = true;
        weightTextBox.Visible = true;
        repsLabel.Visible = true;
        repsTextBox.Visible = true;

        distanceLabel.Visible = false;
        distanceTextBox.Visible = false;
        timeLabel.Visible = false;
        hrTextBox.Visible = false;
        minTextBox.Visible = false;
        secTextBox.Visible = false;
    }

    protected void cardioButton_Click(object sender, EventArgs e)
    {
        addCardioButton.Visible = true;
        addLiftButton.Visible = false;

        distanceLabel.Visible = true;
        distanceTextBox.Visible = true;
        timeLabel.Visible = true;
        hrTextBox.Visible = true;
        minTextBox.Visible = true;
        secTextBox.Visible = true;

        weightLabel.Visible = false;
        weightTextBox.Visible = false;
        repsLabel.Visible = false;
        repsTextBox.Visible = false;

    }


    //ADD A NEW EXERCISE TO 'EXERCISENAMES' TABLE
    protected void addNewButton_Click(object sender, EventArgs e)
    {


        //Make connection to Database
        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlCommand userCommand;
        StringBuilder insertSQL = new StringBuilder();

        
         //Insert Command
         insertSQL
             .Append("INSERT INTO ExerciseNames(Username,ExerciseName,MuscleGroup,isCardio)")
             .Append(" Values (@Username,@ExerciseName,@MuscleGroup,@isCardio)");

        //Create INSERT Commands using 'insertUserSQL' string with the connection
        userCommand = new SqlCommand(insertSQL.ToString(), myConnection);
        userCommand.CommandType = CommandType.Text;

        userCommand.Parameters.AddWithValue("@ExerciseName", nameTextBox.Text.ToString());
        userCommand.Parameters.AddWithValue("@Username", Session["Username"].ToString());
        userCommand.Parameters.AddWithValue("@MuscleGroup", muscleGroupDropDownList.SelectedValue.ToString());

        if (muscleGroupDropDownList.SelectedValue.ToString().Equals("Cardio"))
        {
            userCommand.Parameters.AddWithValue("@isCardio", "yes");
        }
        else
        {
            userCommand.Parameters.AddWithValue("@isCardio", "no");
        }
            


        //Insert data into Users table
        try
        {
            //Open Connection
            myConnection.Open();
            //Execute SQL Command
            userCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            workoutNameLabel.Text = ex.ToString();
        }
        finally
        {
            userCommand.Dispose();
            myConnection.Close();
        }
        populateDropDownList();
    }



    protected void addCardioButton_Click(object sender, EventArgs e)
    {
        //Make connection to Database
        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlCommand userCommand;
        StringBuilder insertSQL = new StringBuilder();

        //Insert command
        insertSQL
                .Append("INSERT INTO Cardio(Date,Username,Name,Distance,TimeInMinutes,Calories)")
                .Append(" Values (@Date,@Username,@Name,@Weight,@Repititions)");

        //Create INSERT Commands using 'insertUserSQL' string with the connection
        userCommand = new SqlCommand(insertSQL.ToString(), myConnection);
        userCommand.CommandType = CommandType.Text;

        userCommand.Parameters.AddWithValue("@Date", DateTime.Today);
        userCommand.Parameters.AddWithValue("@Username", Session["Username"].ToString());
        userCommand.Parameters.AddWithValue("@Name", exercisesDropDownList.SelectedValue.ToString());
        userCommand.Parameters.AddWithValue("@Weight", weightTextBox.Text);
        userCommand.Parameters.AddWithValue("@Repititions", repsTextBox.Text);
        
        //Insert data into 'Cardio' table
        try
        {
            //Open Connection
            myConnection.Open();
            //Execute SQL Command
            userCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            userCommand.Dispose();
            myConnection.Close();
        }

    }

    protected void addLiftButton_Click(object sender, EventArgs e)
    {

        //Make connection to Database
        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlCommand userCommand;
        StringBuilder insertSQL = new StringBuilder();

        //Insert into 
        insertSQL
             .Append("INSERT INTO LiftExercise(Date,Username,Name,Weight,Repititions)")
             .Append(" Values (@Date,@Username,@Name,@Weight,@Repititions)");

        //Create INSERT Commands using 'insertSQL' string with the connection
        userCommand = new SqlCommand(insertSQL.ToString(), myConnection);
        userCommand.CommandType = CommandType.Text;

        userCommand.Parameters.AddWithValue("@Date", DateTime.Today.Date);
        userCommand.Parameters.AddWithValue("@Username", Session["Username"].ToString());
        userCommand.Parameters.AddWithValue("@Name", exercisesDropDownList.SelectedValue.ToString());
        userCommand.Parameters.AddWithValue("@Weight", weightTextBox.Text);
        userCommand.Parameters.AddWithValue("@Repititions", repsTextBox.Text);


        //Insert data into 'LiftExercise' table
        try
        {
            //Open Connection
            myConnection.Open();
            //Execute SQL Command
            userCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            myConnection.Close();
         }
    }

    protected void newWorkoutButton_Click(object sender, EventArgs e)
    {
        nameTextBox.Visible = true;
        muscleGroupDropDownList.Visible = true;
        addNewButton.Visible = true;
        exerciseLabel.Visible = true;
        muscleGroupLabel.Visible = true;
    }

    //SAVING THE WORKOUT 
    protected void saveButton_Click(object sender, EventArgs e)
    {
        
       
    }

    //SAVING AN EXERCISE ENTRY FOR THE SPECIFIC WORKOUT
    protected void addExerciseButton_Click(object sender, EventArgs e)
    {
        //Make connection to Database
        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlCommand userCommand;
        StringBuilder insertSQL = new StringBuilder();

        //SQL Statement
        insertSQL
             .Append("INSERT INTO LiftExercise(Date,Username,Name,Weight,Repititions)")
             .Append(" Values (@Date,@Username,@Name,@Weight,@Repititions)");

        //Create INSERT Commands using 'insertSQL' string with the connection
        userCommand = new SqlCommand(insertSQL.ToString(), myConnection);
        userCommand.CommandType = CommandType.Text;

        userCommand.Parameters.AddWithValue("@Date", DateTime.Today.Date);
        userCommand.Parameters.AddWithValue("@Username", Session["Username"].ToString());
        userCommand.Parameters.AddWithValue("@Name", exercisesDropDownList.SelectedValue.ToString());
        userCommand.Parameters.AddWithValue("@Weight", weightTextBox.Text);
        userCommand.Parameters.AddWithValue("@Repititions", repsTextBox.Text);


        //Insert data into 'LiftExercise' table
        try
        {
            //Open Connection
            myConnection.Open();
            //Execute SQL Command
            userCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            myConnection.Close();
        }
    }

}
}

   