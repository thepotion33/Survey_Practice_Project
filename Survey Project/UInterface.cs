using System;
using static System.Convert;

namespace Survey_Project
{
    public class UInterface
    {
        public void ReadCommand()
        {
            var alive = true;
            while (alive)
            {
                Console.WriteLine("Enter the command (-help for command list):");
                switch (Console.ReadLine()?.ToLower())
                {
                    case "-new_form":
                        NewFormCommand();
                        break;
                    case "-get_forms":
                        GetFormsCommand();
                        break;
                    case "-get_form":
                        GetFormCommand();
                        break;
                    case "-delete_form":
                        DeleteFormCommand();
                        break;
                    case "-exit":
                        alive = false;
                        break;
                    case "-help":
                        Console.WriteLine(
                            "Commands: \n -new_form - Creates new form \n -delete_form - Deletes form by id \n -get_forms - shows all forms \n -get_form - shows form by id \n -help - Shows all available commands \n -exit");
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        continue;
                }
            }
        }

        private static void NewFormCommand()
        {
            var form = new Form();
            DbHandler.AddForm(DbHandler.NewProfile(form));
        }

        private static void GetFormsCommand()
        {
            DbHandler.GetForms();
        }

        private static void GetFormCommand()
        {
            Console.WriteLine("Enter the id:");
            DbHandler.GetForm(ToInt32(Console.ReadLine()));
        }

        private static void DeleteFormCommand()
        {
            Console.WriteLine("Enter the id:");
            DbHandler.DeleteForm(ToInt32(Console.ReadLine()));
        }
        
    }
}