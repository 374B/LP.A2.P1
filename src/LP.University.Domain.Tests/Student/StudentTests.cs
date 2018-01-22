using System.Collections.Generic;
using LP.University.Domain.Student;
using LP.University.Domain.Subject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LP.University.Domain.Tests.Student
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void WeeklyWorkload_Should_Use_The_StudentWorkloadCalculator()
        {
            //Arrange

            var calcMock = new Mock<IStudentWorkloadCalculator>();

            var sut = new Domain.Student.Student(
                calcMock.Object,
                StudentDetailsItem.Default(),
                new List<SubjectEnrollment>());

            //Act

            var workload = sut.WeeklyWorkload;

            //Assert

            calcMock.Verify(x => x.CalculateWeeklyWorkload(sut), Times.Once);
        }
    }
}
