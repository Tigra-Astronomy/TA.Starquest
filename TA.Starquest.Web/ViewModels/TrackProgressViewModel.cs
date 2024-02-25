using System.Collections.Generic;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.Web.ViewModels;

public class TrackProgressViewModel
{
    public string Name { get; set; }

    public int Number { get; set; }

    public virtual List<ChallengeViewModel> Challenges { get; set; }

    public string AwardTitle { get; set; }

    public Badge Badge { get; set; }

    public int BadgeId { get; set; }

    public int Id { get; set; }

    public int PercentComplete { get; set; }
}