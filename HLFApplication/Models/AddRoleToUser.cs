using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HLFApplication.Models
{
    public class AddRoleToUser
    {
        public string Email { get; set; }
        public string selectedRole { get; set; }
        public List<string> Roles { get; set; }

        public AddRoleToUser()
        {
            Roles = new List<string>();
        }
    }
}