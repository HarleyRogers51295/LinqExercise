using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers*******************************************

            Console.WriteLine("SUM && AVEERAGE");
            var sum = numbers.Sum(); //This gets the sum of all the indexes
            int average = sum / numbers.Length; //this devides the sum by the length of the array
            foreach (int num in numbers)//here we pring it out
            {
                Console.WriteLine(average);//need to put average here for it to print right. 
            }
            Console.WriteLine();

            //Order numbers in ascending order and decsending order. Print each to console.*****************************
           
            Console.WriteLine("ASCENDING");
            //var ascend = from num in numbers  (this would be the other method.)
            //             orderby num ascending
            //             select num;
            var ascend = numbers.OrderBy(x => x);
            foreach (int num in ascend) //need to put the name of the new array here.
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();

            Console.WriteLine("DECSENDING");
            //var descend = from num in numbers
            //             orderby num descending
            //             select num;
            var descend = numbers.OrderByDescending(x => x).ToArray();
            foreach (int num in descend)// need to put the name of the new array here.
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();



            //Print to the console only the numbers greater than 6*******************************

            Console.WriteLine("ONLY GREATER THAN 6");

            var greaterSix = numbers.Where(x => x > 6);
            foreach (int num in greaterSix)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**

            Console.WriteLine("ONLY 4 NUM");

            //var onlyFour = numbers.OrderBy(x => x).Take(4);//this only prints four!!Yay!
          
            foreach (int num in numbers.Take(4))
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();

            //Change the value at index 4 to your age, then print the numbers in decsending order

            Console.WriteLine("CHANGE INDEX 4 TO AGE, THEN DESCEND");

            numbers[4] = 25; //this changes the index.
            foreach (var items in numbers.OrderByDescending(x => x))//this puts it into descending order.
            {
                Console.WriteLine(items);
            }
            Console.WriteLine();

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            
            Console.WriteLine("C and S EMPLOYEES");

            var filteredNames = employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S'))
           .OrderBy(person => person.FirstName);
            foreach (var employee in filteredNames)
            {
                Console.WriteLine(employee.FullName);
            }
            Console.WriteLine();

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.

            Console.WriteLine("EMPLOYEES OVER 26");
            var over26 = employees.Where(x => x.Age > 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName);
            foreach (var person in over26)
            {
                Console.WriteLine($"{person.FullName}, {person.Age}, {person.YearsOfExperience}");
            }
            Console.WriteLine();

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35

            Console.WriteLine("SUM OF AVE EMPLOYEES YOE");

            var years = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            var sum2 = years.Sum(x => x.YearsOfExperience);
            var average2 = years.Average(x => x.YearsOfExperience);

            Console.WriteLine($"S:{sum2} A:{average2}");

            Console.WriteLine();

            //Add an employee to the end of the list without using employees.Add()

            employees.Append(new Employee("firstname", "lastname", 98, 1)).ToList();

            
            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
