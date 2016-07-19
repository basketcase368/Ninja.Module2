using System;
using System.Data.Entity;
using NinjaDomain.Classes;
using NinjaDomain.DataModel;

namespace ConsoleApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Prevents data initialization from occuring.
            Database.SetInitializer(new NullDatabaseInitializer<NinjaContext>());

            // Methods demonstrating EF functionality
            InsertNinja();
            Console.ReadKey();
        }

        private static void InsertNinja()
        {
            var ninja = new Ninja
            {
                Name = "JulieSan",
                ServedInOniwaban = false,
                DateOfBirth = new DateTime(1980, 1, 1),
                ClanId = 1
            };

            using(var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Ninjas.Add(ninja);
                context.SaveChanges();
            }
        }
    }
}
