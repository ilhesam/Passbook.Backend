using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IMessageRepository : IAsyncRepository<Message>
    {
        IQueryable<Message> GetAllByUserId(string userId);
    }
}
