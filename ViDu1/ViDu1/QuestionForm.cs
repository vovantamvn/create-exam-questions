using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ViDu1.DataAccess;
using ViDu1.MutipleChoiceExam;

namespace ViDu1
{
    public partial class QuestionForm : Form
    {
        private List<Question> questions = new List<Question>();
        public QuestionForm()
        {
            InitializeComponent();
        }

        private void loadSubject()
        {
            MonHocDao subjectDao = new MonHocDao();
            DataTable table = subjectDao.LayDSMonHoc();

            List<string> subjectNames = new List<string>();
            List<string> subjectCodes = new List<string>();

            cbSubject.Items.Clear();

            foreach(DataRow row in table.Rows)
            {
                string name = row["TenMonHoc"].ToString();
                string code = row["MaMonHoc"].ToString();

                cbSubject.Items.Add(name);

                subjectNames.Add(name);
                subjectCodes.Add(code);
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            int numberOfExam = (int) txtNumberOfExam.Value;
            int numberOfQuestion = (int)txtNumberOfQuestion.Value;

            try
            {
                CreateExamFormQuestions createExam = new CreateExamFormQuestions(questions, numberOfExam, numberOfQuestion);
                CreateDocumentFormExam createDocument = new CreateDocumentFormExam(createExam);

                createDocument.excute();

            } catch(Exception ex)
            {
                MessageBox.Show("Không hợp lệ!");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".docx";
            openFileDialog.Filter = "Word documents (.docx)|*.docx";

            DialogResult result = openFileDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                String fileName = openFileDialog.FileName;
                Console.WriteLine("File: " + fileName);

                ReadQuestionFormFile readQuestionFormFile = new ReadQuestionFormFile(fileName);
                questions = readQuestionFormFile.excute();

                lbDetail.Text = "Số câu hỏi: " + questions.Count;
            }
        }

        private void QuestionForm_Load(object sender, EventArgs e)
        {
            loadSubject();
        }
    } 
}
