using System;
using System.Collections.Generic;
using CSharpGenerics.Models;
using CSharpGenerics.WithGenerics;
using CSharpGenerics.WithoutGenerics;

namespace CSharpGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            DemonstrateTextFileStorage();
            Console.WriteLine("Hello World!");
        }

        private static void DemonstrateTextFileStorage()
        {
            List<Person> people = new List<Person>();
            List<LogEntry> logs = new List<LogEntry>();

            string peopleFile = @"C:\Users\HP\Desktop\Practice\CSharpGenerics\people.csv";
            string logFile = @"C:\Users\HP\Desktop\Practice\CSharpGenerics\logs.csv";

            PopulateLists(people, logs);
            /****NEW WAY OF DOING THINGS WITH GENERICS***/
            GenericTextFileProcessor.SaveToTextFile<Person>(people, peopleFile);
            GenericTextFileProcessor.SaveToTextFile<LogEntry>(logs, logFile);

            /****OLD WAY OF DOING THINGS NON- GENERICS***/
            //OriginalTextFileProcessor.SavePeople(people, peopleFile);

            var newPeople = GenericTextFileProcessor.LoadFromTextFile<Person>(peopleFile);

            foreach (var p in newPeople)
            {
                Console.WriteLine($"{p.FirstName} {p.LastName} (IsAlive={p.IsAlive})");
            }
            // OriginalTextFileProcessor.SaveLog(logs, logFile);
            var newLogs = GenericTextFileProcessor.LoadFromTextFile<LogEntry>(logFile);
            foreach (var log in newLogs)
            {
                Console.WriteLine($"{log.ErrorCode} {log.Message} (IsAlive={log.TimeOfError.ToShortTimeString()})");
            }
        }

        private static void PopulateLists(List<Person> people, List<LogEntry> logs)
        {
            people.Add(new Person { FirstName = "Dipen", LastName = "Giri" });
            people.Add(new Person { FirstName = "Bijay", LastName = "Lama" });
            people.Add(new Person { FirstName = "Sherey", LastName = "Acharya", IsAlive = false });

            logs.Add(new LogEntry { Message = "Im Handsome", ErrorCode = 200 });
            logs.Add(new LogEntry { Message = "Im Beautiful", ErrorCode = 400 });
            logs.Add(new LogEntry { Message = "Im Superman", ErrorCode = 500 });

        }
    }
}
