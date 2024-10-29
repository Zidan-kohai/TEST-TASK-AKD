using Infrustructure.Service.CoroutineController;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Runtime.Curtain
{
    public class Curtain : MonoBehaviour, ICurtain
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Image _imageProgress;
        [SerializeField] private float _fadeInTime = 0.5f;

        private ICoroutineController _coroutineController;
        private WaitForEndOfFrame _waitForEndOfFrame = new();

        [Inject]
        private void Constructor(ICoroutineController coroutineController)
        {
            _coroutineController = coroutineController;
        }

        private void Awake() => 
            DontDestroyOnLoad(this);

        public void SetProgress(float progress) => 
            _imageProgress.fillAmount = progress;

        public void Show()
        {
            gameObject.SetActive(true);
            _canvasGroup.alpha = 1.0f;
        }

        public void Hide()
        {
            _coroutineController.Run(FadeIn());
        }

        private IEnumerator FadeIn()
        {
            while (_canvasGroup.alpha >= 0)
            {
                _canvasGroup.alpha -= _fadeInTime * Time.deltaTime;
                yield return _waitForEndOfFrame;
            }

            gameObject.SetActive(false);
        }
    }
}
