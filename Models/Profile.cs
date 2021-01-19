using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public bool IsFromFacebook { get; set; }
        public bool IsFromGoogle { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime DateTimCreated { get; set; }
        public Profile()
        {
            IsEnabled = true;
            DateTimeCreated = DateTime.Now;
        }
    }
}
