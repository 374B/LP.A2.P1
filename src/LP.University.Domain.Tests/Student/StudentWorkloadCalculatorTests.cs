using System;
using System.Collections.Generic;
using LP.University.Domain.Student;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LP.University.Domain.Tests.Student
{
    [TestClass]
    public class StudentWorkloadCalculatorTests
    {
        [TestMethod]
        [Description("WeeklyWorkload should return 0 when the student is not enrolled in any subjects")]
        public void WeeklyWorkload_Should_Return_0_For_Student_With_No_Subjects()
        {
            //Arrange

            var sut = new StudentWorkloadCalculator();
            var student = new Domain.Student.Student(sut, StudentDetails.Default(), new List<Subject.Subject>());

            //Act

            var workload = sut.CalculateWeeklyWorkload(student);

            //Assert

            Assert.AreEqual(TimeSpan.FromTicks(0), workload);
        }

        [TestMethod]
        [Description("WeeklyWorkload should return 0 when the student has 1 subject, but the subject has no lectures")]
        public void WeeklyWorkload_Should_Return_0_For_Student_With_1_Subject_x_0_Lecture()
        {
            //Arrange

            var sut = new StudentWorkloadCalculator();

            var subjects = new List<Subject.Subject> { new Subject.Subject() };

            var student = new Domain.Student.Student(sut, StudentDetails.Default(), subjects);

            //Act

            var workload = sut.CalculateWeeklyWorkload(student);

            //Assert

            Assert.AreEqual(TimeSpan.FromTicks(0), workload);
        }

        [TestMethod]
        [Description("WeeklyWorkload should return 0 when the student has any number of subjects, none of which have any lectures")]
        public void WeeklyWorkload_Should_Return_0_For_Student_With_N_Subjects_x_0_Lectures()
        {
            //Arrange

            var sut = new StudentWorkloadCalculator();

            var subjects = new[]
            {
                new Subject.Subject(),
                new Subject.Subject(),
                new Subject.Subject()
            };

            var student = new Domain.Student.Student(sut, StudentDetails.Default(), subjects);

            //Act

            var workload = sut.CalculateWeeklyWorkload(student);

            //Assert

            Assert.AreEqual(TimeSpan.FromTicks(0), workload);
        }

        [TestMethod]
        [Description("WeeklyWorkload should return the correct result when a student has 1 subject with 1 lecture")]
        public void WeeklyWorkload_Should_Return_Correctly_For_Student_With_1_Subject_x_1_Lecture()
        {
            //Arrange

            var duration = TimeSpan.FromTicks(1234);

            //1 subject with 1 lecture
            var subj = new Subject.Subject(new[]
            {
                new Lecture.Lecture{ Duration = duration }
            });

            var sut = new StudentWorkloadCalculator();

            var student = new Domain.Student.Student(sut, StudentDetails.Default(), new[] { subj });

            //Act

            var workload = sut.CalculateWeeklyWorkload(student);

            //Assert

            Assert.AreEqual(duration, workload);
        }

        [TestMethod]
        [Description("WeeklyWorkload should return the correct result when a student has 1 subject with multiple lectures")]
        public void WeeklyWorkload_Should_Return_Correctly_For_Student_With_1_Subject_x_N_Lectures()
        {
            //Arrange

            var duration1 = TimeSpan.FromTicks(1234);
            var duration2 = TimeSpan.FromTicks(1234);
            var duration3 = TimeSpan.FromTicks(1234);

            //1 subject with multiple lectures
            var subj = new Subject.Subject(new[]
            {
                new Lecture.Lecture{ Duration = duration1 },
                new Lecture.Lecture{ Duration = duration2 },
                new Lecture.Lecture{ Duration = duration3 },
            });

            var sut = new StudentWorkloadCalculator();

            var student = new Domain.Student.Student(sut, StudentDetails.Default(), new[] { subj });

            //Act

            var workload = sut.CalculateWeeklyWorkload(student);

            //Assert

            var expectedDuration = duration1 + duration2 + duration3;

            Assert.AreEqual(expectedDuration, workload);
        }

        [TestMethod]
        [Description("WeeklyWorkload should return the correct result when a student has multiple subjects, each with 1 lecture")]
        public void WeeklyWorkload_Should_Return_Correctly_For_Student_With_N_Subjects_x_1_Lecture()
        {
            //Arrange

            var duration1 = TimeSpan.FromTicks(1234);
            var duration2 = TimeSpan.FromTicks(1234);
            var duration3 = TimeSpan.FromTicks(1234);

            //Multiple subjects, each with 1 lecture
            var subj1 = new Subject.Subject(new[] { new Lecture.Lecture { Duration = duration1 } });
            var subj2 = new Subject.Subject(new[] { new Lecture.Lecture { Duration = duration1 } });
            var subj3 = new Subject.Subject(new[] { new Lecture.Lecture { Duration = duration1 } });

            var subjects = new[] { subj1, subj2, subj3 };

            var sut = new StudentWorkloadCalculator();

            var student = new Domain.Student.Student(sut, StudentDetails.Default(), subjects);

            //Act

            var workload = sut.CalculateWeeklyWorkload(student);

            //Assert

            var expectedDuration = duration1 + duration2 + duration3;

            Assert.AreEqual(expectedDuration, workload);
        }

        [TestMethod]
        [Description("WeeklyWorkload should return the correct result when a student has multiple subjects, each with multiple lectures")]
        public void WeeklyWorkload_Should_Return_Correctly_For_Student_With_N_Subjects_x_N_Lectures()
        {
            //Arrange

            var durationA1 = TimeSpan.FromTicks(1);
            var durationA2 = TimeSpan.FromTicks(10);
            var durationB1 = TimeSpan.FromTicks(100);
            var durationB2 = TimeSpan.FromTicks(1000);
            var durationC1 = TimeSpan.FromTicks(10000);
            var durationC2 = TimeSpan.FromTicks(100000);

            //Multiple subjects, each with multiple lectures

            var subjA = new Subject.Subject(new[]
            {
                new Lecture.Lecture { Duration = durationA1 },
                new Lecture.Lecture { Duration = durationA2 }
            });

            var subjB = new Subject.Subject(new[]
            {
                new Lecture.Lecture { Duration = durationB1 },
                new Lecture.Lecture { Duration = durationB2 }
            });

            var subjC = new Subject.Subject(new[]
            {
                new Lecture.Lecture { Duration = durationC1 },
                new Lecture.Lecture { Duration = durationC2 }
            });

            var subjects = new[] { subjA, subjB, subjC };

            var sut = new StudentWorkloadCalculator();

            var student = new Domain.Student.Student(sut, StudentDetails.Default(), subjects);

            //Act

            var workload = sut.CalculateWeeklyWorkload(student);

            //Assert

            var expectedDuration =
                durationA1 + durationA2
                + durationB1 + durationB2
                + durationC1 + durationC2;

            Assert.AreEqual(expectedDuration, workload);
        }

    }
}
