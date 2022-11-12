using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendAppNet.Models.DataModels
{
    public class Chapter: BaseEntity
    {
        [ForeignKey("Courses")]
        public int CourseId { get; set; }
        public virtual Courses Courses { get; set; } = new Courses();
        [Required]
        public string List = string.Empty;
    }
}
