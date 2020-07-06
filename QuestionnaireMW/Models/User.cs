using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnaireMW.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(10)]
        public string UserFName { get; set; }
        [Required]
        public string UserLName { get; set; }
        [Required]
        public string UserPassword { get; set; }
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string UserMobileNo { get; set; }
        [Required]
        public int UserResponseCount { get; set; }



    }
}
