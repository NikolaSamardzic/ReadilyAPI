using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.DTO.Category
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
