using ReadSenseApi.Database.Entities;
using ReadSenseApi.Models;

namespace ReadSenseApi.Services
{
    public interface IDataDownloadService
    {
        public IEnumerable<UserDataResponse> GetUserData();
    }
}
