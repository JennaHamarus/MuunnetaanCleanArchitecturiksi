using Moq;
using Microsoft.AspNetCore.Mvc;
using StudentEfCoreDemo.Application.Services;
using StudentEfCoreDemo.Domain.Entities;
using StudentEfCoreDemo.Presentation.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StudentEfCoreDemo.Presentation.Tests
{
    public class StudentControllerTests
    {
        private readonly Mock<StudentService> _studentServiceMock;
        private readonly StudentController _studentController;

        public StudentControllerTests()
        {
            _studentServiceMock = new Mock<StudentService>(MockBehavior.Strict, null);
            _studentController = new StudentController(_studentServiceMock.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnStudents()
        {
            //Arrange
            var students = new List<Student>
            {
                new Student { Id = 1, Name = "John", Age = 21 }
            };
            _studentServiceMock.Setup(service => service.GetAllStudentsAsync()).ReturnsAsync(students);

            //Act
            var result = await _studentController.GetAll();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnStudents = Assert.IsType<List<Student>>(okResult.Value);
            Assert.Single(returnStudents);
        }
    }
}
