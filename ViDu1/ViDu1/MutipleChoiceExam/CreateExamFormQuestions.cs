using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViDu1.MutipleChoiceExam
{
    class CreateExamFormQuestions
    {
        private readonly List<Question> questions;
        private readonly int numberOfExam;
        private readonly int numberOfQuestion;
        private readonly Random random = new Random(DateTime.Now.Second);

        public CreateExamFormQuestions(List<Question> questions, int numberOfExam, int numberOfQuestion)
        {
            if (numberOfExam <= 0)
                throw new ArgumentException("numberOfExam must be great than 0!");

            if (numberOfQuestion <= 0)
                throw new ArgumentException("numberOfQuestion must be great than 0!");

            if (questions == null || questions.Count <= numberOfQuestion)
                throw new ArgumentException("question size must be great than numberOfQuestion!");

            this.questions = questions;
            this.numberOfExam = numberOfExam;
            this.numberOfQuestion = numberOfQuestion;
        }

        public Dictionary<Int32, HashSet<Question>> excute()
        {
            Dictionary<Int32, HashSet<Question>> keyValues = new Dictionary<Int32, HashSet<Question>>();

            for (int i = 1; i <= numberOfExam; i++)
            {
                keyValues.Add(i, randomQuestion());
            }


            return keyValues;
        }

        private HashSet<Question> randomQuestion()
        {
            HashSet<Question> questions = new HashSet<Question>();
            int max = this.questions.Count;

            while (questions.Count < this.numberOfQuestion)
            {
                int index = random.Next(0, max);
                questions.Add(this.questions[index]);
            }

            return questions;
        }
    }

}
