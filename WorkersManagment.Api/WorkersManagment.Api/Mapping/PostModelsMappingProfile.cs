using AutoMapper;
using WorkersManagment.Api.Models;
using WorkersManagment.Core.Models;

namespace WorkersManagment.Api.Mapping
{
    public class PostModelsMappingProfile: Profile
    {
        public PostModelsMappingProfile()
        {
            CreateMap<WorkerAddModel,Worker>().ReverseMap();
            CreateMap<PositionPostModel, Position>().ReverseMap();
            CreateMap<WorkerPostModel, Worker>().ReverseMap();
            CreateMap<PositionWorkerPostModel, PositionWorker>().ReverseMap();
        }
    }
}
