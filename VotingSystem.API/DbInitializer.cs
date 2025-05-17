using Microsoft.EntityFrameworkCore;
using VotingSystem.API.Model.Entities;

namespace VotingSystem.API
{
    public static class DbInitializer
    {
        public static void Initialize(VotingSystemDbContext context)
        {
            context.Database.Migrate();

            // Check if any movies already exist
            if (context.Votes.Any())
            {
                return;
            }

            Vote[] votes = [
                new Vote {
                    Title = "What is your favorite color?",
                    VoteOptions = [
                        new VoteOption {
                            Title = "Green"
                        },
                        new VoteOption {
                            Title = "Purple"
                        },
                        new VoteOption {
                            Title = "Red"
                        }
                        ]
                }
                ];

            context.Votes.AddRange(votes);
            context.SaveChanges();
        }
    }
}
