using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViDu1
{
    public partial class QuestionForm : Form
    {
        private List<Question> questions = new List<Question>();
        public QuestionForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isQuestionValid())
            {
                Question question = getQuestionInForm();
                questions.Add(question);

                cleanForm();
                lbDetail.Text = string.Format("Số câu hỏi: " + questions.Count);
            }
            else
            {
                MessageBox.Show("Phải điền hết các thuộc tính!");
            }
        }

        private Question getQuestionInForm()
        {
            string A = txtA.Text;
            string B = txtB.Text;
            string C = txtC.Text;
            string D = txtD.Text;
            string content = txtContent.Text;
            Question.AnswerEnum answer = (Question.AnswerEnum)cbAnswer.SelectedIndex;

            return new Question(content, A, B, C, D, answer);
        }

        private bool isQuestionValid()
        {
            if (String.IsNullOrWhiteSpace(txtContent.Text))
            {
                return false;
            }

            if(String.IsNullOrWhiteSpace(txtA.Text))
            {
                return false;
            }

            if(String.IsNullOrWhiteSpace(txtB.Text))
            {
                return false;
            }

            if(String.IsNullOrWhiteSpace(txtC.Text))
            {
                return false;
            }

            if(String.IsNullOrWhiteSpace(txtD.Text))
            {
                return false;
            }


            if(cbAnswer.SelectedItem == null)
            {
                return false;
            }
            
            return true;
        }

        private void cleanForm()
        {
            txtA.Text = "";
            txtB.Text = "";
            txtC.Text = "";
            txtD.Text = "";
            txtContent.Text = "";
            cbAnswer.SelectedIndex = 0;
        }
    }
}
