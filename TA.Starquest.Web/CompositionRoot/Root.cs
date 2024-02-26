using System;

namespace TA.Starquest.Web.CompositionRoot;

internal static class Root
{
    /// <summary>
    ///     A unique identifier that changes at the start of each run of the program.
    /// </summary>
    public static Guid CorrelationId { get; } = Guid.NewGuid();
}