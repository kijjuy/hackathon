using System.ComponentModel.DataAnnotations;

public class Tag {
    

    [Key]
    public Guid Key { get; set; }

    public string TagName { get; set; }

}
