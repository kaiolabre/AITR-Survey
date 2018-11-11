using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Windows.Forms;
//Add these
using System.Data;
using System.Data.SqlClient; //sql stuff
using System.Configuration; //access to web config

namespace AITR_Survey
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           



        }


        protected string GetIPAddress()
        {
            //get IP through PROXY
            //====================
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            //should break ipAddress down, but here is what it looks like:
            // return ipAddress;
            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] address = ipAddress.Split(',');
                if (address.Length != 0)
                {
                    return address[0];
                }
            }
            //if not proxy, get nice ip, give that back :(
            //ACROSS WEB HTTP REQUEST
            //=======================
            ipAddress = context.Request.UserHostAddress;//ServerVariables["REMOTE_ADDR"];

            if (ipAddress.Trim() == "::1")//ITS LOCAL(either lan or on same machine), CHECK LAN IP INSTEAD
            {
                //This is for Local(LAN) Connected ID Address
                string stringHostName = System.Net.Dns.GetHostName();
                //Get Ip Host Entry
                System.Net.IPHostEntry ipHostEntries = System.Net.Dns.GetHostEntry(stringHostName);
                //Get Ip Address From The Ip Host Entry Address List
                System.Net.IPAddress[] arrIpAddress = ipHostEntries.AddressList;

                try
                {
                    ipAddress = arrIpAddress[1].ToString();
                }
                catch
                {
                    try
                    {
                        ipAddress = arrIpAddress[0].ToString();
                    }
                    catch
                    {
                        try
                        {
                            arrIpAddress = System.Net.Dns.GetHostAddresses(stringHostName);
                            ipAddress = arrIpAddress[0].ToString();
                        }
                        catch
                        {
                            ipAddress = "127.0.0.1";
                        }
                    }
                }
            }
            return ipAddress;
        }
        public string GetDate ()
        {
            // Get the current date.
            DateTime thisDay = DateTime.Today;

            string date = thisDay.ToString("d");

            return date;
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

        protected void anonymousButton_Click(object sender, EventArgs e)
        {
            //make sure connection is open
            SqlConnection connection = ConnectToSqlDB();

            string ipAdd = GetIPAddress();
            HttpContext.Current.Session["IPAddress"] = ipAdd;
            string date = GetDate();
            HttpContext.Current.Session["todaydate"] = date;

            SqlCommand insertRespondentCommand = new SqlCommand("INSERT INTO [DB_9AB8B7_B18DDA5704].[dbo].[Respondent] (Date, IPAddress) VALUES ('" + date + "','" + ipAdd+ "');", connection);
            insertRespondentCommand.ExecuteNonQuery();


            SqlCommand getRID = new SqlCommand("SELECT * FROM [DB_9AB8B7_B18DDA5704].[dbo].[Respondent] WHERE [IPAddress] = '"+ipAdd+"'", connection);
            SqlDataReader RIDReader = getRID.ExecuteReader();
            

            while (RIDReader.Read())
            {

               int RID = (int)RIDReader["RID"];

               HttpContext.Current.Session["RID"] = RID;
            }
            

            connection.Close();



            Response.Redirect("questionPage.aspx");
        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            //make sure connection is open
            SqlConnection connection = ConnectToSqlDB();

            string ipAdd = GetIPAddress();
            HttpContext.Current.Session["IPAddress"] = ipAdd;
            string date = GetDate();
            HttpContext.Current.Session["todaydate"] = date;

            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            string phoneNumber = mobilephoneTextBox.Text;
            string dob = dateofbirthTextBox.Text;

            try
            {


                SqlCommand insertRptCommand = new SqlCommand("INSERT INTO [DB_9AB8B7_B18DDA5704].[dbo].[Respondent] (FirstName, LastName, DoB, PhoneNumber, Date, IPAddress) VALUES ('" + firstName + "','" + lastName + "','" + dob + "','" + phoneNumber + "','" + date + "','" + ipAdd + "');", connection);
                insertRptCommand.ExecuteNonQuery();

                SqlCommand getRID = new SqlCommand("SELECT * FROM [DB_9AB8B7_B18DDA5704].[dbo].[Respondent] WHERE [IPAddress] = '" + ipAdd + "'", connection);
                SqlDataReader RIDReader = getRID.ExecuteReader();


                while (RIDReader.Read())
                {

                    int RID = (int)RIDReader["RID"];

                    HttpContext.Current.Session["RID"] = RID;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            connection.Close();

            Response.Redirect("questionPage.aspx");
        }
    }
}