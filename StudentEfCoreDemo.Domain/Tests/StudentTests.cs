using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentEfCoreDemo.Domain.Entities;
using Xunit;

namespace StudentEfCoreDemo.Domain.Tests
{
    public class StudentTests
    {
        [Fact]
        public void Student_Should_Have_Valid_Properties()
        {
            //Arrange
            var student = new Student
            {
                Id = 1,
                Name = "John Doe",
                Age = 22
            };

            //Act & Assert
            Assert.Equal(1, student.Id);
            Assert.Equal("John Doe", student.Name);
            Assert.Equal(22, student.Age);
        }
    }
}
