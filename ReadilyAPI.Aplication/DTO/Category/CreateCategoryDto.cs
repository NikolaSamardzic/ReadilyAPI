using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Aplication.DTO.Category
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
