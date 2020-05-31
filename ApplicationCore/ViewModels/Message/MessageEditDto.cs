using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.ViewModels
{
    public class MessageEditDto : EntityEditDto
    {
        public string Title { get; set; }

        public string Body { get; set; }
    }
}
