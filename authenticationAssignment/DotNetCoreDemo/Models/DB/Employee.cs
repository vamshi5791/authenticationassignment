using System;
using System.Collections.Generic;

#nullable disable

namespace DotNetCoreDemo.Models.DB
{
    public partial class Employee
    {
        public int? EmpId { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Designation { get; set; }
        public string ShiftTime { get; set; }
        public string Possword { get; set; }
    }
}
