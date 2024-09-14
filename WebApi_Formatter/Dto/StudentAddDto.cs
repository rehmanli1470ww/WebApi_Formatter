using System.ComponentModel.DataAnnotations;

namespace WebApi_Formatter.Dto
{
    public class StudentAddDto
    {
        [Required]
        public string? Fullname { get; set; }
        [Required]
        public string? SeriaNo { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public double Score { get; set; }
    }
}
