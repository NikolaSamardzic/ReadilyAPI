﻿using ReadilyAPI.Application.UseCases.DTO.Images;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.DTO.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public ImageDto Image { get; set; }
        public IEnumerable<ChildCategoryDto> Children { get; set; } = new List<ChildCategoryDto>();
    }
}
