using Microsoft.Office.Interop.Word;
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
        
        public static List<Question> readAllQuestion(string filePath)
        {
            List<Question> questions = new List<Question>();

            Application wordApp = new Application();
            Document doc = wordApp.Documents.Open(filePath);

            string[] lines = doc.Content.Text.Split('\r');
            int max = lines.Length;
            int i = 0;
            Regex pattern = new Regex("^<Câu [0-9]+>"); 

            while(i<max)
            {
                if (pattern.IsMatch(lines[i]))
                {
                    string content = Regex.Replace(lines[i], "^<Câu [0-9]+>", "");
                    string a = lines[i + 1].Replace("A. ", "");
                    string b = lines[i + 2].Replace("B. ", "");
                    string c = lines[i + 3].Replace("C. ", "");
                    string d = lines[i + 4].Replace("D. ", "");

                    Question question = new Question(content, a, b, c, d, Question.AnswerEnum.A);
                    questions.Add(question);
                    i = i + 5;
                }
                else
                {
                    i++;
                }
            }

            doc.Close();
            wordApp.Quit();

            return questions;
        }
    }
}
