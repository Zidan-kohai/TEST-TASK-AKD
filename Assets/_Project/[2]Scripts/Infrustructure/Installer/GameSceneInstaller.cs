using AYellowpaper;
using Runtime.Carring;
using UnityEngine;
using Zenject;

namespace Infrustructure.Installer
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private InterfaceReference<IContainer, MonoBehaviour> _playerContainer;

        public override void InstallBindings()
        {
            BindPickUpValidator();
        }

        private void BindPickUpValidator()
        {
            this.Container
                .Bind<IInteractionValidator>()
                .To<InteractionValidator>()
                .AsSingle()
                .WithArguments(_playerContainer.Value);
        }
    }   
}
