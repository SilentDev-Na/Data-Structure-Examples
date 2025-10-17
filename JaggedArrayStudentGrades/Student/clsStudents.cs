using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArrayStudentGrades.Student
{
    public class clsStudents
    {
        //public enum enPass
        //{
        //    Math = 80,
        //    English = 75,
        //    CSharp = 70,
        //}

        //enPass Pass;

        public int StudentID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public int Grade { get; set; }
        public bool IsActive { get; set; }



        public bool Passed
        {
            get
            {
                switch (this.Subject)
                {
                    case "Math":
                        return Grade >= 80;

                    case "English":
                        {
                            return Grade >= 75;
                        }

                    case "C#":
                        {
                            return Grade >= 70;
                        }

                    case "Science":
                        {
                            return Grade >= 80;
                        }

                    default:
                        return false;
                }
            }
        }
    }
}