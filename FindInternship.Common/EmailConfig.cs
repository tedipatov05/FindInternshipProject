﻿namespace FindInternship.Common
{
    public class EmailConfig
    {
        public string To { get; set; } 
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
