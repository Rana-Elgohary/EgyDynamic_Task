using AutoMapper;
using EgyDynamic_Task.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EgyDynamic_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        UOW unit;
        IMapper mapper;

        public AccountController(UOW unit, IMapper mapper)
        {
            this.unit = unit;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult login(string userName, string password)
        {
            var employee = unit.EmployeeRepo.FirstOrDefault(e => e.اسم_المستخدم == userName && e.كلمه_المرور == password);
            if (employee != null)
            {
                List<Claim> Employee = new List<Claim>();
                Employee.Add(new Claim("name", employee.اسم_الموظف));
                Employee.Add(new Claim("id", employee.كود_الموظف.ToString()));

                string key = "Employee login Key string for security";
                var secertkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
                var signingcer = new SigningCredentials(secertkey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    claims: Employee,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: signingcer
                    );

                var tokenstring = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(tokenstring);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
