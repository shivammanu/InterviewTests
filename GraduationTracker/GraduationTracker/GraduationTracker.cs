using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
       public class GraduationTracker
    {   
        public Tuple<bool, STANDING>  HasGraduated(Diploma diploma, Student student)
        {
            if (student.Courses == null || student.Courses.Count() == 0)
            {
                return new Tuple<bool, STANDING>(false, STANDING.Remedial);
            }
            var credits = 0;
            var average = 0;
            
            
          //  for(int i = 0; i < diploma.Requirements.Length; i++)
            int TotalNumberOfCourses = 0;

            foreach (Requirement r in diploma.Requirements)
            {
                //if the student does not have all the courses in the requirement then they do not graduate
                Course[] coursesSelected = student.Courses.Where(c => r.Courses.Contains(c.Id)).ToArray<Course>();
                if (coursesSelected.Count() == 0)
                {
                   /* var requirement = Repository.GetRequirement(diploma.Requirements[i]);

                    for (int k = 0; k < requirement.Courses.Length; k++)
                    {
                        if (requirement.Courses[k] == student.Courses[j].Id)
                        {
                            average += student.Courses[j].Mark;
                            if (student.Courses[j].Mark > requirement.MinimumMark)
                            {
                                credits += requirement.Credits;
                            }
                        }
                    }*/
                     return new Tuple<bool, STANDING>(false, STANDING.Remedial);
                }
            

           // average = average / student.Courses.Length;
            if (coursesSelected.Count() != r.Courses.Count())
                {
                    return new Tuple<bool, STANDING>(false, STANDING.Remedial);
                }
            //var standing = STANDING.None;
                average += coursesSelected.Select(c => c.Mark).Sum();
                int passedCourses = coursesSelected.Where(c => c.Mark > r.MinimumMark).Count();
                credits += passedCourses * r.Credits; //i've assumed that you only get credit points for the requirement if you complete all the courses in the requirement
                TotalNumberOfCourses += coursesSelected.Count();
            }
                
                
            average = average / TotalNumberOfCourses;

          //if the student does not have the number of credits necessary for the diploma then they do not graduate
            if (credits < diploma.CreditsToGraduate)
            {
            return new Tuple<bool, STANDING>(false, STANDING.Remedial);
            }

            switch (average)
            {
                case int n when (n < 50):
                    return new Tuple<bool, STANDING>(false, STANDING.Remedial);
                case int n when (n < 80):
                    return new Tuple<bool, STANDING>(true, STANDING.Average);
                case int n when (n < 90):
                    return new Tuple<bool, STANDING>(true, STANDING.MagnaCumLaude);
                case int n when (n <= 100):
                    return new Tuple<bool, STANDING>(true, STANDING.SumaCumLaude);

                default:
                    return new Tuple<bool, STANDING>(true, STANDING.Remedial);
            
            } 
        }
    }
}
