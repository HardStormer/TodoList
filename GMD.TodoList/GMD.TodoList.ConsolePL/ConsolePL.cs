using System;
using System.Collections.Generic;
using GMD.TodoList.StandartBLL;
using GMD.TodoList.Dependencies;
using GMD.TodoList.Entities;

namespace GMD.TodoList.ConsolePL
{
    public class ConsolePL
    {
        static void Main(string[] args)
        {
            var bll = DependencyResolver.Instance.tasksLogic;

            Console.WriteLine("Welcome to ToDoList");
            Console.WriteLine("1 - Add task");
            Console.WriteLine("2 - Delete task");
            Console.WriteLine("3 - Read all tasks");
            Console.WriteLine("4 - Search for a task");
            Console.WriteLine("5 - Mark task as done");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Write name:");
                    var crnm = Console.ReadLine();
                    while(bll.Find(crnm) != null)
                    {
                        Console.WriteLine("You have a task with that name, choose another name");
                        crnm = Console.ReadLine();
                    }
                    Console.WriteLine("Write text:");
                    var crtx = Console.ReadLine();
                    Console.WriteLine("What the priority of the task?(1-5)");
                    int crpr = Convert.ToInt32(Console.ReadLine());
                    while (!BetweenRanges(1, 5, crpr))
                    {
                        Console.WriteLine("Enter the number between 1 and 5");
                        crpr = Convert.ToInt32(Console.ReadLine());
                    }

                    Task newTask = new Task(crnm, crpr, crtx, Guid.NewGuid(), false);
                    bll.AddTask(newTask);
                    Console.WriteLine($"Added task with:");
                    WriteTask(newTask);
                    Console.WriteLine();
                    Main(args);
                    break;

                case "2":
                    Console.WriteLine("Enter the name of task, you want to be deleted");
                    string delnm = Console.ReadLine();
                    var findForDel = bll.Find(delnm);

                    if (findForDel != null)
                    {
                        bll.RemoveTask(delnm);
                        Console.WriteLine($"Task with name: '{delnm}' deleted");
                    }
                    else
                        Console.WriteLine($"Wheres no task with name: {delnm}");

                    Console.WriteLine();
                    Main(args);
                    break;

                case "3":
                    foreach (var task in bll.GetAll())
                    {
                        WriteTask(task);
                    }
                    Console.WriteLine();
                    Main(args);
                    break;

                case "4":
                    Console.WriteLine("Enter the name of task, you want to find");
                    string findnm = Console.ReadLine();
                    var find = bll.Find(findnm);

                    if (find != null)
                        WriteTask(find);
                    else
                        Console.WriteLine($"Wheres no task with name: {findnm}");

                    Console.WriteLine();
                    Main(args);
                    break;

                case "5":
                    Console.WriteLine("Enter the name of task, you want to make done");
                    string donenm = Console.ReadLine();
                    var findDone = bll.Find(donenm);

                    if (findDone != null)
                    {
                        bll.DoneTask(donenm);
                        Console.WriteLine($"Task with name {donenm} now done");
                    }
                    else
                        Console.WriteLine($"Wheres no task with name: {donenm}");

                    Main(args);
                    break;
                default:
                    Main(args);
                    break;
            }
            

        }

        private static void WriteTask(Task task)
        {
            Console.WriteLine($"Name: {task.Name}");
            Console.WriteLine($"Text: {task.Text}");
            Console.WriteLine($"Priority: {task.Priority}");

            if (task.Done == true)
                Console.WriteLine("> That task is done <");

            Console.WriteLine($"Creation date - {task.CreationDate}");
            Console.WriteLine("-------------------------");
        }
        private static bool BetweenRanges(int a, int b, int number)
        {
            return (a <= number && number <= b);
        }
    }
}
