using MVCProject.Base;

namespace MVCProject.Models
{
    public class Term:BaseEntity
    {
        public string Title { get; set; }      
        public string Description { get; set; }
    }
}
