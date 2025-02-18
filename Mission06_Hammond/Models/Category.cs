using System.ComponentModel.DataAnnotations;

namespace Mission06_Hammond.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
