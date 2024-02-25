using System.Collections.Generic;
using TA.Starquest.BusinessLogic.Preconditions;

namespace TA.Starquest.Web.ViewModels;

public class LevelProgressViewModel : IPreconditionXml
{
    public int Level { get; set; }

    public bool Unlocked { get; set; }

    public List<TrackProgressViewModel> Tracks { get; set; }

    public int OverallProgressPercent { get; set; }

    public int Id { get; set; }

    public string Precondition { get; set; }
}