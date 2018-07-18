using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks {
    public class RankedGradeBook : BaseGradeBook {
        public RankedGradeBook(string name) : base(name) {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade) {
            char result;
            if (Students.Count < 5) {
                throw new InvalidOperationException("Ranked need at least 5 Students");
            } else {            
                var temp = (int)Math.Ceiling(Students.Count * 0.2);
                var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

                if (grades[temp - 1] <= averageGrade) {
                    return 'A';
                } else if (grades[2 * temp - 1] <= averageGrade) {
                    return 'B';
                } else if (grades[3 * temp - 1] <= averageGrade) {
                    return 'C';
                } else if (grades[4 * temp - 1] <= averageGrade) {
                    return 'D';
                }

            }
            result = 'F';
            return result;
        }
    }
}
