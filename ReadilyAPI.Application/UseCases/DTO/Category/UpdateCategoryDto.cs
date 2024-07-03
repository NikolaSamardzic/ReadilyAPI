using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.DTO.Category
{
    public class UpdateCategoryDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public string Image { get; set; }
        public IEnumerable<int> ChildrenIds { get; set; } = new List<int>();
    }
}
