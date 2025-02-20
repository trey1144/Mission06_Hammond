using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Hammond.Models
{
    public class Movies
    {
        // create properties for the form
        // get and set the values
        // MovieID is the key
        // this is the Movie table with all the columns and data types
        // CategoryID is a foreign key

        [Key]
        [Required]
        public int MovieID { get; set; }
        
        //sets up foreign key relationship
        [ForeignKey("CategoryID")]
        public int? CategoryID { get; set; }
        public Category? Category { get; set; }
        [Required(ErrorMessage = "You need to enter a movie title")]
        public string Title { get; set; }
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
        public string Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }
        [Required]
        public int Edited { get; set; }
        public string? LentTo { get; set; }
        [Required]
        public int CopiedToPlex { get; set; }
        public string? Notes { get; set; }
    }
}
