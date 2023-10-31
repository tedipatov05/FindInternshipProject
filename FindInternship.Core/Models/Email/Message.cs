using MimeKit;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FindInternship.Core.Models.Email
{
    public class Message
    {
        [Required]
        public string From { get; set; } = null!;
        [Required]
        public string Subject { get; set; } = null!;
        [Required]
        public string Content { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;
    }
}
