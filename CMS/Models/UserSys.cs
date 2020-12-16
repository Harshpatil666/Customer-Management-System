using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class UserSys
    {
        public int Id { get; set; }

        public string Login { get; set; }

        [Required(ErrorMessage = "Email can not be empty.", AllowEmptyStrings = false)]
        public string Email { get; set; }

        public int UserRoleId { get; set; }

        [Required(ErrorMessage = "Password can not be empty.", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)] 
        public string Password { get; set; }

    }
}