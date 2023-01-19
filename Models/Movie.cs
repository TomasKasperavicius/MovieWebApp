using System.ComponentModel.DataAnnotations;

namespace Models;

public class Movie
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
     [Display(Name = "Producer name")]
    public string ProducerName { get; set; }
}

