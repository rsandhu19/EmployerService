using EmployerService.Controller;
using EmployerServiceDemo.Domain.Models;
using EmployerServiceDemo.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployerServiceDemo.Test.Unit.Controller
{
    [TestClass]
    public class EmployerControllerTests
    {
        private EmployerController employerController;
        private Mock<IEmployerService> mockEmployerService;
        private Mock<IEmployeeService> mockEmployeeService;
        private MockRepository moq;

        public EmployerControllerTests()
        {
            moq = new MockRepository(MockBehavior.Default);
            mockEmployeeService = moq.Create<IEmployeeService>();
            mockEmployerService = moq.Create<IEmployerService>();
            employerController = new EmployerController(mockEmployerService.Object, mockEmployeeService.Object);
        }

        [TestMethod]
        public void WhenCalled_GetAllEmployers_ReturnsOkResult()
        {
            //Arrange
            var mockServiceResponse = new List<Employer>
            {
                new Employer
                {
                    EmployerName = "Test",
                    EmployerId = 12345
                }
            };

            mockEmployerService.Setup(s => s.GetAllEmployers()).Returns(mockServiceResponse);

            //Act
            var actualResult = employerController.GetAllEmployers();


            //Assert
            var okResult = actualResult.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            var employersList = okResult.Value as List<Employer>;
            Assert.AreEqual(1, employersList.Count);

        }

        [TestMethod]
        public void WhenCalled_GetAllEmployers_ReturnsNotFound()
        {
            //Arrange
            var mockServiceResponse = new List<Employer>();           
            mockEmployerService.Setup(s => s.GetAllEmployers()).Returns(mockServiceResponse);

            //Act
            var actualResult = employerController.GetAllEmployers();

            //Assert
            var notFound = actualResult.Result as NotFoundResult;
            
            Assert.AreEqual(404, notFound.StatusCode);

        }

        [TestMethod]
        public void WhenCalledWithValidInput_GetEmployeesForEmployer_ReturnsOkResult()
        {
            //Arrange
            var mockServiceResponse = new List<Employee>
            {
                new Employee
                {
                    FirstName = "Adam",
                    LastName = "Carter"
                }
            };

            var inputEmployeeId = 1234;

            mockEmployeeService.Setup(s => s.GetEmployeesForEmployer(inputEmployeeId)).Returns(mockServiceResponse);

            //Act
            var actualResult = employerController.GetEmployeesForEmployer(inputEmployeeId);


            //Assert
            var okResult = actualResult.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            var employersList = okResult.Value as List<Employee>;
            Assert.AreEqual(1, employersList.Count);

        }

        [TestMethod]
        public void WhenCalledWithValidInput_GetEmployeesForEmployer_ReturnsNotFound()
        {
            //Arrange
            var mockServiceResponse = new List<Employee>();
            var inputEmployeeid = 1234;
            mockEmployeeService.Setup(s => s.GetEmployeesForEmployer(inputEmployeeid)).Returns(mockServiceResponse);

            //Act
            var actualResult = employerController.GetEmployeesForEmployer(inputEmployeeid);

            //Assert
            var notFound = actualResult.Result as NotFoundResult;

            Assert.AreEqual(404, notFound.StatusCode);

        }

        [TestMethod]
        public void WhenCalledWithNegativeInput_GetEmployeesForEmployer_ReturnsBadRequest()
        {
            //Arrange
            var mockServiceResponse = new List<Employee>();
            var inputEmployeeid = -1;
           
            //Act
            var actualResult = employerController.GetEmployeesForEmployer(inputEmployeeid);

            //Assert
            var notFound = actualResult.Result as BadRequestResult;

            Assert.AreEqual(400, notFound.StatusCode);

        }
    }
}
