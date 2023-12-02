using System.ComponentModel.DataAnnotations;

namespace hackathon.ViewModels;

public class PrefSelectViewModel {

    [Display(Name = "Find a housemate")]
    public bool HousePref { get; set; }
    
    [Display(Name = "Find a studymate")]
    public bool StudyPref { get; set; }

    [Display(Name = "Find a friend")]
    public bool FriendPref { get; set; }

}