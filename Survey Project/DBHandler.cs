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
            db.SaveChanges();
            Console.WriteLine("Successfully added!");
        }

        public static void GetForms()
        {
            var db = new ApplicationContext();
            var forms = db.Forms.ToList();
            if (forms.Capacity == 0)
            {
                Console.WriteLine("There are no forms!");
            }
            else
            {
                Console.WriteLine("Forms:");
                foreach (var form in forms)
                {
                    Console.WriteLine($"ID:{form.Id}. Date Birth: {form.Date} - Programming language: {form.ProgLang} - Experience(in years): {form.Experience} - Phone Number: {form.PhoneNumber}");
                } 
            }
        }

        public static void GetForm(int id)
        {
            var db = new ApplicationContext();
            try
            {
                var entity = db.Forms.First(f => f.Id == id);
                Console.WriteLine(($"ID:{entity.Id}. Date Birth: {entity.Date} - Programming language: {entity.ProgLang} - Experience(in years): {entity.Experience} - Phone Number: {entity.PhoneNumber}"));
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("There is no form for this id!");
            }
        }

        public static void DeleteForm(int id)
        {
            var db = new ApplicationContext();
            var entity = new Form() {Id = id};
            db.Forms.Remove(entity);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                Console.WriteLine("Form isn't found!");
                return;
            }
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