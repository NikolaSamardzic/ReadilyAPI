using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Tests.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Tests
{
    public class DatabaseFixture : IDisposable
    {
        private ReadilyContext _context;

        public ReadilyContext Context => _context;

        public DatabaseFixture()
        {
            _context = new ReadilyContext("Data Source=NIKOLA\\SQLEXPRESS;Initial Catalog=Readily_Test;TrustServerCertificate=true;Integrated security = true");

            CleanDB();
            InitDB(_context);
        }

        public void Dispose()
        {
            CleanDB();
        }

        private void CleanDB()
        {
            using SqlConnection connection = new SqlConnection("Data Source=NIKOLA\\SQLEXPRESS;Initial Catalog=Readily_Test;TrustServerCertificate=true;Integrated security = true");

            connection.Execute("CleanDatabase", commandType: CommandType.StoredProcedure);
        }

        private void InitDB(ReadilyContext _context)
        {
            RoleInit.Execute(_context);

            _context.SaveChanges();
        }
    }
}
