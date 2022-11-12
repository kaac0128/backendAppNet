using backendAppNet.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace backendAppNet.Models.DataModels
{
    public class Courses: BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required, StringLength(280)]
        public string ShortDescription { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string TargetAudiences { get; set; } = string.Empty;
        [Required]
        public string Objectives { get; set; } = string.Empty;
        [Required]
        public string Requirements { get; set; } = string.Empty;
        [Required]
        public Levels Level { get; set; } = Levels.Essential;
        [Required]
        public ICollection<Category> Categories { get; set; } = new List<Category>();
        [Required]
        public Chapter Chapter { get; set; } = new Chapter();
        [Required]
        public ICollection<Student> Students { get; set; } = new List<Student>();
        
    }
}
