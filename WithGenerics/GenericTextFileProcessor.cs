using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGenerics.WithGenerics
{
    public class GenericTextFileProcessor
    {
        public static List<T> LoadFromTextFile<T>(string filePath) where T : class, new()
        {
            List<T> output = new List<T>();
            var lines = File.ReadAllLines(filePath).ToList();
            T entry = new T();

            //getting properties of model to compare between header and property name
            var cols = entry.GetType().GetProperties();
            if (lines.Count < 2)
            {
                Console.WriteLine("No Message Found");
            }
            //split the header 
            var headers = lines[0].Split(',');

            //remove the header
            lines.RemoveAt(0);
            foreach (var row in lines)
            {
                entry = new T();
                var vals = row.Split(',');

                for (int i = 0; i < headers.Length; i++)
                {
                    foreach (var col in cols)
                    {
                        if (col.Name == headers[i])
                        {
                            col.SetValue(entry, Convert.ChangeType(vals[i], col.PropertyType));
                        }
                    }
                }
                output.Add(entry);
            }
            return output;
        }

        public static void SaveToTextFile<T>(List<T> data, string filePath) where T : class, new()
        {
            List<string> lines = new List<string>();
            StringBuilder line = new StringBuilder();

            if (data == null || data.Count == 0)
            {
                throw new ArgumentNullException("Data", "You must populate atleast one data");
            }
            var cols = data[0].GetType().GetProperties();

            //loops through each column and gets the name so it can comma saperate it into the header row
            foreach (var col in cols)
            {
                line.Append(col.Name);
                line.Append(",");
            }

            //Adds the column header entries to the first line
            lines.Add(line.ToString().Substring(0, line.Length - 1));

            foreach (var row in data)
            {
                line = new StringBuilder();
                foreach (var col in cols)
                {
                    line.Append(col.GetValue(row));
                    line.Append(",");
                }
                lines.Add(line.ToString());
            }
            File.WriteAllLines(filePath, lines);
        }
    }
}