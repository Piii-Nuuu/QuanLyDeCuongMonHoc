using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeCuongProject
{
    internal class Taikhoans
    {
        private string email;
        private string password;

        public Taikhoans()
        {
        }

        public Taikhoans(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
    }
}
