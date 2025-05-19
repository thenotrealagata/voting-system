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

            CreateMap<VoteOptionRequestDto, VoteOption>(MemberList.Destination);
            CreateMap<VoteRequestDto, Vote>(MemberList.Destination);
        }
    }
}
