using backendAppNet.Models.DataModels;

namespace backendAppNet.Services
{
    public interface ICoursesService
    {
        IEnumerable<Courses> GetCoursesOfCategory();
        IEnumerable<Courses> GetCoursesWithNoChater();
        IEnumerable<Courses> GetCoursesOfOneStudent();
    }
}
