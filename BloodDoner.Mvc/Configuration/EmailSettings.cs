using Microsoft.Build.Framework;

namespace BloodDoner.Mvc.Configuration
{
    public class EmailSettings
    {
        [Required]
        public string SmtpServer { get; set; } = string.Empty;
        public int Port { get; set; }
        
    }
}
