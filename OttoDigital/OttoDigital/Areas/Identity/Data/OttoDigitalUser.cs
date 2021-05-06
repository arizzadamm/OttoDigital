using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace OttoDigital.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the OttoDigitalUser class
    public class OttoDigitalUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName ="nvarchar(100)")]
        public string UserID { get; set; }
        public string Password { get; set; }
    }
}
