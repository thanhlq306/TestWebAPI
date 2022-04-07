using APIWebTinTuc.Data;
using APIWebTinTuc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace APIWebTinTuc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDBcontext _context;
        private readonly Appsetting _appsetting;

        public UserController(MyDBcontext context, IOptionsMonitor<Appsetting> optionsMonitor)
        {
            _context = context;
            _appsetting = optionsMonitor.CurrentValue;
        }

        [HttpPost("Login")]
        public IActionResult Validate(LoginModel login)
        {
            var user = _context.dataUsers.SingleOrDefault(p => p.UserName == login.UserName
                                && login.Password == p.PassWord);
            if (user == null)
            {
                return Ok(new ApiRespon
                {
                    Success = false,
                    Message = "Sai mật khẩu/ tài khoản!"
                });
            }
            return Ok(new ApiRespon
            {
                Success = true,
                Message = "Truy cập thành công!",
                TokenID = GenerateToken(user)
            }) ;
        }

        private TokenModel GenerateToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appsetting.SecretKey);
            var tokenDesciption = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name,user.HoTen),
                    new Claim(JwtRegisteredClaimNames.Email,user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim("UserName",user.UserName),
                    new Claim("Id",user.Id.ToString()),

                    
                }),
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes),
                                                            SecurityAlgorithms.HmacSha512Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDesciption);

            var accessToken =  jwtTokenHandler.WriteToken(token);
            var refreshtoken = GenerateRefreshToken();

            //save database




            return new TokenModel
            {
                AccessToken = accessToken,
                RefreshToken = refreshtoken
            };
        }

        private string GenerateRefreshToken()
        {
            var bytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
