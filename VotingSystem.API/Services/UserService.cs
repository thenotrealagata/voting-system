﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using VotingSystem.API.Exceptions;
using VotingSystem.API.Infrastructure;
using VotingSystem.API.Model.Entities;

namespace VotingSystem.API.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JwtSettings _jwtSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            JwtSettings jwtSettings,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddUserAsync(User user, string password)
        {
            user.RefreshToken = Guid.NewGuid();
            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                throw new Exception($"Creating user failed with error: { result.Errors.First().Description }");
            }
        }

        public async Task<(string authToken, string refreshToken, string userId)> LoginAsync(string email, string password)
        {
            var user = _userManager.FindByEmailAsync(email).Result;
            if (user == null)
            {
                throw new AccessViolationException("Invalid authentication data!");
            }


            var result = _signInManager.PasswordSignInAsync(user.UserName!, password, true, false);
            if (!result.IsCompletedSuccessfully)
            {
                throw new AccessViolationException("Invalid authentication data!");
            }

            var accessToken = await GenerateJwtTokenAsync(user);
            return (accessToken, user.RefreshToken.ToString()!, user.Id);
        }

        public async Task LogoutAsync()
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
                return;

            await _signInManager.SignOutAsync();
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                throw new AccessViolationException("User not accessible");

            if (user.Id != GetCurrentUserId())
                throw new AccessViolationException("User not accessible");

            return user;
        }

        private async Task<string> GenerateJwtTokenAsync(User user)
        {
            var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Email!),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new("id", user.Id),
            new("username", user.UserName!),
        };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.AccessTokenExpirationMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<(string authToken, string refreshToken, string userId)> RedeemRefreshTokenAsync(string refreshToken)
        {
            if (!Guid.TryParse(refreshToken, out var parsedToken))
                throw new AccessViolationException("Invalid refresh token");

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == parsedToken);
            if (user == null)
                throw new AccessViolationException("Invalid refresh token");

            var accessToken = await GenerateJwtTokenAsync(user);

            return (accessToken, refreshToken, user.Id);
        }

        public async Task<User?> GetCurrentUserAsync()
        {
            var userId = GetCurrentUserId();
            if (userId == null)
                return null;

            return await _userManager.FindByIdAsync(userId);
        }

        public string? GetCurrentUserId()
        {
            var id = _httpContextAccessor.HttpContext?.User.FindFirstValue("id");
            if (id == null)
                return null;

            return id;
        }
    }
}
