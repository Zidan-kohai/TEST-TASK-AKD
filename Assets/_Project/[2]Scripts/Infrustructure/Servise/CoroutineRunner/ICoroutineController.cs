using System.Collections;
using UnityEngine;

namespace Infrustructure.Service.CoroutineController
{
    public interface ICoroutineController
    {
        public Coroutine Run(IEnumerator enumerator);
        public void Stop(Coroutine coroutine);
    }
}
