using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [ValidateNever]
        public string? FirstName { get; set; }
        [ValidateNever]
        public string? LastName { get; set; }
        [ValidateNever]
        public string? ProfilePicture { get; set; }  //Save Profile Picture to DB 

        public bool IsActive { get; set; } = false;
    }
}
