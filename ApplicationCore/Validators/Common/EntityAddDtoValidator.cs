using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.ViewModels;
using FluentValidation;

namespace ApplicationCore.Validators.Common
{
    public class EntityAddDtoValidator<TEntityAddDto> : AbstractValidator<TEntityAddDto>
    where TEntityAddDto : EntityAddDto
    {
        public EntityAddDtoValidator()
        {
            
        }
    }
}
