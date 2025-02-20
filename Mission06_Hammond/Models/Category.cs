using System.ComponentModel.DataAnnotations;

namespace Mission06_Hammond.Models
{
    // create a class for the category
    // make the Category table with the columns and data types
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
