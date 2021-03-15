using System;
using static System.Convert;

namespace Survey_Project
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var alive = true;
            while (alive)
            {
                Console.WriteLine("Enter the command:");
                switch (Console.ReadLine())
                {
                    case "-new_form":
                        var form = new Form();
                        DbHandler.AddForm(DbHandler.NewProfile(form));
                        break;
                    //case "-restart_profile":
                    //RestartProfile();
                    case "-get_forms":
                        DbHandler.GetForms();
                        break;
                    case "-delete_form":
                        Console.WriteLine("Enter the id:");
                        DbHandler.DeleteForm(ToInt32(Console.ReadLine()));
                        break;
                    case "-exit":
                        alive = false;
                        continue;
                    default:
                        Console.WriteLine("Unknown command");
                        continue;
                }
            }
            
        }
    }
}