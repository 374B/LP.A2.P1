using System;
using System.Collections.Generic;
using LP.University.Domain.Student;
using LP.University.Domain.Subject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LP.University.Domain.Tests.Student
{
    //TODO: Missing tests to ensure only current subjects are included in calculations
    [TestClass]
    public class StudentWorkloadCalculatorTests
    {
        [TestMethod]
        [Description("WeeklyWorkload should return 0 when the student is not enrolled in any subjects")]
        public void WeeklyWorkload_Should_Return_0_For_Student_With_No_Subjects()
        {
            //Arrange

            var sut = new StudentWorkloadCalculator();

            var student = new Domain.Student.Student(sut, StudentDetailsItem.Default(), new List<SubjectEnrollment>());

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

            var subjects = CreateSubjectEnrollmentsFromTimespans(
                new TimeSpan[0]);

            var student = new Domain.Student.Student(sut, StudentDetailsItem.Default(), subjects);

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

            var subjects = CreateSubjectEnrollmentsFromTimespans(
                new TimeSpan[0],
                new TimeSpan[0],
                new TimeSpan[0]);


            var student = new Domain.Student.Student(sut, StudentDetailsItem.Default(), subjects);

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

            var subjects = CreateSubjectEnrollmentsFromTimespans(
                new[] { duration });

            var sut = new StudentWorkloadCalculator();

            var student = new Domain.Student.Student(sut, StudentDetailsItem.Default(), subjects);

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

            var subjects = CreateSubjectEnrollmentsFromTimespans(
                new[] { duration1, duration2, duration3 });

            var sut = new StudentWorkloadCalculator();

            var student = new Domain.Student.Student(sut, StudentDetailsItem.Default(), subjects);

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

            var subjects = CreateSubjectEnrollmentsFromTimespans(
                new[] { duration1 },
                new[] { duration2 },
                new[] { duration3 }
            );

            var sut = new StudentWorkloadCalculator();

            var student = new Domain.Student.Student(sut, StudentDetailsItem.Default(), subjects);

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

            var subjects = CreateSubjectEnrollmentsFromTimespans(
                    new[] { durationA1, durationA2 },
                    new[] { durationB1, durationB2 },
                    new[] { durationC1, durationC2 }
                );

            var sut = new StudentWorkloadCalculator();

            var student = new Domain.Student.Student(sut, StudentDetailsItem.Default(), subjects);

            //Act

            var workload = sut.CalculateWeeklyWorkload(student);

            //Assert

            var expectedDuration =
                durationA1 + durationA2
                + durationB1 + durationB2
                + durationC1 + durationC2;

            Assert.AreEqual(expectedDuration, workload);
        }

        /// <summary>
        /// Helper method to create a subject for each group of lectures (timespans)
        /// I.E Each of timespans will return a corresponding SubjectEnrollment
        /// </summary>
        /// <param name="lectureGroups"></param>
        /// <returns></returns>
        private List<SubjectEnrollment> CreateSubjectEnrollmentsFromTimespans(params IEnumerable<TimeSpan>[] lectureGroups)
        {
            var subjectEnrollments = new List<SubjectEnrollment>();

            var session = new SubjectSession
            {
                Start = DateTime.Now.AddDays(-1),
                End = DateTime.Now.AddDays(1)
            };

            foreach (var lectureGroup in lectureGroups)
            {
                var lectures = new List<Lecture.Lecture>();

                foreach (var timeSpan in lectureGroup)
                {
                    lectures.Add(new Lecture.Lecture { Duration = timeSpan });
                }

                var subject = new Subject.Subject(lectures);
                var subjectEnrollment = new SubjectEnrollment(subject, session);

                subjectEnrollments.Add(subjectEnrollment);

            }

            return subjectEnrollments;
        }

    }
}
