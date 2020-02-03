using System;
using System.ComponentModel.DataAnnotations;

namespace WebSiteUnderTest.Models
{
    public class Request
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Each Request needs a Title")]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Body { get; set; }

        [Required(ErrorMessage = "Please select a level")]
        public Level Level { get; set; }

        public DateTime? Created { get; set; }
    }

    public enum Level
    {
        Low,
        Medium,
        High
    }
}
