using SwiftlyS2.Shared;
using SwiftlyS2.Shared.Memory;

namespace SwiftlyExtensions.Functions;

public static class GameFunctions
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

    public static IUnmanagedFunction<IsAbleToApplySprayDelegate>? IsAbleToApplySprayFn
    {
        get;
        internal set;
    } = null;

    public static IUnmanagedFunction<SetSignonStateDelegate>? SetSignonStateFn
    {
        get;
        internal set;
    } = null;

    public static IUnmanagedFunction<ConnectDelegate>? ConnectFn { get; internal set; } = null;

    private static IUnmanagedFunction<TDelegate>? RegisterFunction<TDelegate>(
        ISwiftlyCore core,
        string signature
    )
        where TDelegate : Delegate
    {
        nint? address = core.GameData.GetSignature(signature);
        return address is not null
            ? core.Memory.GetUnmanagedFunctionByAddress<TDelegate>(address.Value)
            : null;
    }

    internal static void Initialize(ISwiftlyCore core)
    {
        IsAbleToApplySprayFn = RegisterFunction<IsAbleToApplySprayDelegate>(
            core,
            "CCSPlayerPawn::IsAbleToApplySpray"
        );
        SetSignonStateFn = RegisterFunction<SetSignonStateDelegate>(
            core,
            "CServerSideClientBase::SetSignonState"
        );
        ConnectFn = RegisterFunction<ConnectDelegate>(core, "CServerSideClientBase::Connect");
    }
}
