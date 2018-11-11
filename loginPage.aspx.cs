using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Add these
using System.Data.SqlClient; //sql stuff
using System.Configuration; //access to web config

namespace AITR_Survey
{
    public partial class loginPage : System.Web.UI.Page
    {
        //lets get the text box question
        public  TextBox UserNameTextBox
        {
            get { return usernameTextBox; }
            set { usernameTextBox = value; }
        }
        public TextBox PasswordTextBox
        {
            get { return passwordTextBox; }
            set { passwordTextBox = value; }
        }
        public Label ErrorMsg
        {
            get { return errorMsg; }
            set { errorMsg = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionHandler.IsLoggedIn())
            {
                Response.Redirect("staffPage.aspx");
            }
        }


        //Function to easialy connecto to external DB
        private static SqlConnection ConnectToSqlDB()
        {
            //get question from DB
            //get Connection string from web config
            string connectionString = ConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;

            //build sqlq connection, use connection string, and open(connect)
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            return connection;
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            SqlConnection connection = ConnectToSqlDB();

            string username = UserNameTextBox.Text;
            string password = PasswordTextBox.Text;

            SqlCommand loginCommand = new SqlCommand("SELECT COUNT(*) FROM [DB_9AB8B7_B18DDA5704].[dbo].[Staff] WHERE [UserName] = '" + username + "' AND [Password] = '" + password + "'", connection);
            int rowsAffected = (int)loginCommand.ExecuteScalar();

            try
            {
                if (rowsAffected > 0)
                {

                    SessionHandler.setUserName(username);
                    Response.Redirect("staffPage.aspx");

                }
                else
                {
                    string str = "Oops! Incorrect Username or Password";
                    ErrorMsg.Text = str;
                }
            }catch (Exception ex)
            {
                Console.Write(ex);
            }

            connection.Close();
        }

    }
}