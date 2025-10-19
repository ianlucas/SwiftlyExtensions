using SwiftlyExtensions.Functions;
using SwiftlyS2.Shared.SchemaDefinitions;

namespace SwiftlyExtensions.Extensions;

/// <summary>
/// Extension methods for CCSPlayerPawn operations.
/// </summary>
public static class PlayerPawnExtensions
{
    /// <summary>
    /// Determines whether the player pawn is able to apply a spray.
    /// </summary>
    /// <param name="pawn">The player pawn to check.</param>
    /// <param name="ptr">Optional pointer parameter.</param>
    /// <param name="pvecForward">Optional forward vector pointer.</param>
    /// <param name="pvecRight">Optional right vector pointer.</param>
    /// <returns>True if the pawn is able to apply a spray, false otherwise.</returns>
    /// <exception cref="Exception">Thrown when SwiftlyExtensions are not initialized.</exception>
    public static bool IsAbleToApplySpray(
        this CCSPlayerPawn pawn,
        nint ptr = 0,
        nint pvecForward = 0,
        nint pvecRight = 0
    )
    {
        if (GameFunctions.IsAbleToApplySprayFn == null)
            throw new Exception("Extensions aren't initialized yet.");
        return GameFunctions.IsAbleToApplySprayFn.Call(pawn.Address, ptr, pvecForward, pvecRight)
            == nint.Zero;
    }
}
