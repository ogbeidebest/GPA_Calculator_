using GPACalculation.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPACalculation.CORE
{
    public class GradeCalculations
    {
        //
        ArrayList Course_Code;
        ArrayList Course_Grade = new ArrayList();
        ArrayList Course_Unit ;
        ArrayList Course_score ;
        ArrayList Grade_Unit = new ArrayList();
        ArrayList Course_WeightPoint = new ArrayList();
        ArrayList Remark = new ArrayList();
        int NumberOfCourses;

        //creates a construcctor that takes course code, course unit , vourse score and number of courses from the inpuntCollectors class 
        public GradeCalculations(ArrayList CourseCode, ArrayList CourseUnit, ArrayList Course_score, int NumberOfCourses)
        {
            this.Course_Code = CourseCode;
            this.Course_Unit = CourseUnit;
            this.Course_score = Course_score;
            this.NumberOfCourses = NumberOfCourses;
        }

        //a method that calculates the grade, weight point, grade, grade unit, add remarks and calculate the gpa
        public void Calculator()

        {
            
            var Table = new PrintTable("Course_Code", "Course_Unit", "Coure_Score", "Course_Grade",
              "Grade_Unit", "Weight_Point", "Remark");

            for (int j = 0; j < NumberOfCourses; j++)
            {
                
                double CourseScores = Convert.ToDouble(Course_score[j]);


                //calculates the grade, grade unit and add remarks then put to their respective arraylist
                switch (CourseScores)
                {
                    case >= 70:

                        Course_Grade.Add("A");
                        Remark.Add("Excellent");
                        Grade_Unit.Add("5"); ;
                        break;

                    case >= 60:
                        Course_Grade.Add("B");
                        Remark.Add("Very Good");
                        Grade_Unit.Add("4");
                        break;

                    case >= 50:
                        Course_Grade.Add("C");
                        Remark.Add("Good");
                        Grade_Unit.Add("3");
                        break;

                    case >= 45:
                        Course_Grade.Add("D");
                        Remark.Add("Fair");
                        Grade_Unit.Add("2");
                        break;

                    case >= 40:
                        Course_Grade.Add("E");
                        Remark.Add("Pass");
                        Grade_Unit.Add("1");
                        break;

                    default:
                        Course_Grade.Add("F");
                        Remark.Add("Fail");
                        Grade_Unit.Add("0");
                        break;

                }


            }
            //calculates and add Course_weightPoint and add to ccourse_weightPoint arraylist
            for (int i = 0; i < NumberOfCourses; i++)
            {
                int GradeUnits = Convert.ToInt32(Grade_Unit[i]);
                int CourseUnits = Convert.ToInt32(Course_Unit[i]);
            
                Course_WeightPoint.Add((GradeUnits * CourseUnits).ToString());

            }
            //calls the addrow method from the printable class and add every item to their respective rows 
            int Counter = 0;
            while (Counter < NumberOfCourses)
            {
                Table.AddRow(Course_Code[Counter], Course_Unit[Counter], Course_score[Counter], 
                    Course_Grade[Counter],Grade_Unit[Counter], Course_WeightPoint[Counter], Remark[Counter]);
                Counter++;
            }

            Table.Print();

            Console.WriteLine("");
            Console.WriteLine("");
            
            //calulate the total course weight, total grade unit and total course unit
            int Total_Course_Weigth = 0;
            int Total_Grade_Uint = 0;
            int Total_Course_unit = 0;

            for (int i = 0; i < NumberOfCourses; i++)
            {
                Total_Course_Weigth += Convert.ToInt32(Course_WeightPoint[i]);
               
                
                if (Course_Grade[i] != "F")
                {
                    Total_Grade_Uint += Convert.ToInt32(Course_Unit[i]);
                }
                else
                {
                    Total_Grade_Uint += 0;
                }
                Total_Course_unit += Convert.ToInt32(Course_Unit[i]);
            }

            //calculates the gpa
            double GPA = ((double)Total_Course_Weigth / Total_Course_unit);

            decimal GPAGrade = Decimal.Parse(GPA.ToString("0.00"));

            //print out the total course unit, total grade unit and total_Course_ weight
            Console.WriteLine($"Total Course Unit Registered is: {Total_Course_unit}");
            Console.WriteLine($"Total Course Unit Passed is: {Total_Grade_Uint}");
            Console.WriteLine($"Total Weight Point is: {Total_Course_Weigth}");

            Console.WriteLine($"Your GPA is = {GPAGrade}");
        }
    }
}
