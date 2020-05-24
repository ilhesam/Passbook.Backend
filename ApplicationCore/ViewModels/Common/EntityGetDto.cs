using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.ViewModels
{
    public class EntityGetDto
    {
        public string Id { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }
    }
}
