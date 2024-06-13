using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.Uploads
{
    public class AllowedFileExtensions
    {
        public IEnumerable<string> Extensions => new List<string>
        {
            "jpg", "png", "jpeg"
        };
    }
}
