using System;
using System.Collections.Generic;
using System.Text;
using Domain.Common;

namespace Domain.Entities
{
    public class Message : Entity
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }
    }
}
