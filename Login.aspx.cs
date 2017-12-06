using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    //Connection String in Web Config 
    private string connectionString = WebConfigurationManager.ConnectionStrings["FitnalysisDatabase"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void loginButton_Click(object sender, EventArgs e)
    {
        if (usernameTextBox.Text.Equals("") || passwordTextBox.Text.Equals(""))
        {
            errorLabel.Text = "Please enter Email and Password to login!";
        }

        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        //selects the amount of usernames that the user entered in text box
        string selectSQL;
        selectSQL = "SELECT count(*) FROM [User] where Username ='" + usernameTextBox.Text.ToString() + "'";
        SqlCommand myCommand = new SqlCommand(selectSQL, myConnection);
        //converts piece of data to integer
        int temp = Convert.ToInt32(myCommand.ExecuteScalar().ToString());

        //if number returned is 1, that means the user exists
        if (temp == 1) 
        {
            //it now reopens the connection and checks if the password entered is correct
         
            string checkPassword = "SElECT Password FROM [User] WHERE Username ='" + usernameTextBox.Text + "'";
            SqlCommand passCommand = new SqlCommand(checkPassword, myConnection);
            string password = passCommand.ExecuteScalar().ToString().Replace(" ", "");
            if(password.Equals(passwordTextBox.Text))
            {
                Session["USERNAME"] = usernameTextBox.Text;
                Response.Redirect("Home.aspx");

            }

            else
            {
                errorLabel.Text = "username or password is not correct";
            }
             
            
       
        }


            
    }
       
                
}