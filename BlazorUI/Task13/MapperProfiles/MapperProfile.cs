using AutoMapper;
using Core.Models;
using Services.DTO;

namespace Task13.MapperProfiles {
    public class MapperProfile : Profile {
        public MapperProfile() {
            CreateMap<Operation, OperationCreateDTO>()
                .ForMember(x => x.OperationTypeId, y => y.MapFrom(src => src.OperationTypeDTO.Id));
        }
    }
}
