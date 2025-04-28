using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentEfCoreDemo.Domain.Entities;
using StudentEfCoreDemo.Infrastructure.Persistence;
using StudentEfCoreDemo.Infrastructure.Repositories;
using Xunit;

namespace StudentEfCoreDemo.Infrastructure.Tests
{
   public class StudentRepositoryTests
    {
        private async Task<StudentDbContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<StudentDbContext>()
                .UseInMemoryDatabase(databaseName: "StudentDbTest")
                .Options;
            var databaseContext = new StudentDbContext(options);
            databaseContext.Database.EnsureCreated();

            if (await databaseContext.Students.CountAsync() <= 0)
            {
                databaseContext.Students.Add(new Student { Id = 1, Name = "Test Student", Age = 21 });
                await databaseContext.SaveChangesAsync();
            }
            return databaseContext;
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnStudents()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var repository = new StudentRepository(dbContext);

            //Act
            var result = await repository.GetAllAsync();

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal("Test Student", result[0].Name);
        }
    }
}
