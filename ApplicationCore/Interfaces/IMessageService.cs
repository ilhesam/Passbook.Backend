using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.ViewModels;
using Domain.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IMessageService : IAsyncService
        <Message, MessageAddDto, MessageEditDto, MessageGetDto>
    {
        Task<List<MessageGetDto>> GetUserMessagesAsync(string userId);

        Task<bool> ExistsAsync(string userId, string messageId);

        Task<MessageGetDto> AddAsync(string userId, MessageAddDto messageAddDto);

        Task<MessageGetDto> UpdateAsync(string userId, string messageId, MessageEditDto messageEditDto);
    }
}
