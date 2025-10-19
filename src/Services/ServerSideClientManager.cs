using System.Collections.Concurrent;
using SwiftlyExtensions.Functions;
using SwiftlyS2.Shared;
using SwiftlyS2.Shared.SchemaDefinitions;

namespace SwiftlyExtensions.Services;

public class ServerSideClientManager : IServerSideClientManager
{
    private readonly ConcurrentDictionary<nint, ushort> _serverSideClientUserid = [];
    private readonly List<Func<CCSPlayerController, int, bool>> _middlewares = [];
    private readonly ISwiftlyCore _core;

    public ServerSideClientManager(ISwiftlyCore core)
    {
        _core = core;
        GameFunctions.ConnectFn?.AddHook(OnClientConnect);
        GameFunctions.SetSignonStateFn?.AddHook(OnClientSetSignonState);
    }

    private GameFunctions.ConnectDelegate OnClientConnect(Func<GameFunctions.ConnectDelegate> next)
    {
        return (client, a2, a3, userid, a5, a6, a7) =>
        {
            _serverSideClientUserid[client] = userid;
            return next()(client, a2, a3, userid, a5, a6, a7);
        };
    }

    private GameFunctions.SetSignonStateDelegate OnClientSetSignonState(
        Func<GameFunctions.SetSignonStateDelegate> next
    )
    {
        return (client, state) =>
        {
            ushort? userid = _serverSideClientUserid.TryGetValue(client, out var id) ? id : null;
            if (userid != null)
            {
                var player = _core.PlayerManager.GetPlayer((int)userid);
                if (player != null && !player.IsFakeClient && player.Controller != null)
                    if (!_middlewares.All(fn => fn(player.Controller, state)))
                        return 0;
            }
            return next()(client, state);
        };
    }

    public void AddSignonMiddleware(Func<CCSPlayerController, int, bool> handler)
    {
        _middlewares.Add(handler);
    }

    public void RemoveSignonMiddleware(Func<CCSPlayerController, int, bool> handler)
    {
        _middlewares.Remove(handler);
    }
}
