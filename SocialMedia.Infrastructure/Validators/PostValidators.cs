﻿using FluentValidation;
using SocialMedia.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Validators
{
    public class PostValidators:AbstractValidator<PostDto>
    {
        public PostValidators()
        {
            RuleFor(post => post.Description)
                .NotNull()
                .Length(10, 15);

            RuleFor(post => post.Date)
                .NotNull()
                .LessThan(DateTime.Now);                
        }
    }
}
