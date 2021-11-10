using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIMAN.Model
{
   public class Login
    {
        [Key]
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
