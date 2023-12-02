using Microsoft.AspNetCore.Identity;

public class ApplicationUser: IdentityUser {

    //TODO verify that email is mohawk college email
    //TODO add any other things for user

    public string Description { get; set; }   

    public List<Tag> Tags { get; set; }


}
