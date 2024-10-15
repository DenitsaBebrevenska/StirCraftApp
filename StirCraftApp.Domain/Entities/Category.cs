﻿using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constraints.EntityConstraints;

namespace StirCraftApp.Domain.Entities;
public class Category : BaseEntity
{
	[MaxLength(CategoryMaxLength)]
	public required string Name { get; set; }
}
