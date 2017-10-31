using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad1
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }
        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj.GetType() == typeof(Student)))
            {
                return false;
            }

            var student = obj as Student;

            return this.Jmbag.Equals(student.Jmbag);
        }

        public override int GetHashCode()
        {
            return this.Jmbag.GetHashCode();
        }

        public static bool operator == (Student student1, Student student2)
        {
            return student1.Jmbag.Equals(student2.Jmbag);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !(student1.Jmbag.Equals(student2.Jmbag));
        }

    }

    public enum Gender
    {
        Male, Female
    }

}
