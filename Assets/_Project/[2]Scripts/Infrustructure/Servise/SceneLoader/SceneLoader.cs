using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Infrustructure.Service.CoroutineController;
using Runtime.Curtain;

namespace Infrustructure.Service.SceneLoader
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ICurtain _curtain;
        private readonly ICoroutineController _coroutineRunner;

        public SceneLoader(ICurtain curtain, ICoroutineController coroutineRunner)
        {
            _curtain = curtain;
            _coroutineRunner = coroutineRunner;
        }

        public void LoadScene(int index, Action onLoaded)
        {
            var loadingProcess = SceneManager.LoadSceneAsync(index);

            _coroutineRunner.Run(LoadingScene(loadingProcess));
        }

        private IEnumerator LoadingScene(AsyncOperation loading)
        {
            _curtain.Show();

            while (!loading.isDone)
            {
                _curtain.SetProgress(loading.progress);
                yield return null;
            }

            _curtain.SetProgress(1);
            _curtain.Hide();
        }
    }
}