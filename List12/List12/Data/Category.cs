using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace List12.Data
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
