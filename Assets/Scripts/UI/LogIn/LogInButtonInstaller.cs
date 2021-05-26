using UnityEngine;
using Zenject;

namespace UI.LogIn
{
    public class LogInButtonInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ILogInButton>()
                     .To<LogInButton>()
                     .FromComponentsInHierarchy()
                     .AsCached();
        }
    }
}
