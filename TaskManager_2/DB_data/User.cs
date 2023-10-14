using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_2.DB_data
{
    public class User
    {
        public User(string name, string password) 
        {
            Name = name;
            Password = password;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
