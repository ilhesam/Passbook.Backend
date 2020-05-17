using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.Entities;

namespace ApplicationCore.ViewModels
{
    public class LoginDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public Platform Platform { get; set; }
    }
}
