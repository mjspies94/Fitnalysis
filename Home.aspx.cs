using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    private string connectionString = WebConfigurationManager.ConnectionStrings["FitnalysisDatabase"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USERNAME"] != null) {
            
            if (!IsPostBack)
            {
                loadUserProfile();
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void loadUserProfile()
    {

        //selects the amount of usernames that the user entered in text box
        string selectSQL;
        //selectSQL = "SELECT ImageName, ContentType, Data FROM [UserImages] where Username ='" + Session["USERNAME"] + "'";
        byte[] bytes = (byte[])getImageData("SELECT ImageName, ContentType, Data FROM [UserImages] where Username ='" + Session["USERNAME"] + "'").Rows[0]["Data"];
        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
        Image1.ImageUrl = "data:image/png;base64," + base64String;
      

    }

    private DataTable getImageData(string query)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        DataTable dt = new DataTable();
        using (myConnection)
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = myConnection;
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                }
            }
            return dt;
        }
    }


    protected void newExerciseButton_Click(object sender, EventArgs e)
    {

    }
}
