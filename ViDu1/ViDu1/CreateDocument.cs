using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViDu1
{
    class CreateDocument
    {
        private readonly Dictionary<Int32, HashSet<Question>> keyValues;

        public CreateDocument(CreateExam createExam)
        {
            if (createExam == null)
                throw new ArgumentNullException();

            this.keyValues = createExam.excute();
        }

        public void excute()
        {
            Console.WriteLine("Print document....");

            Console.WriteLine(keyValues);
        }
    }
}
