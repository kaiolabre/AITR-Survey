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
    public partial class staffPage : System.Web.UI.Page
    {
        public Label FeatureLabel
        {
            get { return featureLabel; }
            set { featureLabel = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //check if session is logged in
            if (!SessionHandler.IsLoggedIn())
            {
                Response.Redirect("loginPage.aspx");
            }

            //Make first letter upper case
            string username = SessionHandler.getUserName();
            char firstLetter = char.ToUpper(username[0]);
            string newUsernameText = firstLetter + username.Substring(1);
            
            //display in login link

            //and display it on feature title
            string newFeature = "Hi " + newUsernameText + ",";
            FeatureLabel.Text = newFeature;

           

        }

        protected void SearchAll_Click(object sender, EventArgs e)
        {

        }

        protected void searchButton_Click(object sender, EventArgs e)
        {

        }
    }
}