using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSharpGenerics.Models;

namespace CSharpGenerics.WithoutGenerics
{
    public static class OriginalTextFileProcessor
    {
        public static List<Person> LoadPeople(string filePath)
        {
            List<Person> output = new List<Person>();
            Person p;
            var lines = File.ReadAllLines(filePath).ToList();

            lines.RemoveAt(0);

            foreach (var line in lines)
            {
                var vals = line.Split(",");
                p = new Person();

                p.FirstName = vals[0];
                p.IsAlive = bool.Parse(vals[1]);
                p.LastName = vals[2];
                output.Add(p);
            }
            return output;
        }
        public static List<LogEntry> LoadLog(string filePath)
        {
            List<LogEntry> output = new List<LogEntry>();
            LogEntry l;
            var lines = File.ReadAllLines(filePath).ToList();

            lines.RemoveAt(0);

            foreach (var line in lines)
            {
                var vals = line.Split(",");
                l = new LogEntry();

                l.Message = vals[0];
                l.ErrorCode = int.Parse(vals[1]);
                l.TimeOfError = DateTime.Parse(vals[2]);
                output.Add(l);
            }
            return output;
        }

        public static void SavePeople(List<Person> people, string filePath)
        {
            List<string> lines = new List<string>();

            //Add a new Header
            lines.Add("FirstName,IsAlive,LastName");

            foreach (var p in people)
            {
                lines.Add($"{p.FirstName},{p.IsAlive},{p.LastName}");
            }

            System.IO.File.WriteAllLines(filePath, lines);
        }
        public static void SaveLog(List<LogEntry> logs, string filePath)
        {
            List<string> lines = new List<string>();

            //Add a new Header
            lines.Add("Message,ErrorCode,TimeOfError");

            foreach (var l in logs)
            {
                lines.Add($"{l.Message},{l.ErrorCode},{l.TimeOfError}");
            }

            System.IO.File.WriteAllLines(filePath, lines);
        }
    }
}