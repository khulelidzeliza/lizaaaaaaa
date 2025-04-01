using lizaaaaaaa.Data;
using lizaaaaaaa.Model;
using BCrypt.Net;
using BCrypt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lizaaaaaaa.SMTP;
using lizaaaaaaa.Request;

namespace lizaaaaaaa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("register")]
        public ActionResult Register(AddUser req)
        {
            var user = new User
            {
                Email = req.Email,
                Password = req.Password,

            };

            user.Password = BCrypt.Net.BCrypt.HashPassword(req.Password);

            Random rand = new Random();
            string randomCode = rand.Next(1000, 9999).ToString();

            user.VerificationCode = randomCode;
            EmailSender emailSender = new EmailSender();
            emailSender.sendMail(req.Email, "verification , $"{ randomCode} ");
            _context.Users.Add(rand);
            _context.SaveChanges();

            return Ok();
        }
    }
}
