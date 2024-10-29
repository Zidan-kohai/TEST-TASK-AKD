using System;

namespace Infrustructure.Service.SceneLoader
{
    public interface ISceneLoader
    {
        public void LoadScene(int index, Action onLoaded = null);
    }
}
