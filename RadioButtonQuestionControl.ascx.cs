using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITR_Survey
{
    public partial class RadioButtonQuestionControl : System.Web.UI.UserControl
    {
        public Label QuestionLabel
        {
            get
            {
                return questionLabel;
            }
            set
            {
                questionLabel = value;
            }
        }
        public RadioButtonList QuestionRadioButtonList
        {
            get
            {
                return questionRadioButtonList;
            }
            set
            {
                questionRadioButtonList = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}