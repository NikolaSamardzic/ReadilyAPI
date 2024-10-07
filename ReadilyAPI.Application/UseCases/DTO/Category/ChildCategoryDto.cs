using ReadilyAPI.Application.UseCases.DTO.Images;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.DTO.Category
{
    public class ChildCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
    }
}
