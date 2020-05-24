using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Common
{
    public class Entity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        public DateTime UpdatedDateTime { get; set; } = DateTime.Now;
    }
}