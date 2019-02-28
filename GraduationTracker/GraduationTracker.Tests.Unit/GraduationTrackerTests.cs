using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        [TestMethod]
        public void TestHasCredits()
        {
            var tracker = new GraduationTracker();

            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            var students = new[]
            {
               new Student
               {
                   Id = 1,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=95 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                   }
               },
               new Student
               {
                   Id = 2,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=80 },
                        new Course{Id = 2, Name = "Science", Mark=80 },
                        new Course{Id = 3, Name = "Literature", Mark=80 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=80 }
                   }
               },
            new Student
            {
                Id = 3,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=50 },
                    new Course{Id = 2, Name = "Science", Mark=50 },
                    new Course{Id = 3, Name = "Literature", Mark=50 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=50 }
                }
            },
            new Student
            {
                Id = 4,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=40 },
                    new Course{Id = 2, Name = "Science", Mark=40 },
                    new Course{Id = 3, Name = "Literature", Mark=40 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=40 }
                }
            }


            //tracker.HasGraduated()
        };
            var diploma = Repository.GetDiploma(1);
            Student[] students = { Repository.GetStudent(1), Repository.GetStudent(2), Repository.GetStudent(3), Repository.GetStudent(4) };

            
            
            var graduated = new List<Tuple<bool, STANDING>>();

            foreach(var student in students)
            {
                graduated.Add(tracker.HasGraduated(diploma, student));      
            }

            Assert.AreEqual(2, graduated.Where(g => !g.Item1 && g.Item2.Equals(STANDING.Remedial)).Count()); // only two students must have failed
            Assert.IsTrue(graduated[2].Item2.Equals(STANDING.SumaCumLaude) && graduated[3].Item2.Equals(STANDING.Average));

        }

        [TestMethod]
        public void TestStudentHasOptedForAllRequiredCourses()
        {
            var tracker = new GraduationTracker();
            var diploma = Repository.GetDiploma(2);
            Student student = Repository.GetStudent(5);

            Tuple<bool, STANDING> result = tracker.HasGraduated(diploma, student);
            Assert.AreEqual(new Tuple<bool, STANDING>(false, STANDING.Remedial), result);

        }

        [TestMethod]
        public void TestStudentHasOptedForAtLeastOneCourses()
        {
            var tracker = new GraduationTracker();
            var diploma = Repository.GetDiploma(2);
            Student student = Repository.GetStudent(5);

            Tuple<bool, STANDING> result = tracker.HasGraduated(diploma, student);
            Assert.AreEqual(new Tuple<bool, STANDING>(false, STANDING.Remedial), result);
        }
        
        
    }
}
