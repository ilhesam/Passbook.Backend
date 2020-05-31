using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.ViewModels;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Services
{
    public class MessageService : AsyncService
        <Message, MessageAddDto, MessageEditDto, MessageGetDto>,
        IMessageService
    {
        protected readonly IMessageRepository MessageRepository;

        public MessageService(IMessageRepository repository, IMapper mapper) : base(repository, mapper)
        {
            MessageRepository = repository;
        }

        public async Task<List<MessageGetDto>> GetUserMessagesAsync(string userId)
        => await MessageRepository.GetAllByUserId(userId)
            .Select(m => MapEntityToGetDto(m))
            .ToListAsync();

        public async Task<bool> ExistsAsync(string userId, string messageId)
            => await MessageRepository.ExistsAsync
                (m => m.Id == messageId && m.UserId == userId);

        public async Task<MessageGetDto> AddAsync(string userId, MessageAddDto messageAddDto)
        {
            var entity = MapAddDtoToEntity(messageAddDto);
            entity.UserId = userId;

            return await AddAsync(entity);
        }

        public async Task<MessageGetDto> UpdateAsync(string userId, string messageId, MessageEditDto messageEditDto)
        {
            var entity = MapEditDtoToEntity(messageEditDto);
            entity.UserId = userId;

            return await UpdateAsync(messageId, entity);
        }
    }
}
