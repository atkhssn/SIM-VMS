using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.Infrastructure.Model
{
    public class LoginModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

    }
}
