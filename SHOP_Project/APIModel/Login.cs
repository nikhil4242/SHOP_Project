using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP_Project.APIModel
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        public string UserEmailID { get; set; }

        public string Password { get; set; }
    }
}
