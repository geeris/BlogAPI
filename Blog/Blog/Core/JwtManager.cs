using Blog.DataAccess;
using Blog.Implementation.UseCases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Api.Core
{
    public class JwtManager : EFUseCase
    {
        //moze se cuvati u app settings ali nije najbolje
        //enviroment variable ----- mi cemo cuvati u conf file
        readonly JwtSettings _settings;

        public JwtManager(BlogContext context, JwtSettings settings) : base(context)
        {
            _settings = settings;
        }

        public string MakeToken(string username, string password)
        {
            var user = _context.Users.Include(x => x.UseCases)
                .FirstOrDefault(x => x.Username == username);

            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }

            var valid = BCrypt.Net.BCrypt.Verify(password, user.Password);
            //1. password od korisnika

            if(!valid)
            {
                throw new UnauthorizedAccessException();
            }

            var useCases = _context.UserUseCases.Where(x => x.UserId == user.Id).Select(x => x.UseCaseId);

            var actor = new JwtUser
            {
                Id = user.Id,
                AllowedUseCases = user.UseCases.Select(x => x.UseCaseId).ToList(),
                Identity = user.Username,
                Username = user.Username,
                //AllowedUseCases = new List<int>()
            };

            //var issuer = "AspIspit";
            //var secret = "123ASDjfipoawopriqwop123124";

            var claims = new List<Claim> // Jti : "",
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iss, _settings.Issuer),
                //ovde se generise timestamp - kada je token napravljen
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _settings.Issuer),
                new Claim("UserId", actor.Id.ToString(), ClaimValueTypes.String, _settings.Issuer),
                new Claim("UseCases", JsonConvert.SerializeObject(actor.AllowedUseCases)),
                new Claim("Username", user.Username),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(_settings.Minutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}