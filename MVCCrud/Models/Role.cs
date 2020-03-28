using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCrud.Models
{
    public class Role
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserRole { get; set; }
    }
}