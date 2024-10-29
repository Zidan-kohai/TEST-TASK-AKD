using System.Collections;
using UnityEngine;

namespace Infrustructure.Service.CoroutineController
{
    public class CoroutineСontroller : MonoBehaviour, ICoroutineController
    {
        public Coroutine Run(IEnumerator enumerator) =>
            StartCoroutine(enumerator);

        public void Stop(Coroutine coroutine) =>
            StopCoroutine(coroutine);
    }
}