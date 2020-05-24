using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.ViewModels;
using FluentValidation;

namespace ApplicationCore.Validators.Common
{
    public class EntityEditDtoValidator<TEntityEditDto> : AbstractValidator<TEntityEditDto>
    where TEntityEditDto : EntityEditDto
    {
        public EntityEditDtoValidator()
        {

        }
    }
}
