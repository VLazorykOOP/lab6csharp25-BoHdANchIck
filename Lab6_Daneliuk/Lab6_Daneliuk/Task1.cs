using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_Daneliuk
{
    interface IShowable
    {
        void Show();
    }

    interface ITest : IShowable
    {
        string Name { get; set; }
        DateTime Date { get; set; }
    }

    interface IExam : ITest
    {
        string Subject { get; set; }
    }

    class Test : ITest, IComparable<Test>
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public Test(string name, DateTime date)
        {
            Name = name;
            Date = date;
        }

        public virtual void Show()
        {
            Console.WriteLine($"Test: {Name}, Date: {Date.ToShortDateString()}");
        }

        public int CompareTo(Test other)
        {
            return Date.CompareTo(other.Date);
        }
    }

    class Exam : Test, IExam
    {
        public string Subject { get; set; }

        public Exam(string name, DateTime date, string subject) : base(name, date)
        {
            Subject = subject;
        }

        public override void Show()
        {
            Console.WriteLine($"Exam: {Name}, Subject: {Subject}, Date: {Date.ToShortDateString()}");
        }
    }

    class FinalExam : Exam
    {
        public bool IsGraduationExam { get; set; }

        public FinalExam(string name, DateTime date, string subject, bool isGraduationExam)
            : base(name, date, subject)
        {
            IsGraduationExam = isGraduationExam;
        }

        public override void Show()
        {
            Console.WriteLine($"Final Exam: {Name}, Subject: {Subject}, Graduation: {IsGraduationExam}, Date: {Date.ToShortDateString()}");
        }
    }

    class Trial : Test
    {
        public string TypeOfTrial { get; set; }

        public Trial(string name, DateTime date, string typeOfTrial) : base(name, date)
        {
            TypeOfTrial = typeOfTrial;
        }

        public override void Show()
        {
            Console.WriteLine($"Trial: {Name}, Type: {TypeOfTrial}, Date: {Date.ToShortDateString()}");
        }
    }

}
