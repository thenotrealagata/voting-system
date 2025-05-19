using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VotingSystem.API.Dto;
using VotingSystem.API.Model.Entities;
using VotingSystem.API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VotingSystem.API.Controllers
{
    [Route("api/votes")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService _voteService;
        private readonly IMapper _mapper;

        public VoteController(IVoteService voteService, IMapper mapper)
        {
            _voteService = voteService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(List<VoteResponseDto>))]
        public async Task<IActionResult> GetCurrentVotes()
        {
            var votes = await _voteService.GetAvailableVotesAsync();
            var voteResponseDtos = _mapper.Map<List<VoteResponseDto>>(votes);

            return Ok(voteResponseDtos);
        }

        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created, type: typeof(VoteResponseDto))]
        public async Task<IActionResult> AddVote([FromBody] VoteRequestDto voteRequestDto)
        {
            var vote = _mapper.Map<Vote>(voteRequestDto);
            await _voteService.AddAsync(vote);

            var voteResponseDto = _mapper.Map<VoteResponseDto>(vote);

            return CreatedAtAction(nameof(AddVote), new { id = voteResponseDto.Id }, voteResponseDto);

        }

    }
}
