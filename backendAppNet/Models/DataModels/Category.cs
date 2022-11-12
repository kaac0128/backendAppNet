using System.ComponentModel.DataAnnotations;

namespace backendAppNet.Models.DataModels
{
    public class Category: BaseEntity
    {
        [Required]
        public string Name {get; set; } = string.Empty;

        public ICollection<Courses> Courses { get; set; } = new List<Courses>();

    }
}
