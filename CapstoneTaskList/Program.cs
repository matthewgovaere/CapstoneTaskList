using System;
using System.Collections.Generic;

namespace CapstoneTaskList
{
    class Program
    {
        static void Main(string[] args)

        {
            Console.WriteLine("Welcome to the Task Manager!");

            List<string> taskList = new List<string>
            {
                "\t1.  List tasks", "\t2.  Add task", "\t3.  Delete task", "\t4.  Mark task complete", "\t5.  Quit"
            };

            PrintList(taskList);

            List<Duties> displayTasks = new List<Duties>
            {
                new Duties ("Edward", "trims hedges", DateTime.Parse("06/20/2020")),
                new Duties ("Terry", "clean pool", DateTime.Parse("05/13/2020")),
                new Duties ("Stephanie", "clean gutters", DateTime.Parse("03/13/2020")),

            };


            string option = GetUserInput("\nWhat would you like to do?");

            if (option == "1")
            {
                PrintList(displayTasks);
            }
            else if (option == "2") //want to add user input to displayTasks needs to include employee, duty, and dueDate
            {


                bool keepAdding = true;
                do
                {
                    AddUserInputToList(displayTasks);
                    keepAdding = KeepGoing("Do you have more tasks to add?", "n", "y");
                    PrintList(displayTasks);
                }
                while (keepAdding);

            }
            else if (option == "3")//delete task
            {
                string deleteTask = GetUserInput("\nWhat task do you want to delete?");


            }
            else if (option == "4")//mark complete
            {
                string markComplete = GetUserInput("\nWhat task do you want to complete?");


            }
            else
            {
                Console.WriteLine("\nHit enter to exit program");
            }
        }

        public static bool KeepGoing(string message, string option1, string option2)
        {
            string keepGoing = GetUserInput(message);
            if (keepGoing == option1)
            {
                return false;
            }
            else if (keepGoing == option2)
            {
                return true;
            }
            else
            {
                return KeepGoing("Not valid! " + message, option1, option2);
            }
        }

        public static void PrintList(List<Duties> taskList)
        {
            for (int i = 0; i < taskList.Count; i++)//have to input the fields from the duties class
            {
                Console.WriteLine();
                Console.WriteLine((i + 1) + ":");
                Console.WriteLine($"\t{taskList[i].Employee}");
                Console.WriteLine($"\t{taskList[i].DueDate}");
                Console.WriteLine($"\t{taskList[i].Duty}");
                Console.WriteLine(taskList[i].Complete == true ? "Completed" : "Not Completed");
                Console.WriteLine();

            }
        }
        public static void PrintList(List<string> taskList)
        {
            for (int i = 0; i < taskList.Count; i++)
            {
                Console.WriteLine($"{taskList[i]}");
            }
        }


        //Method to get userInput
        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        //Method to add task
        public static void AddUserInputToList(List<Duties> taskList)
        {
            string optionName = GetUserInput("\nWhat is their name?");
            string optionDescription = GetUserInput("\nWhat is their duty?");
            string optionDate = GetUserInput("\nWhen is it due?");

            taskList.Add(new Duties(optionName, optionDescription, DateTime.Parse(optionDate)));
        }



    }

}
