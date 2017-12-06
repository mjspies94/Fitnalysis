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

public partial class Register : System.Web.UI.Page
{
    //Get Connection String from Web Config
    private string connectionString = WebConfigurationManager.ConnectionStrings["FitnalysisDatabase"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void loginButton_Click(object sender, EventArgs e)
    {

        if (checkTextBoxes() && checkPasswords(passwordTextBox.Text, retypePassTextBox.Text) && validEmail(emailTextBox.Text))
        {
            sendEmailVerication();
            createProfile();
        }

    }

    protected Boolean checkTextBoxes()
    {
        bool validInfo = true;

        if (firstNameTextBox.Text.Equals("") || firstNameTextBox.Text.Equals(" "))
        {
            validInfo = false;
            fnameLabel.Text = "please enter first name";
        }

        if (lastNameTextBox.Text.Equals("") || lastNameTextBox.Text.Equals(" "))
        {
            validInfo = false;
            lnameLabel.Text = "please enter last name";
        }

        if (usernameTextBox.Text.Equals("") || usernameTextBox.Text.Equals(" "))
        {
            validInfo = false;
            usernameLabel.Text = "please enter username";
        }

        if (emailTextBox.Text.Equals("") || emailTextBox.Text.Equals(" "))
        {
            validInfo = false;
            emailLabel.Text = "please a valid email";
        }

        if (passwordTextBox.Text.Equals("") || passwordTextBox.Text.Equals(" "))
        {
            validInfo = false;
            passwordLabel.Text = "please enter password";
        }

        return validInfo;
    }

    protected void createProfile()
    {
        //Write SQL Insert Commands for the [User] and [UserImages] table 
        StringBuilder insertUserSQL = new StringBuilder();
        StringBuilder insertUserImageSQL = new StringBuilder();
        //User table
        insertUserSQL
             .Append("INSERT INTO [User](fName,lName,Username,Email,Password)")
             .Append(" Values (@fName, @lName, @Username, @Email, @Password)");
        //User UserImages table
        insertUserImageSQL
            .Append("INSERT INTO [UserImages](ImageName,ContentType,Data,ProfilePic,Username)")
            .Append(" Values (@ImageName,@ContentType,@Data,@ProfilePic,@Username)");        


        //Make connection to Database
        SqlConnection myConnection = new SqlConnection(connectionString);

        //Create INSERT Commands using 'insertUserSQL' string with the connection
        SqlCommand userCommand = new SqlCommand(insertUserSQL.ToString(), myConnection);
        userCommand.CommandType = CommandType.Text;

        userCommand.Parameters.AddWithValue("@fName", firstNameTextBox.Text.ToString());
        userCommand.Parameters.AddWithValue("@lName", lastNameTextBox.Text);
        userCommand.Parameters.AddWithValue("@Username", usernameTextBox.Text);
        userCommand.Parameters.AddWithValue("@Password", passwordTextBox.Text);
        userCommand.Parameters.AddWithValue("@Email", emailTextBox.Text);

        //Insert data into Users table
        try
        {
            //Open Connection
            myConnection.Open();
            //Execute SQL Command
            userCommand.ExecuteNonQuery();

            if (pictureFileUpload.HasFile) 
            {

                // Read the file and convert it to Byte Array
                string filePath = pictureFileUpload.PostedFile.FileName;
                string filename = Path.GetFileName(filePath);
                string extension = Path.GetExtension(filename);
                string contenttype = String.Empty;

                //Set the contenttype based on File Extension
                switch (extension)
                {
                    case ".doc":
                        contenttype = "application/vnd.ms-word";
                        break;
                    case ".docx":
                        contenttype = "application/vnd.ms-word";
                        break;
                    case ".xls":
                        contenttype = "application/vnd.ms-excel";
                        break;
                    case ".xlsx":
                        contenttype = "application/vnd.ms-excel";
                        break;
                    case ".JPG":
                        contenttype = "image/jpg";
                        break;
                    case ".png || .PNG":
                        contenttype = "image/png";
                        break;
                    case ".gif || .GIF":
                        contenttype = "image/gif";
                        break;
                    case ".pdf":
                        contenttype = "application/pdf";
                        break;
                }
                if (contenttype != String.Empty)
                {

                    Stream fs = pictureFileUpload.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    //Create INSERT Commands using 'insertUserSQL' string with the connection
                    SqlCommand userImageCommand = new SqlCommand(insertUserImageSQL.ToString(), myConnection);
                    userImageCommand.CommandType = CommandType.Text;

                    userImageCommand.Parameters.Add("@ImageName", SqlDbType.VarChar).Value = filename;
                    userImageCommand.Parameters.Add("@ContentType", SqlDbType.VarChar).Value = contenttype;
                    userImageCommand.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes;
                    userImageCommand.Parameters.AddWithValue("@ProfilePic", 1);
                    userImageCommand.Parameters.AddWithValue("@Username", usernameTextBox.Text);

                    //Run command to insert image data into table
                    userImageCommand.ExecuteNonQuery();
                    //InsertUpdateData(cmd);
                    imgUploadLabel.ForeColor = System.Drawing.Color.Green;
                    imgUploadLabel.Text = "File Uploaded Successfully";
                }
                else
                {
                    imgUploadLabel.ForeColor = System.Drawing.Color.Red;
                    imgUploadLabel.Text = "File format not recognised." +
                      " Upload Image/Word/PDF/Excel formats";
                }

            }
            errLabel.Visible = true;
            errLabel.Text = "User Created";
        }
        //If error inserting then print out exception clause 
        catch (System.IO.IOException ex)
        {
            errLabel.Visible = true;
            errLabel.Text = ex.Message;
        }
        finally
        {
            //Close Connection
            myConnection.Close();
        }



    }

    protected bool validEmail(String email)
    {
        try
        {
            MailAddress m = new MailAddress(email);

            return true;
        }
        catch (FormatException)
        {
            emailLabel.Text = "invalid email";
            return false;
        }
    }

    protected bool checkPasswords(String passOne, String passTwo)
    {
        if (passOne.Equals(passTwo)){
            return true;
        }
        else
        {
            passwordLabel.Text = "Passwords do not match";
            return false;
        }
    }

    protected void sendEmailVerication()
    {
        try
        {
            SmtpClient Smtp_Server = new SmtpClient("smtp.gmail.com", 587);
            MailMessage emailVerification = new MailMessage();
            Smtp_Server.UseDefaultCredentials = false;
            Smtp_Server.Credentials = new NetworkCredential("mjspies94@gmail.com", "eazyspeazy3013");
            Smtp_Server.EnableSsl = true;
        

            emailVerification = new MailMessage();
            emailVerification.From = new MailAddress(emailTextBox.Text);
            emailVerification.To.Add("emailTextBox.text");
            emailVerification.Subject = "Welcome to Fitnalysis!";
            emailVerification.IsBodyHtml = false;
            emailVerification.Body = "Dear " + firstNameTextBox.Text + ", \n" + "You are now registered to Fitnalysis!";

            Smtp_Server.Send(emailVerification);
        }
        catch(Exception ex)
        {
            emailSentLabel.Text = ex.ToString();
        }


    }

}
   