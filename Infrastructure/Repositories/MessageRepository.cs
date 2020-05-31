using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class MessageRepository : AsyncRepository<Message>, IMessageRepository
    {
        public MessageRepository(PassbookDbContext db) : base(db)
        {
        }

        public IQueryable<Message> GetAllByUserId(string userId)
        => GetAll().Where(p => p.UserId == userId);
    }
}
