using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using QuestionnaireMW.Models;
using QuestionnaireMW.Repository;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace QuestionnaireMW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("Validate/{email}/{password}")]
        public Token Get(string email, string password)
        {
            if (_repository.UserLogin(email, password) != null)
            {
                User response = _repository.UserLogin(email, password);
                return new Token() { UserName = response.UserFName + " " + response.UserLName, token = tokengen(), UserId = response.UserId, UserResponse = response.UserResponseCount };
            }
            else
            {
                return new Token() { UserName = "Invalid User", token = "", UserId = 0 };
            }
        }

        // GET: api/User/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/User
        [HttpPost]
        [Route("AddUser")]
        public IActionResult Post([FromBody] User item)
        {
            try
            {
                _repository.AddUser(item);
                return Ok("Record Added");
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

        }

        // PUT: api/User/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        public string GetToken()
        {
            var _config = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json").Build();
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(120);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes("3432"));
            var credentials = new SigningCredentials
        (securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: issuer,
        audience: audience,
        expires: DateTime.Now.AddMinutes(120),
        signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
        public string tokengen()
        {
            string key = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
            var securityKey = new Microsoft
               .IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials
                              (securityKey, SecurityAlgorithms.HmacSha256Signature);
            JwtHeader header = new JwtHeader(credentials);
            var payload = new JwtPayload
           {
               { "some ", "hello "},
               { "scope", "http://dummy.com/"},
           };
            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();
            var tokenString = handler.WriteToken(secToken);
            var token = handler.ReadJwtToken(tokenString);

            return (token.Payload.First().Value.ToString());
        }

    }
}
