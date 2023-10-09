using System.ComponentModel.DataAnnotations;

namespace NetCoreWebAPI.Models
{
    public class SmtpOptions
    {
        [Required(AllowEmptyStrings =false)]
        public string Server { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Port { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string FromAddress { get; set; }
    }
   
}
