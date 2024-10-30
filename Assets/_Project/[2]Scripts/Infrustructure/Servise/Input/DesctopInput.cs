using UnityEngine;

namespace Infrustructure.Service.Input
{
    public class DesctopInput : IInput
    {
        public bool IsE => UnityEngine.Input.GetKey(KeyCode.E);
    }
}
