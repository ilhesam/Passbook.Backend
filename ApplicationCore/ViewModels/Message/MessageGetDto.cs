using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.ViewModels
{
    public class MessageGetDto : EntityGetDto
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public string UserId { get; set; }
    }
}
