namespace Lab1.Models;

using System.ComponentModel.DataAnnotations;

public class Employer
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }

    [Required]
    public string Website { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Incorporated Date")]
    public DateTime? IncorporatedDate { get; set; }
}
