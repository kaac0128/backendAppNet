using backendAppNet.Models.DataModels;

namespace backendAppNet.Services
{
    public interface IStudentsService
    {
        IEnumerable<Student> GetStudentsWithCourses();
        IEnumerable<Student> GetStudentsWithNoCourses();
        IEnumerable<Student> GetStudentsOfOneCourse();
    }
}
