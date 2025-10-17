using JaggedArrayStudentGrades.Student;
using JaggedArrayStudentGrades.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace JaggedArrayStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<clsStudents> students = new List<clsStudents>();
            // Create a list to store all students. Each element is of type clsStudents.

            InitialValuesToStudents(students);
            // Fill the students list with initial/demo values. 
            // This method adds sample student data for testing.

            List<string> subjects = new List<string>();
            // Create a list to store unique subject names from the students list.

            GetSubjects(students, subjects);
            // Populate the subjects list with unique subject names found in the students list.

            int[][] jaggedGrades;
            BitArray[] passFlasgs;
            // Declare a jagged array to store grades of students per subject.
            // Declare an array of BitArray to store pass/fail flags for each student per subject.
            // Size is not specified yet because it depends on the number of subjects and students in each subject.

            PrepareGradesAndPassFlags(students, subjects, out jaggedGrades, out passFlasgs);
            // This method fills:
            // - jaggedGrades: a jagged array containing student grades for each subject.
            // - passFlasgs: an array of BitArray indicating pass/fail for each student per subject.

            DisplayResults(students, subjects, jaggedGrades, passFlasgs);
            // Display the results in the console:
            // For each subject, print student names, their grades, and pass/fail status in a formatted table.

        }
        static void InitialValuesToStudents(List<clsStudents> students)
        {
            students.AddRange(new List<clsStudents>()
        {
                new clsStudents { StudentID=1, Name="Alice", Subject="Math", Grade=90, IsActive=true },
                new clsStudents { StudentID=2, Name="Bob", Subject="Math", Grade=85, IsActive=true },
                new clsStudents { StudentID=3, Name="Charlie", Subject="English", Grade=78, IsActive=true },
                new clsStudents { StudentID=4, Name="Dave", Subject="Science", Grade=88, IsActive=true },
                new clsStudents { StudentID=5, Name="Emma", Subject="C#", Grade=92, IsActive=true },
                new clsStudents { StudentID=6, Name="Fiona", Subject="Math", Grade=79, IsActive=true }
        });

            //return students;
        }
        static void GetSubjects(List<clsStudents> students, List<string> Subjects)
        {
            foreach (var s in students)
            {
                if (!Subjects.Contains(s.Subject))
                    Subjects.Add(s.Subject);
            }
        }
        static void PrepareGradesAndPassFlags( List<clsStudents> students,
                                               List<string> subjects,
                                               out int[][] gradesJagged,
                                               out BitArray[] passFlags)
        {
            gradesJagged = new int[subjects.Count][];
            passFlags = new BitArray[subjects.Count];

            for (int i = 0; i < subjects.Count; i++)
            {
                var subjectStudents = students.FindAll(s => s.Subject == subjects[i]);

                gradesJagged[i] = new int[subjectStudents.Count];
                passFlags[i] = new BitArray(subjectStudents.Count);

                for (int j = 0; j < subjectStudents.Count; j++)
                {
                    gradesJagged[i][j] = subjectStudents[j].Grade;
                    passFlags[i][j] = subjectStudents[j].Passed;
                }
            }
        }
        static void DisplayResults(List<clsStudents> Students, List<string> Subject, int[][] jaggedGrades, BitArray[] passFalgs)
        {
            for (int i = 0; i < Subject.Count; i++)
            {
                WriteLine($"\t\t\t Subject {i + 1}");

                clsUtil.SetSeperator('-', 55);
                WriteLine($"{"Subject:",-10} {"Name:",-15} {"Grade:",15} {"Status:",10}");
                clsUtil.SetSeperator('-', 55);

                for (int j = 0; j < jaggedGrades[i].Length; j++)
                {

                    string status = passFalgs[i][j] ? "Pass" : "Fail";
                    var student = Students.Find(s => s.Subject == Subject[i] && s.Grade == jaggedGrades[i][j]);
                    WriteLine($"{Subject[i],-10} {student.Name,-15} {jaggedGrades[i][j],15} {status,10}");

                }
                clsUtil.SetSeperator('-', 55);

                WriteLine();
            }
        }
    }
}
