using AutoMapper;
using HighSchoolMarathon.DataAccess.Models;
using HighSchoolMarathon.WebApp.Models;

namespace HighSchoolMarathon.WebApp.Infrastructure
{
    public class MarathonProfile : Profile
    {
        public MarathonProfile()
        {
            CreateMap<RunningEvent, EventModel>().ReverseMap();
            CreateMap<RunnerRegistration, RegistrationModel>().ReverseMap();
            CreateMap<RunnerRegistration, RankingModel>();
        }
    }
}
