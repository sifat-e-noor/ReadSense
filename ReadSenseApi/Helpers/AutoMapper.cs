using AutoMapper;
using Microsoft.Extensions.Logging;
using ReadSenseApi.Database.Entities;
using ReadSenseApi.Models;
using System.Text.Json.Nodes;

namespace ReadSenseApi.Helpers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<User, UserDataResponse>();
            CreateMap<Device, DeviceDataResponse>();
            CreateMap<Database.Entities.Environment, EnvironmentDataResponse>();
            CreateMap<ReadSettingsEvent, ReadSettingsEventData>();
            CreateMap<ScrollingEvent, ScrollingEventData>();
            CreateMap<string?, JsonNode?>().ConvertUsing<JsonNodeTypeConverter>();
        }
    }
}
