using GPACalculation.CORE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPACalculation.UI
{
    public class UserInput
    {
        //method that collects the number of courses offered, course score, course unit and course code.
        public void TakeInputs()
        {

            ArrayList Course_Unit = new ArrayList();
            ArrayList Course_score = new ArrayList();
            ArrayList Course_Code = new ArrayList();

            //ask the user for the number of courses and converts it to an integar
            Console.Write("Please enter the number of courses registered: ");
            string NumberOfCourse = Console.ReadLine();
            int NumberOfCourses;

            //checks if the user entered a valid number of courses
            while (!int.TryParse(NumberOfCourse, out NumberOfCourses))
            {
                Console.Clear();
                Console.WriteLine("Input number of courses must be a number");
                Console.WriteLine("*************");
                Console.Write("Please enter a valid number of courses registered: ");

                NumberOfCourse = Console.ReadLine(); 
            }
          
            for (int i = 0; i < NumberOfCourses; i++)
            {
                Console.Write($"What is the Course code (e.g MTH101): ");
                Course_Code.Add(Console.ReadLine().ToUpper());


                Console.Write($"What is the Course unit for {Course_Code[i]}: ");
                string CourseUnit = Console.ReadLine();

                int Course_Units;
                while (!int.TryParse(CourseUnit, out Course_Units))
                {
                   
                    Console.Write("Please input a number for the Course unit field.. ");
                    CourseUnit = Console.ReadLine();
                    
                }
                Course_Unit.Add(Course_Units);


                Console.Write($"What is the score for {Course_Code[i]}: ");
                string Course_scores = Console.ReadLine();
                double CourseScore;
                while (!double.TryParse(Course_scores, out CourseScore))
                {
                    Console.Write("Please input a number for the Course score field.. ");
                    Course_scores = Console.ReadLine();
                   
                }
                Course_score.Add(CourseScore);

                Console.WriteLine("*************");

            }
            Console.Clear();

            var GradeCalculation = new GradeCalculations(Course_Code, Course_Unit, Course_score, NumberOfCourses);
            GradeCalculation.Calculator();
        }
    }
}
