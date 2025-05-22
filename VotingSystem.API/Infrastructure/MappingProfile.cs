using AutoMapper;
using VotingSystem.API.Dto;
using VotingSystem.API.Model.Entities;

namespace VotingSystem.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            // CreateMap<Movie, MovieViewModel>(MemberList.Destination);
            CreateMap<User, UserResponseDto>(MemberList.Destination);
            CreateMap<VoteOption, VoteOptionResponseDto>(MemberList.Destination);
            CreateMap<Vote, VoteResponseDto>(MemberList.Destination);
            CreateMap<User, UserResponseDto>(MemberList.Destination);

            CreateMap<VoteOptionRequestDto, VoteOption>(MemberList.Destination);
            CreateMap<VoteRequestDto, Vote>(MemberList.Destination);
            CreateMap<UserRequestDto, User>(MemberList.Source)
                .ForSourceMember(src => src.Password, opt => opt.DoNotValidate())
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
        }
    }
}
