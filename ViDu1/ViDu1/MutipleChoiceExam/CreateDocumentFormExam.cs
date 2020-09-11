using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void excute()
        {
            Console.WriteLine("Print document....");

            foreach(int key in keyValues.Keys)
            {
                Console.WriteLine("Đề số: " + key);

                HashSet<Question> value = keyValues[key];

                foreach(Question q in value)
                {
                    Console.WriteLine(q);
                }

                Console.WriteLine();
            }
        }
    }
}
