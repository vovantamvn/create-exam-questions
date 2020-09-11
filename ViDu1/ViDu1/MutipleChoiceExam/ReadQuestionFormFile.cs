using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ViDu1.MutipleChoiceExam
{
    class ReadQuestionFormFile
    {
        private readonly String fileName;

        public ReadQuestionFormFile(String fileName)
        {
            if (String.IsNullOrEmpty(fileName))
                throw new ArgumentNullException();

            this.fileName = fileName;
        }

        public List<Question> excute()
        {
            List<Question> questions = new List<Question>();
            Microsoft.Office.Interop.Word.Application AC = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();

            doc = AC.Documents.Open(fileName, null, null, null);

            string[] lines = doc.Content.Text.Split('\r');
            int max = lines.Length;
            int i = 0;
            Regex pattern = new Regex("^<Câu [0-9]+>"); 

            while(i<max)
            {
                if (pattern.IsMatch(lines[i]))
                {
                    string content = lines[i];
                    string a = lines[i + 1].Replace("A. ", "");
                    string b = lines[i + 2].Replace("B. ", "");
                    string c = lines[i + 3].Replace("C. ", "");
                    string d = lines[i + 4].Replace("D. ", "");

                    Question question = new Question(content, a, b, c, d, Question.AnswerEnum.None);
                    questions.Add(question);
                    i = i + 5;
                }
                else
                {
                    i++;
                }
            }

            return questions;
        }
    }
}
