using backendAppNet.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace backendAppNet.Models.DataModels
{
    public class Courses
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required, StringLength(280)]
        public string ShortDescription { get; set; } = string.Empty;
        [Required]
        public string LongDescription { get; set; } = string.Empty;
        [Required]
        public string TargetAudiences { get; set; } = string.Empty;
        [Required]
        public string Objectives { get; set; } = string.Empty;
        [Required]
        public string Requirements { get; set; } = string.Empty;
        [Required]
        public Levels Level { get; set; } = Levels.Essential;
    }
}
