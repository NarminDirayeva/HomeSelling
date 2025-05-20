using MVCProject.Base;

namespace MVCProject.Models
{
    public class FAQ:BaseEntity
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
