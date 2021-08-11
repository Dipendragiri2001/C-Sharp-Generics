using System;

namespace CSharpGenerics.Models
{
    public class LogEntry
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public DateTime TimeOfError { get; set; } = DateTime.Now;
    }
}