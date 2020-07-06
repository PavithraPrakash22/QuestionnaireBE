using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnaireMW.Models
{
    public class AnswerResponse
    {
        [Key]
        public int ResponseId { get; set; }
        [Required]
        public int UserResponseCount { get; set; }
        public string ans1 { get; set; }
        public string ans2 { get; set; }
        public string ans3 { get; set; }
        public string ans4 { get; set; }
        public string ans5 { get; set; }
        public string ans6 { get; set; }

        public string ans7 { get; set; }
        public string ans8 { get; set; }

        public string ans9 { get; set; }

        public string ans10 { get; set; }

        public string ans11 { get; set; }

        public string ans12 { get; set; }

        public string ans13 { get; set; }
        public string ans14 { get; set; }
        public string ans15 { get; set; }
        public string ans16 { get; set; }
        public string ans17 { get; set; }
        public string ans18 { get; set; }
        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
