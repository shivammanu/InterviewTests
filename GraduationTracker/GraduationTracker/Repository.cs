
using System.Linq;


namespace GraduationTracker
{
    public class Repository
    {
        public static Student GetStudent(int id)
        {
            
            return GetStudents().Where(s => s.Id == id).Select(x => x).FirstOrDefault();
        }

        public static Diploma GetDiploma(int id)
        {
              return GetDiplomas().Where(d => d.Id == id).Select(x => x).FirstOrDefault();

        }

        public static Requirement GetRequirement(int id)
        {
            return GetRequirements().Where(r => r.Id == id).Select(x => x).FirstOrDefault();
        }


        private static Diploma[] GetDiplomas()
        {
            return new[]
            {
                new Diploma
                {
                    Id = 1,
                    CreditsToGraduate = 4,
                    Requirements = new Requirement[] { Repository.GetRequirement(100),
                                                   Repository.GetRequirement(102),
                                                   Repository.GetRequirement(103),
                                                   Repository.GetRequirement(104) }
                },

                new Diploma
                {
                    Id = 2,
                    CreditsToGraduate = 2,
                    Requirements = new Requirement[] { Repository.GetRequirement(100),}
                }
            };
        }

        public static Requirement[] GetRequirements()
        {   
                return new[]
                {
                   // new Requirement{Id = 100, Name = "Math", MinimumMark=50, Courses = new int[]{1}, Credits=1 },
                    new Requirement{Id = 100, Name = "Math", MinimumMark=50, Courses = new int[]{1,2}, Credits=1 },

                    new Requirement{Id = 102, Name = "Science", MinimumMark=50, Courses = new int[]{2}, Credits=1 },
                    new Requirement{Id = 103, Name = "Literature", MinimumMark=50, Courses = new int[]{3}, Credits=1},
                   // new Requirement{Id = 104, Name = "Physichal Education", MinimumMark=50, Courses = new int[]{4}, Credits=1 }
                    new Requirement{Id = 104, Name = "Physical Education", MinimumMark=50, Courses = new int[]{4}, Credits=1 }

                };
        }
        private static Student[] GetStudents()
        {
            return new[]
            {
               new Student
               {
                   Id = 1,
                   Courses = new Course[]
                    {     //this student has not opted for one of the required courses
                        new Course{Id = 1, Name = "Math", Mark=95 },
                       // new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=95 },
                        new Course{Id = 4, Name = "Physical Education", Mark=95 }
                   }
               },
               new Student
               {
                   Id = 2,
                   Courses = new Course[]
                   {
                       //this student doesn't have the number of credits necessary to graduate
                        new Course{Id = 1, Name = "Math", Mark=80 },
                        new Course{Id = 2, Name = "Science", Mark=20 },
                        new Course{Id = 3, Name = "Literature", Mark=80 },
                        new Course{Id = 4, Name = "Physical Education", Mark=80 }
                   }
               },
            new Student
            {
                Id = 3,
                Courses = new Course[]
                {
                    //this student graduates with the highest distinction
                    new Course{Id = 1, Name = "Math", Mark=95 },
                    new Course{Id = 2, Name = "Science", Mark=98 },
                    new Course{Id = 3, Name = "Literature", Mark=97 },
                    new Course{Id = 4, Name = "Physical Education", Mark=99 }
                }
            },
            new Student
            {
                Id = 4,
                Courses = new Course[]
                {
                    //this student graduates with average standing
                    new Course{Id = 1, Name = "Math", Mark=70 },
                    new Course{Id = 2, Name = "Science", Mark=70 },
                    new Course{Id = 3, Name = "Literature", Mark=70 },
                    new Course{Id = 4, Name = "Physical Education", Mark=70 }
                }
             },
            new Student
            {
                Id = 5,
                Courses = null
            }

            };
        }
    }


}
