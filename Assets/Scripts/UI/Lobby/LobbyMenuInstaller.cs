using UnityEngine;
using Zenject;

namespace UI.Lobby
{
    public class LobbyMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ILobbyMenu>()
                     .To<LobbyMenu>()
                     .FromComponentInHierarchy()
                     .AsCached();
        }
    }
}
