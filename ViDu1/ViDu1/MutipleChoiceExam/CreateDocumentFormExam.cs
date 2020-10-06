using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ViDu1.MutipleChoiceExam
{
    class CreateDocumentFormExam
    {
        private readonly Dictionary<Int32, HashSet<Question>> keyValues;

        public CreateDocumentFormExam(CreateExamFormQuestions createExamFormQuestions)
        {
            if (createExamFormQuestions == null)
                throw new ArgumentNullException();

            this.keyValues = createExamFormQuestions.excute();
        }

        public void excute(string pathDeMau, string kiThi, string monThi, string doiTuong, string hinhThucThi, string thoiGian, string ngayThi, string maDe)
        {
            // Duong dan de chua thu muc de thi sinh ra
            string filePath = @"C:\Users\ADMIN\Documents\Test\";

            Application wordApp = new Application();
            Document sourceDoc = wordApp.Documents.Open(pathDeMau);

            sourceDoc.ActiveWindow.Selection.WholeStory();
            sourceDoc.ActiveWindow.Selection.Copy();

            // Khong thay doi noi dung
            sourceDoc.Close(false);

            foreach (int key in keyValues.Keys)
            {
                Document doc = wordApp.Documents.Add();
                doc.ActiveWindow.Selection.Paste();
                doc.Activate();

                string fileName = filePath + monThi + key + ".docx";
                // Hien thi duong dan
                Console.WriteLine(fileName);

                HashSet<Question> questions = keyValues[key];
                StringBuilder stringBuilder = new StringBuilder();

                for(int i=0; i<questions.Count; i++)
                {
                    Question q = questions.ElementAt(i);
                    stringBuilder.AppendLine("Câu " + (i + 1) + ": " + q.Content);
                    stringBuilder.AppendLine("A. " + q.A);
                    stringBuilder.AppendLine("B. " + q.B);
                    stringBuilder.AppendLine("C. " + q.C);
                    stringBuilder.AppendLine("D. " + q.D);
                }

                try
                {
                    this.FindAndReplace(wordApp, "$KYTHI$", kiThi);
                    this.FindAndReplace(wordApp, "$MONTHI$", monThi);
                    this.FindAndReplace(wordApp, "$DOITUONG$", doiTuong);
                    this.FindAndReplace(wordApp, "$HINHTHUCTHI$", hinhThucThi);
                    this.FindAndReplace(wordApp, "$THOIGIAN$", thoiGian);
                    this.FindAndReplace(wordApp, "$NGAYTHI$", ngayThi);
                    this.FindAndReplace(wordApp, "$MADE$", maDe);

                    Paragraph paragraph = doc.Paragraphs.Add();
                    paragraph.Range.Text = stringBuilder.ToString();

                    // Đoạn code bổ sung
                    // totalQuestion chính là tổng số câu hỏi, bạn có thể truyền nó vào phương thức excute ở trên

                    int totalQuestion = questions.Count;
                    int row = (totalQuestion%10 == 0)? (totalQuestion / 10) : (totalQuestion / 10) + 1;

                    Range range = doc.Paragraphs.Add().Range;
                    Table table = doc.Tables.Add(range, row, 10);
                    table.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
                    table.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;

                    int number = 1;

                    for (int j = 1; j <= row; j++)
                    {
                        for (int i = 1; i <= 10; i++)
                        {
                            if (number <= questions.Count)
                            {
                                Cell cell = table.Cell(j, i);
                                cell.Range.Text = number.ToString() + "-" + questions.ElementAt(number - 1).Answer.ToString();
                                number++;
                            }
                        }
                    }

                    // Kết thúc đoạn code
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }

                doc.SaveAs2(fileName);
                doc.Close();
            }

            // Thoat app
            wordApp.Quit();
        }

        private void FindAndReplace(Application wordApp, object findText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            wordApp.Selection.Find.Execute(ref findText,
                        ref matchCase, ref matchWholeWord,
                        ref matchWildCards, ref matchSoundLike,
                        ref nmatchAllForms, ref forward,
                        ref wrap, ref format, ref replaceWithText,
                        ref replace, ref matchKashida,
                        ref matchDiactitics, ref matchAlefHamza,
                        ref matchControl);
        }
    }
}
