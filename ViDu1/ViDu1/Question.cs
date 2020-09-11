using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViDu1
{
    class Question
    {
        private string content;
        private string answerA;
        private string answerB;
        private string answerC;
        private string answerD;
        private AnswerEnum answer;

        public enum AnswerEnum
        {
            A, B, C, D, None
        }

        public Question(string content, string A, string B, string C, string D, AnswerEnum answer)
        {
            this.content = content.Trim();
            this.answerA = A.Trim();
            this.answerB = B.Trim();
            this.answerC = C.Trim();
            this.answerD = D.Trim();
            this.answer = answer;
        }

        public string Content
        {
            set { this.content = value; }
            get { return this.content; }
        }

        public string A
        {
            set { this.answerA = value; }
            get { return this.answerA; }
        }

        public string B
        {
            set { this.answerB = value; }
            get { return this.answerB; }
        }

        public string C
        {
            set { this.answerC = value; }
            get { return this.answerC; }
        }

        public string D
        {
            set { this.answerD = value; }
            get { return this.answerD; }
        }

        public AnswerEnum Answer
        {
            set { this.answer = value; }
            get { return this.answer; }
        }

        public override string ToString()
        {
            return "[Content: "
                + content
                + ", A: "
                + answerA
                + ", B: "
                + answerB
                + ", C: "
                + answerC
                + ", D: "
                + answerD
                + "]";
        }
    }
}
