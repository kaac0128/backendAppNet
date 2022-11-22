using backendAppNet.Models.DataModels;

namespace backendAppNet.Services
{
    public interface IChaterService
    {
        IEnumerable<Chapter> GetChaptersOfOneCourse();
    }
}
