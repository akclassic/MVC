using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCrud.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desgination { get; set; }
        public decimal Salary { get; set; }
    }
}