using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadSenseApi.Database;
using ReadSenseApi.Database.Entities;
using ReadSenseApi.Models;

namespace ReadSenseApi.Services
{
    /// <summary>
    /// Service To Download All Data Produced By The App
    /// </summary>
    /// <param name="context"></param>
    /// <param name="_mapper"></param>
    public class DataDownloadService(
        ReadSenseDBContext context,
        IMapper _mapper) : IDataDownloadService
    {

        /// <summary>
        /// Get All User Data as List of UserDataResponse Objects 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserDataResponse> GetUserData()
        {
            // get all user data with their devices and map it to UserDataResponse
            var data = context.Users
                .Include(u => u.Devices)
                .ThenInclude(d => d.Environments)
                .ThenInclude(e => e.ReadSettingsEvents)
                .ThenInclude(r => r.ScrollingEvents)
                .Select(u => _mapper.Map<UserDataResponse>(u));



            return data;
        }
    }
}
