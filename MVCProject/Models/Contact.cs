using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class Contact
        
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Firstname cannot be empty")]
        [StringLength(20, ErrorMessage = "Firstname cannot be longer than 20 simvols")]
        public string? Firstname { get; set; }

        [Required(ErrorMessage = "Lastname cannot be empty")]
        [StringLength(20, ErrorMessage = "Lastname cannot be longer than 20 simvols")]
        public string? Lastname { get; set; }

        [Required(ErrorMessage = "E-mail section cannot be empty")]
        [EmailAddress(ErrorMessage = "Please enter correct e-mail address")]
        public string? Email { get; set; }

        [Required(ErrorMessage="Please write something to subject section")]
        public string? Subject { get; set; }

        [Required(ErrorMessage = "Message section cannot be empty")]
        public string? Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
