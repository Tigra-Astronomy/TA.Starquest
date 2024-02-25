using System.ComponentModel.DataAnnotations;

namespace TA.Starquest.BusinessLogic.Models;

/// <summary>
///     DTO Data model for a Mission Level
/// </summary>
public record MissionLevelModel
{
    /// <summary>
    ///     The level name.
    /// </summary>
    [Required]
    public string Name { get; set; }

    public int Level { get; set; }

    /// <summary>
    ///     The name of the award granted upon level completion.
    /// </summary>
    [Required]
    public string AwardTitle { get; set; }

    /// <summary>
    ///     An XML precondition expression that must be satisfied in order for a user to unlock this level.
    /// </summary>
    public string Precondition { get; set; } = string.Empty;

    /// <summary>
    ///     The level unique ID.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///     The unique ID of the parent mission.
    /// </summary>
    public int MissionId { get; set; }
}
