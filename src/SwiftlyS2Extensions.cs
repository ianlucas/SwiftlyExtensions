using Microsoft.Extensions.DependencyInjection;
using SwiftlyS2.Core.Natives;
using SwiftlyS2.Shared;
using SwiftlyS2.Shared.Memory;
using SwiftlyS2.Shared.Plugins;
using SwiftlyS2.Shared.SchemaDefinitions;

namespace SwiftlyS2Extensions;

[PluginMetadata(
    Id = "SwiftlyS2Extensions",
    Version = "0.0.0",
    Name = "SwiftlyS2Extensions",
    Author = "Ian Lucas",
    Description = "A collection of utilities and extensions for SwiftlyS2."
)]
public static class GameFunctions
{
    delegate nint IsAbleToApplySprayDelegate(
        nint pawnPtr,
        nint ptr,
        nint pvecForward,
        nint pvecRight
    );

    private static IUnmanagedFunction<IsAbleToApplySprayDelegate>? IsAbleToApplySprayFn = null;

    public static void Initialize(ISwiftlyCore core)
    {
        nint? address = core.GameData.GetSignature("CCSPlayerPawn::IsAbleToApplySpray");
        if (address is not null)
        {
            IsAbleToApplySprayFn =
                core.Memory.GetUnmanagedFunctionByAddress<IsAbleToApplySprayDelegate>(
                    address.Value
                );
        }
    }

    public static bool IsAbleToApplySpray(this CCSPlayerPawn pawn, nint ptr = 0) =>
        IsAbleToApplySprayFn?.Call(pawn.Address, ptr, 0, 0) == nint.Zero;
}

public partial class SwiftlyS2Extensions : BasePlugin
{
    public SwiftlyS2Extensions(ISwiftlyCore core)
        : base(core)
    {
        GameFunctions.Initialize(core);
    }

    public override void ConfigureSharedInterface(IInterfaceManager interfaceManager) { }

    public override void UseSharedInterface(IInterfaceManager interfaceManager) { }

    public override void Load(bool hotReload) { }

    public override void Unload() { }
}
