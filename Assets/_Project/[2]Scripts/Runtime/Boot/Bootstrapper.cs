using Helper;
using Infrustructure.Service.SceneLoader;
using Runtime.Curtain;
using UnityEngine;
using Zenject;

namespace Runtime.Boot
{
    public class Bootstrapper : MonoBehaviour
    {
        private ISceneLoader _sceneLoader;
        private ICurtain _curtain;

        [Inject]
        public void Constructor(ISceneLoader sceneLoader, ICurtain curtain)
        {
            _sceneLoader = sceneLoader;
            _curtain = curtain;
        }

        private void Awake()
        {
            _sceneLoader.LoadScene(SceneIndex.Gameplay);
        }
    }
}
