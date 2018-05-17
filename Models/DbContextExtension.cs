using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace workspace.Models
{
    public static class DbContextExtension
    {

        public static bool AllMigrationsApplied(this DbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public static void EnsureSeeded(this DogsContext context)
        {

            //Check if any dogs in DB, if not seed.
            if (!context.Dog.Any())
            {
                using (StreamReader r = new StreamReader(@"Seed" + Path.DirectorySeparatorChar + "dogs.json"))
                {
                    var json = r.ReadToEnd();
                    JObject o = JObject.Parse(json);
                    foreach (var x in o)
                    {
                        string name = x.Key;
                        JArray types = (JArray)x.Value;
                        if(types.Count > 0)
                        {
                            foreach (var type in types.Children())
                            {
                                Dogs dog = new Dogs();
                                dog.Name = type.ToString() + " " + name;
                                context.Dog.Add(dog);

                            }
                        } else
                        {
                            Dogs dog = new Dogs();
                            dog.Name = name;
                            context.Dog.Add(dog);
                        }
                        
                    }

                }
                context.SaveChanges();
            }
        }
    }
}
