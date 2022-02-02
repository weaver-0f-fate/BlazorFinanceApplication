using AutoMapper;
using Core.Models;
using Services.DTO;

namespace Task13.MapperProfiles {
    public class MapperProfile : Profile {
        public MapperProfile() {
            CreateMap<OperationCreateDTO, Operation>().ReverseMap();
        }
    }
}
