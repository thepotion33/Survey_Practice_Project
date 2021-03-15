using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using static System.Convert;

namespace Survey_Project
{
    public static class DbHandler
    {
        public static void AddForm(Form form)
        {
            var db = new ApplicationContext();
            db.Forms.Add(form);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                Console.WriteLine("Form isn't found!");
                throw;
            }
            
            Console.WriteLine("Successfully added!");
        }

        public static void GetForms()
        {
            var db = new ApplicationContext();
            var forms = db.Forms.ToList();
            Console.WriteLine("Forms:");
            foreach (var form in forms)
            {
                Console.WriteLine($"ID:{form.Id}. Date Birth: {form.Date} - Programming language: {form.ProgLang} - Experience(in years): {form.Experience}");
            }
        }

        public static void DeleteForm(int id)
        {
            var db = new ApplicationContext();
            var entity = new Form() {Id = id};
            db.Forms.Remove(entity);
            db.SaveChanges();
            Console.WriteLine("Successfully removed!");
        }
        
        public static Form NewProfile(Form form)
        {
            Console.WriteLine("Enter your birth date: ");
            form.Date = Console.ReadLine();
            Console.WriteLine("Enter your programming language: ");
            form.ProgLang = Console.ReadLine();
            Console.WriteLine("Enter your experience (in years): ");
            form.Experience = ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your phone number: ");
            form.PhoneNumber = Console.ReadLine();
            return form;
        }
        
        public class ApplicationContext : DbContext
        {
            public DbSet<Form> Forms { get; set; }

            public ApplicationContext()
            {
                Database.EnsureCreated();
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=EntityDB;Trusted_Connection=True;");
                //optionsBuilder.LogTo(Console.WriteLine);
            }
            
        }
    }
}