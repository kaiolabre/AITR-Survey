using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
//Add these
using System.Data.SqlClient; //sql stuff
using System.Configuration; //access to web config

namespace AITR_Survey
{
    public partial class questionPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //get list of answers from session to be able to add more on top
            List<Answer> answers = getListOfAnswersFromSession();

            //get current question ID so we know which question we are
            int currentQuestion = GetCurrentQuestionNumber();

            //Connect to External DataBAse
            SqlConnection connection = ConnectToSqlDB();

            //sql command to get current question
            //Question table has foreign key fpr Type, so join them together so we can get the options displayed
            SqlCommand command = new SqlCommand("SELECT * FROM [DB_9AB8B7_B18DDA5704].[dbo].[Question], [DB_9AB8B7_B18DDA5704].[dbo].[Type] WHERE [DB_9AB8B7_B18DDA5704].[dbo].[Question].[TypeID] = [DB_9AB8B7_B18DDA5704].[dbo].[Type].[TypeID] AND [DB_9AB8B7_B18DDA5704].[dbo].[Question].[QID] = " + currentQuestion, connection);
            //run command, store results in SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            //loop through rows of results
            while (reader.Read())
            {

                //get question text and type from this row of results
                string questionText = reader["Text"].ToString();                //"Text" is a column from the Question table
                int questionType = Int32.Parse(reader["TypeID"].ToString()); //"TypeID" is a column from the Type table

                //using type, load up correct web user control
                //textbox control
                if (questionType.Equals(3))
                {
                    //load the control up
                    TextboxQuestionControl textboxControl = (TextboxQuestionControl)LoadControl("~/TextboxQuestionControl.ascx");
                    //set its ID
                    textboxControl.ID = "textboxQuestionControl";
                    //set its question text label to the question Text
                    textboxControl.QuestionLabel.Text = questionText;

                    //add it to the placeholder on our webpage
                    questionPlaceHolder.Controls.Add(textboxControl);
                }
                //using type, load up correct web user control
                //checkbox control
                else if (questionType.Equals(2))
                {
                    CheckBoxQuestionControl checkBoxQuestion = (CheckBoxQuestionControl)LoadControl("~/CheckBoxQuestionControl.ascx");
                    checkBoxQuestion.ID = "checkBoxQuestion";
                    //set text label to question text
                    checkBoxQuestion.QuestionLabel.Text = questionText;

                    //we need to talk to the database to get allllll of the options/choices for this question to display
                    //e.g what gender? then options like male, female and other are the things we want to get from the DB
                    SqlCommand optionCommand = new SqlCommand("SELECT * FROM [DB_9AB8B7_B18DDA5704].[dbo].[Option] WHERE QID = " + currentQuestion, connection);
                    //run command, get ready to read results
                    SqlDataReader optionReader = optionCommand.ExecuteReader();

                    //cycle through rows of options
                    while (optionReader.Read())
                    {
                        //for every row, we'll build a list item representing it
                        //                            display member(for ui),         value member(for devs to store if selected)
                        ListItem item = new ListItem(optionReader["Text"].ToString(), optionReader["OID"].ToString());
                        //add item to our checkbox list
                        checkBoxQuestion.QuestionCheckBoxList.Items.Add(item);
                    }
                    //finally have all the checkbox list items populated, add our checkbox question control to the placeholder
                    questionPlaceHolder.Controls.Add(checkBoxQuestion);
                }
                //using type, load up correct web user control
                //Radio Button control
                else if (questionType.Equals(1))
                {
                    //Load Control
                    RadioButtonQuestionControl radioButtonQuestion = (RadioButtonQuestionControl)LoadControl("~/RadioButtonQuestionControl.ascx");
                    //SetUp Its ID
                    radioButtonQuestion.ID = "radioButtonQuestion";
                    //Set the question Label
                    radioButtonQuestion.QuestionLabel.Text = questionText;
                    //Set up sql command and data reader to get the text and OID assigned to each question
                    SqlCommand optionComman = new SqlCommand("SELECT * FROM [DB_9AB8B7_B18DDA5704].[dbo].[Option] WHERE QID = " + currentQuestion, connection);
                    SqlDataReader optionReader = optionComman.ExecuteReader();
                    while (optionReader.Read())
                    {
                        //populate radio button list
                        ListItem item = new ListItem(optionReader["Text"].ToString(), optionReader["OID"].ToString());
                        radioButtonQuestion.QuestionRadioButtonList.Items.Add(item);
                    }
                    questionPlaceHolder.Controls.Add(radioButtonQuestion);
                }
                else
                {
                    //if it cant find anything 
                    Response.Write("Something went really bad");
                }
            }

            //close connection
            connection.Close();

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

        //Function to get currentQuestion ID number
        private static int GetCurrentQuestionNumber()
        {
            
            string connectionString = ConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;

            //build sqlq connection, use connection string, and open(connect)
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            //OPEN CONNECTION
            connection.Open();
            
            //SQL COMMAND AND READER TO READ QID from the question table
            SqlCommand command = new SqlCommand("SELECT QID FROM [DB_9AB8B7_B18DDA5704].[dbo].[Question]", connection);
            SqlDataReader reader = command.ExecuteReader();

            //variable to store QID
            int currentQuestion;
            //check session state to see what question were up to
            while (reader.Read())
            {
               currentQuestion = Int32.Parse(reader["QID"].ToString());
            }

            if (HttpContext.Current.Session["questionNumber"] != null)
            {
                //we have a question number stored in the session, we should use that value for current question
                currentQuestion = (int)HttpContext.Current.Session["questionNumber"];//session stores Objects, cast to int
            }
            else
            {
                currentQuestion = 1;
                //no value stored in session, set it to our first question number
                HttpContext.Current.Session["questionNumber"] = currentQuestion;//which would be 1 here
            }

            return currentQuestion;
        }

        //get List Of Answers From Session
        private static List<Answer> getListOfAnswersFromSession()
        {
            List<Answer> answers = new List<Answer>();
            if(HttpContext.Current.Session["answers"] != null)
            {
                answers = (List<Answer>)HttpContext.Current.Session["answers"];
            }
            return answers;
        }

        //so when the user presses the NEXT button
        protected void NextQuestionButton_Click(object sender, EventArgs e)
        {
            //We need to know the current question so we handle the next question later
            int currentQuestion = GetCurrentQuestionNumber();

            //make sure connection is open
            SqlConnection connection = ConnectToSqlDB();

            //Use to check for follow up questions by checking selected answers against DB to see if there are follow up questions
            List<Int32> followUpQuestions = new List<int>();

            
            //Find out what the next question should be:
            //get current question from DB, there is a column on this table with a foreign key to the next question
            SqlCommand command = new SqlCommand("SELECT * FROM [DB_9AB8B7_B18DDA5704].[dbo].[Question] WHERE [QID] = " + currentQuestion, connection);
            SqlDataReader reader = command.ExecuteReader();

            //Lets try to find check box question control in web page
            CheckBoxQuestionControl checkBoxQuestion = (CheckBoxQuestionControl)questionPlaceHolder.FindControl("checkBoxQuestion");
            if (checkBoxQuestion != null)
            {
                //Make sure that the list is populated
                if (HttpContext.Current.Session["followUpQuestions"] != null)
                {
                    followUpQuestions = (List<Int32>)HttpContext.Current.Session["followUpQuestions"];
                }

                //then its a check box question, lets process answers

                //empty list of shown answers in bullet list
                selectedAnswerBulletedList.Items.Clear();

                //Skip question handling
                bool isEmpty = true;

                //for each selected item, add to bullet list
                foreach (ListItem item in checkBoxQuestion.QuestionCheckBoxList.Items)
                {

                    if (item.Selected)
                    {
                        //skipped question handling
                        isEmpty = false;

                        //it will be used to check against DADABase using its text value
                        selectedAnswerBulletedList.Items.Add(item);

                        string optionText = item.Text.ToString();
                        //Check what has been checked by user, using text value from selectedAnswerBulletedList
                        SqlCommand nqCommand = new SqlCommand("SELECT NQ FROM [DB_9AB8B7_B18DDA5704].[dbo].[Option] WHERE [Text] = '" + optionText + "'", connection);
                        SqlDataReader nqReader = nqCommand.ExecuteReader();

                        //we will use this index to check if column is null
                        int NQColumnIndex = nqReader.GetOrdinal("NQ");

                        //we will use this variable to go store the next Question and compare it to the database even if we have a follow Up question 
                        int nextQuestion;
                        
                       
                        if (nqReader.HasRows)
                        {
                            while (nqReader.Read())
                            {
                                if (nqReader.IsDBNull(NQColumnIndex))
                                {
                                    //do nothing
                                    nextQuestion = 0;
                                    //int nextQuestionColumnIndex = reader.GetOrdinal("NextQuestion");
                                    //followUpQuestions.Add(nextQuestionColumnIndex);
                                }
                                else
                                {
                                    //if NQ column is not null so we have a follow up question, store it to follow up question list and session so we can access it later
                                    nextQuestion = (int)nqReader["NQ"];

                                    //make sure it will work
                                    if (nextQuestion != 0)
                                    {
                                        if (!followUpQuestions.Contains(nextQuestion))
                                            followUpQuestions.Add(nextQuestion);
                                    }
                                }
                            }
                        }

                        //store the follow up questions list in session
                        HttpContext.Current.Session["followUpQuestions"] = followUpQuestions;


                        //Command to insert the data into the session so we can store data into the data base when Survey has ended
                        SqlCommand idComand = new SqlCommand("SELECT * FROM [DB_9AB8B7_B18DDA5704].[dbo].[Option] WHERE QID = " + currentQuestion, connection);
                        SqlDataReader idReader = idComand.ExecuteReader();
                        if (idReader.Read())
                        {
                            //add answer to session
                            Answer a = new Answer();
                            a.content = optionText;
                            a.optionId = Int32.Parse(idReader["OID"].ToString());
                            a.questionId = currentQuestion;

                            List<Answer> answers = getListOfAnswersFromSession();
                            answers.Add(a);
                            HttpContext.Current.Session["answers"] = answers;
                        }
                    }
                }

                //skip question handler
                if (isEmpty)
                {
                    //nothing selected
                    //empty list of shown answers in bullet list
                    selectedAnswerBulletedList.Items.Clear();
                    //clear buffer
                    followUpQuestions = null;


                    System.Windows.Forms.MessageBox.Show("Sorry! This question cannot be skipped.");

                    //redirect to same question and display error message
                    Response.Redirect("questionPage.aspx");

                    


                }
            }
            //Lets try textbox question
            TextboxQuestionControl textBoxQuestion = (TextboxQuestionControl)questionPlaceHolder.FindControl("textboxQuestionControl");
            if (textBoxQuestion != null)
            {
                string textBoxAnswer = textBoxQuestion.QuestionTextBox.Text;

                //question not answered
                if (textBoxAnswer == "")
                {

                    System.Windows.Forms.MessageBox.Show("Sorry! This question cannot be skipped.");
                    //redirect to same question
                    Response.Redirect("questionPage.aspx");
                }

                //add answer to session
                Answer a = new Answer();
                a.content = textBoxAnswer;
                a.optionId = 0;
                a.questionId = currentQuestion;

                List<Answer> answers = getListOfAnswersFromSession();
                answers.Add(a);
                HttpContext.Current.Session["answers"] = answers;
               

                //make the list empty so there is no followup question
                HttpContext.Current.Session["followUpQuestions"] = null;
            }

            //TODO check for radio and drop down controls
            RadioButtonQuestionControl radioButtonQuestion = (RadioButtonQuestionControl)questionPlaceHolder.FindControl("radioButtonQuestion");
            if (radioButtonQuestion != null)
            {


                //  foreach (ListItem item in radioButtonQuestion.QuestionRadioButtonList.Items)
                //   {
                //   if (item.Selected)
                //      {
                
                try
                {

                    string optionText = radioButtonQuestion.QuestionRadioButtonList.SelectedItem.Text.ToString();
                    

                    string commandstr = "SELECT * FROM [DB_9AB8B7_B18DDA5704].[dbo].[Option] WHERE [Text] = '" + optionText + "'";
                    SqlCommand idCommand = new SqlCommand(commandstr, connection);
                    SqlDataReader idReader = idCommand.ExecuteReader();

                    if (idReader.Read())
                    {
                        //add answer to session
                        Answer a = new Answer();
                        a.content = optionText;
                        a.optionId = Int32.Parse(idReader["OID"].ToString());
                        a.questionId = currentQuestion;


                        List<Answer> answers = getListOfAnswersFromSession();
                        answers.Add(a);
                        HttpContext.Current.Session["answers"] = answers;
                    }
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Sorry! This question cannot be skipped.");
                    Response.Redirect("questionPage.aspx");
                }
                //question not answered
               

                
                   // }
                   
              //  }

                //make the list empty so there is no followup question
                HttpContext.Current.Session["followUpQuestions"] = null;
            }
            
            //if list of follow up questions exists then use it instead of the empty list
            if (HttpContext.Current.Session["followUpQuestions"] != null)
            {
                followUpQuestions = (List<Int32>)HttpContext.Current.Session["followUpQuestions"];
            }
            //loop through results. Should only be 1
            while (reader.Read())
            {
                //first, get index of nextQuestion column
                int nextQuestionColumnIndex = reader.GetOrdinal("NextQuestion");
                //we will use this index to check if column is null
                
                //if next question column in the question table is null and follow uo questions do not exist, its the end of the survey
                if (reader.IsDBNull(nextQuestionColumnIndex) && followUpQuestions.Count == 0)
                {
                    int RID = (int)HttpContext.Current.Session["RID"];
                    //end of Survey
                    List<Answer> answers = getListOfAnswersFromSession();

                    try //to store the list of objects into the DB, inserting each object as each row of the table Answer
                    {
                        foreach (Answer a in answers)
                        {
                            SqlCommand insertCommand = new SqlCommand("INSERT INTO [DB_9AB8B7_B18DDA5704].[dbo].[Answer] (Content, RID, QID, OID) VALUES ('" + a.content + "','"+RID+"','" + a.questionId + "','" + a.optionId + "');", connection);

                            insertCommand.ExecuteNonQuery();
                        }
                        
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }

                   
                    //emtpy my list so the survey can be taken again
                    HttpContext.Current.Session["answer"] = null;
                    HttpContext.Current.Session["RID"] = null;

                    Response.Redirect("endSurveyPage.aspx");


                }
                else //if it is not the end so keep going 
                {
                    //IF THERE IS FOLLOW UP QUESTIONS THOUGH, DO THEM FIRST
                    if (followUpQuestions.Count > 0)
                    {
                        //set current question to first follow up question, then remove from follow up question list 
                        //so it doesn't repeat for next time
                        int followUpQuestion = followUpQuestions[0];
                        HttpContext.Current.Session["questionNumber"] = followUpQuestion;

                        followUpQuestions.RemoveAt(0);

                        //store the follow up questions list in session (just in case it changed)
                        HttpContext.Current.Session["followUpQuestions"] = followUpQuestions;
                    }
                    else
                    {
                        //not end of survey
                        int nextQuestion = (int)reader["NextQuestion"];
                        //set this as the current question in the session
                        HttpContext.Current.Session["questionNumber"] = nextQuestion;
                    }

                    //redirect to same page to load up the next question as current question(aka, run pageLoad again)
                    Response.Redirect("questionPage.aspx");
                }
            }

            //close the connection
            connection.Close();
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            //emtpy my list so the survey can be taken again
            HttpContext.Current.Session["answer"] = null;
            Response.Redirect("index.aspx");
        }
    }
}