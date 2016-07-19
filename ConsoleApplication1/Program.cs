using System;
using System.Data.Entity;
using System.Collections.Generic;
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
            insertNinja();
            insertMultipleNinjas();
            Console.ReadKey();
        }

        private static void insertNinja()
        {
            var ninja = new Ninja
            {
                Name = "JulieSan",
                ServedInOniwaban = false,
                DateOfBirth = new DateTime(1980, 1, 1),
                ClanId = 1
            };

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Ninjas.Add(ninja);
                context.SaveChanges();
            }
        }

        private static void insertMultipleNinjas()
        {
            var ninja1 = new Ninja
            {
                Name = "Leonardo",
                ServedInOniwaban = false,
                DateOfBirth = new DateTime(1984, 1, 1),
                ClanId = 1
            };

            var ninja2 = new Ninja
            {
                Name = "Raphael",
                ServedInOniwaban = false,
                DateOfBirth = new DateTime(1985, 1, 1),
                ClanId = 1
            };

            // using takes care of closing this connection on failure
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Ninjas.AddRange(new List<Ninja> { ninja1, ninja2 });
                context.SaveChanges();
            }
        }
    }
}
