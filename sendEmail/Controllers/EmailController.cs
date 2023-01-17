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
            if (!ModelState.IsValid) return View();
            try {
                _emailService.SendEmail(email);
                ViewBag.Message = "Mail Send";
                ModelState.Clear();
            } catch (Exception ex) {
                ViewBag.Message = ex.Message.ToString();
            }
                return View();
        }
    }
}

