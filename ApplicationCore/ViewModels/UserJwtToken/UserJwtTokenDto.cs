using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace ApplicationCore.ViewModels
{
    public class UserJwtTokenDto
    {
        public string UserName { get; set; }

        public string AccessToken { get; set; }

        public DateTime AccessTokenExpiresDateTime { get; set; }

        public Platform TokenPlatform { get; set; }
    }
}
