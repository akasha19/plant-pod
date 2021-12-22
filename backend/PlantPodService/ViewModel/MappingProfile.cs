using AutoMapper;
using PlantPodService.Model;

namespace PlantPodService.ViewModel
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PlantEntity, Plant>();
        }
    }
}
