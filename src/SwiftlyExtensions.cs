using SwiftlyExtensions.Functions;
using SwiftlyExtensions.Services;
using SwiftlyS2.Shared;
using SwiftlyS2.Shared.Plugins;

namespace SwiftlyExtensions;

[PluginMetadata(
    Id = "SwiftlyExtensions",
    Version = "0.0.0",
    Name = "SwiftlyExtensions",
    Author = "Ian Lucas",
    Description = "A collection of utilities and extensions for SwiftlyS2."
)]
public partial class SwiftlyExtensions : BasePlugin
{
    private readonly SwiftlyExtensionsService _extensionsService;

    public SwiftlyExtensions(ISwiftlyCore core)
        : base(core)
    {
        GameFunctions.Initialize(core);
        _extensionsService = new(core);
    }

    public override void ConfigureSharedInterface(IInterfaceManager interfaceManager)
    {
        interfaceManager.AddSharedInterface<IExtensionService, SwiftlyExtensionsService>(
            "Extension.Service",
            _extensionsService
        );
    }

    public override void UseSharedInterface(IInterfaceManager interfaceManager) { }

    public override void Load(bool hotReload) { }

    public override void Unload() { }
}
