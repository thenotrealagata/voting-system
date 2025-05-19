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

            User[] users = [
                new User {
                    Email = "admin@example.com",
                    Name = "Admin"
                },
                new User {
                    Email = "user1@example.com",
                    Name = "User1"
                }
                ];

            context.Users.AddRange(users);

            List<Vote> votes = [
                // Ongoing vote
                new Vote {
                    User = users[0],
                    Title = "What is your favorite color?",
                    CreatedAt = DateTime.Now,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(7),
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
                },
                // Past vote
                new Vote {
                    User = users[0],
                    Title = "What is your favorite city?",
                    CreatedAt = DateTime.Now.AddDays(-1),
                    StartTime = DateTime.Now.AddDays(-1),
                    EndTime = DateTime.Now.AddMinutes(-1),
                    VoteOptions = [
                        new VoteOption {
                            Title = "Budapest"
                        },
                        new VoteOption {
                            Title = "Paris"
                        },
                        new VoteOption {
                            Title = "Vienna"
                        }
                        ]
                },
                // Not available vote
                new Vote {
                    User = users[0],
                    Title = "Which is better?",
                    CreatedAt = DateTime.Now,
                    StartTime = DateTime.Now.AddDays(3),
                    EndTime = DateTime.Now.AddDays(7),
                    VoteOptions = [
                        new VoteOption {
                            Title = "Sajtos lángos"
                        },
                        new VoteOption {
                            Title = "Fokhagymás lángos"
                        }
                        ]
                },
                ];

            context.Votes.AddRange(votes);
            context.SaveChanges();
        }
    }
}
