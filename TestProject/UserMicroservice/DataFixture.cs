using Microsoft.EntityFrameworkCore;
using System;
using UsersMicroservice.Models;

namespace TestProject.UserMicroservice
{
    class DatabaseFixture : IDisposable
    {
        public DatabaseContext context;
        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase("UsersDB").Options;
            context = new DatabaseContext(options);
        }
        public void Dispose()
        {
            context = null;
        }

    }
}
