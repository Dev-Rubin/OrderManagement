using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OrderManagement.Application.Queryables;
using OrderManagement.Application.Repository;
using OrderManagement.Application.Response;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence.Interface;
using OrderManagement.Infrastructure.Persistence.Service;
using OrderManagement.Persistence.Persistence.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace OrderManagement.Logic.Repository
{
    public class JwtTokenGenerator : BasicCrudService<RefreshToken, int>, IJwtTokenGenerator
    {
        private readonly IConfiguration _config;

        public JwtTokenGenerator(IAppDbContext appDbContext, IConfiguration config, IUnitOfWork unitOfWork, IRepository repository, IQueries queries) : base(unitOfWork, repository, queries)
        {
            _config = config;
        }

        public async Task<Result<AuthResponseDto>> GenerateAsync(User user)
        {
            var keyString = _config["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key missing");

            if (Encoding.UTF8.GetByteCount(keyString) < 32)
                throw new InvalidOperationException("JWT Key must be at least 32 bytes");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };
            var value = _config["Jwt:ExpireHours"];
            int expireHours = int.TryParse(value, out var data) ? data : 1;
            DateTime expires = DateTime.UtcNow.AddHours(expireHours);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            string generatedToken = new JwtSecurityTokenHandler().WriteToken(token);
            string newRefreshToken = GenerateRefreshToken();

            var refreshToken = new RefreshToken
            {
                Token = newRefreshToken,
                UserId = user.Id,
                ExpiryDate = expires
            };

            var result = await Transact.ExecuteWithTransactionAsync(
                () =>
                {
                    Repository.SaveUpdate(refreshToken);
                }, "Token generated successfully.", "Failed to generate token."
            ).ConfigureAwait(false);

            if (!result.Result.IsSuccessful)
            {
                throw new Exception(result.Result.Message);
            }

            return Result<AuthResponseDto>.Success(new AuthResponseDto
            {
                AccessToken = generatedToken,
                RefreshToken = newRefreshToken,
                ExpiresIn = expires
            }, "Token refreshed");
        }

        public string GenerateRefreshToken()
        {
            var randomBytes = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }
        public async Task<Result<AuthResponseDto>> RefreshTokenAsync(string refreshToken)
        {

            var storedToken = await Queries.New<IRefreshTokenQuery>()
                .IncludeUser()
                .WhereTokenIs(refreshToken)
                .GetFirstOrDefaultAsync();

            if (storedToken == null || storedToken.IsRevoked || storedToken.ExpiryDate < DateTime.UtcNow)
                return Result<AuthResponseDto>.Failure("Invalid refresh token");

            if (storedToken.User == null) 
                return Result<AuthResponseDto>.Failure("User not found for the refresh token");

            var result = await Transact.ExecuteWithTransactionAsync(
                () =>
                {
                    storedToken.IsRevoked = true;
                    Repository.Update(storedToken);
                }, "Token refreshed successfully.", "Failed to refresh token."
            ).ConfigureAwait(false);

            if (!result.Result.IsSuccessful)
            {
                throw new Exception(result.Result.Message);
            }

            return await this.GenerateAsync(storedToken.User);

        }
    }
}
