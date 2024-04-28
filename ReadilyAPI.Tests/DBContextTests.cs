using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Tests
{
    internal class DBContextTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;

        public DBContextTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }
    }
}
