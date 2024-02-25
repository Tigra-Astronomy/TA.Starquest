namespace TA.Starquest.Web.ViewModels;

public class ChallengeViewModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Points { get; set; }

    public string Location { get; set; }

    public string BookSection { get; set; }

    public bool HasObservation { get; set; }
}