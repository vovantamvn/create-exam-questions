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

            int length = doc.Paragraphs.Count;
            Regex pattern = new Regex("^<Câu [0-9]+>");

            for (int i=1; i<length; i++)
            {
                Paragraph paragraph = doc.Paragraphs[i];
                Range range = paragraph.Range;

                // Check text
                string text = range.Text;

                if(pattern.IsMatch(text))
                {
                    string content = Regex.Replace(text, "^<Câu [0-9]+>", "");
                    string a = doc.Paragraphs[i + 1].Range.Text.Replace("A. ", "");
                    string b = doc.Paragraphs[i + 2].Range.Text.Replace("B. ", "");
                    string c = doc.Paragraphs[i + 3].Range.Text.Replace("C. ", "");
                    string d = doc.Paragraphs[i + 4].Range.Text.Replace("D. ", "");

                    string answer = "";
                    for(int j = 1; j <= 4; j++)
                    {
                        Range startRange = doc.Paragraphs[i + j].Range;
                        Range underLineRange = doc.Range(startRange.Start, startRange.Start + 1);
                        if (underLineRange.Underline == WdUnderline.wdUnderlineSingle)
                        {
                            answer = underLineRange.Text;
                            break;
                        }
                    }

                    if (!String.IsNullOrWhiteSpace(answer))
                    {
                        questions.Add(new Question(content, a, b, c, d, answer));
                    }

                    i += 3;
                }   
            }

            doc.Close(false);
            wordApp.Quit();

            return questions;
        }
    }
}
