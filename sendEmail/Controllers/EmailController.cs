using Microsoft.AspNetCore.Mvc;

namespace sendEmail.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpGet]
        public IActionResult SendEmail()
        {
            return View();

        }



        [HttpPost]
        public IActionResult SendEmail(MailFields email)
        {
            _emailService.SendEmail(email);
            return Ok();

        }
        }
    }

