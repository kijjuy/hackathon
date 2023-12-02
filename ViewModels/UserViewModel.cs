using System.ComponentModel.DataAnnotations;

public class UserViewModel {

    [Required]
    [StringLength(500, MinimumLength = 50)]
    public string? Description { get; set; }   

    public List<Tag>? Tags { get; set; }


}