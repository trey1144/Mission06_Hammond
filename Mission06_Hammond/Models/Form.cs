using System.ComponentModel.DataAnnotations;

namespace Mission06_Hammond.Models
{
    public class Form
    {
        // create properties for the form
        // get and set the values
        // FormID is the key

        [Key]
        [Required]
        public int FormID { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public bool? Edited { get; set; }
        public string? Lent { get; set; }

        public string? Notes { get; set; }
    }
}
