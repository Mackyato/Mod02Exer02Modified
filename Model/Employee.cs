using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod02Exer02Modified.Model
{
    public class Employee
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public string? Department { get; set; }
        public bool IsActive { get; set; }

        public string FullNames => $"{FirstName ?? "Unknown"} {LastName ?? "Unknown"} {Position ?? "Unknown"} {Department ?? "Unknown"} {IsActive}";
    }
}
