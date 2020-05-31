using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.ViewModels
{
    public class MessageAddDto : EntityAddDto
    {
        public string Title { get; set; }

        public string Body { get; set; }
    }
}
