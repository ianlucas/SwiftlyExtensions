using SwiftlyS2.Shared;
using SwiftlyS2.Shared.Memory;

namespace SwiftlyExtensions.Functions;

/// <summary>
/// Internal class for managing game function signatures and native interop.
/// </summary>
internal static class GameFunctions
{
    public delegate nint IsAbleToApplySprayDelegate(
        nint pawnPtr,
        nint ptr,
        nint pvecForward,
        nint pvecRight
    );

    public delegate byte SetSignonStateDelegate(nint client, int state);

    public delegate nint ConnectDelegate(
        nint client,
        nint a2,
        nint a3,
        ushort userid,
        uint a5,
        byte a6,
        int a7
    );

    internal static IUnmanagedFunction<IsAbleToApplySprayDelegate>? IsAbleToApplySprayFn = null;

    internal static IUnmanagedFunction<SetSignonStateDelegate>? SetSignonStateFn = null;

    internal static IUnmanagedFunction<ConnectDelegate>? ConnectFn = null;

    private static void RegisterFunction<TDelegate>(
        ISwiftlyCore core,
        string signature,
        ref IUnmanagedFunction<TDelegate>? functionField
    )
        where TDelegate : Delegate
    {
        nint? address = core.GameData.GetSignature(signature);
        if (address is not null)
        {
            functionField = core.Memory.GetUnmanagedFunctionByAddress<TDelegate>(address.Value);
        }
    }

    internal static void Initialize(ISwiftlyCore core)
    {
        RegisterFunction(core, "CCSPlayerPawn::IsAbleToApplySpray", ref IsAbleToApplySprayFn);
        RegisterFunction(core, "CServerSideClientBase::SetSignonState", ref SetSignonStateFn);
        RegisterFunction(core, "CServerSideClientBase::Connect", ref ConnectFn);
    }
}
