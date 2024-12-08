﻿using System.ComponentModel.DataAnnotations;

namespace StirCraftApp.Application.DTOs.CommentDtos;
using static Domain.Constants.EntityConstraints;
using static Domain.Constants.ValidationErrorMessages;

public class CommentFormDto : BaseDto
{

    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(CommentTitleMaxLength, MinimumLength = CommentTitleMinLength, ErrorMessage = StringLengthValidationErrorMessage)]
    public required string Title { get; set; }

    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(CommentBodyMaxLength, MinimumLength = CommentBodyMinLength, ErrorMessage = StringLengthValidationErrorMessage)]
    public required string Body { get; set; }

}
