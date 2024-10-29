using Feature.Quest;
using Infrustructure.Service.CoroutineController;
using Infrustructure.Service.SceneLoader;
using Runtime.Curtain;
using System;
using UnityEngine;
using Zenject;

namespace Infrustructure.Installer
{

    [CreateAssetMenu(fileName = "ServiseInstaller", menuName = "Installers/ServiseInstaller")]
    public class ServiseInstaller : ScriptableObjectInstaller<ServiseInstaller>
    {
        [SerializeField] private Curtain _curtainPrefab;

        public override void InstallBindings()
        {
            BindCoroutineRunner();

            BindCurtain();

            BindSceneLoader();

            BindQuestSystem();
        }

        private void BindQuestSystem()
        {
            this.Container
                .Bind<QuestHandler>()
                .ToSelf()
                .AsSingle();
        }

        private void BindSceneLoader()
        {
            this.Container
                .Bind<ISceneLoader>()
                .To<SceneLoader>()
                .AsSingle();
        }

        private void BindCurtain()
        {
            this.Container
                .Bind<ICurtain>()
                .To<Curtain>()
                .FromComponentInNewPrefab(_curtainPrefab)
                .AsSingle();
        }

        private void BindCoroutineRunner()
        {
            this.Container
                .Bind<ICoroutineController>()
                .To<CoroutineÑontroller>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();
        }
    }
}