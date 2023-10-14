using System.ComponentModel.DataAnnotations;

namespace NetCoreWebAPI.Models
{
    public class SmtpOptions
    {
        public string Server { get; set; }

        public string Port { get; set; }

        public string FromAddress { get; set; }

    }
   
}
