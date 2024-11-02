using System;
using UnityEngine;

namespace Runtime.Carring
{
    [Serializable]
    public class Cell
    {
        public Transform Transform;
        public IInteractable Interactable;
    }
}
