using System.ComponentModel.DataAnnotations;

namespace sendEmail.Models
{
    public class MailFields
    {
        [Required]
        public string To{ get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }

    }
}
