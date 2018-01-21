namespace LP.University.Domain.Student
{
    public interface IStudentRepository
    {
        StudentDetails LoadStudentDetailsById(int studentId);

        int CreateStudentDetails(StudentDetails studentDetails);

        Student LoadStudentAggregateById(int studentId);
    }
}
