using UnityEngine;

namespace Runtime.Carring
{
    public interface IInteractable
    {
        public Transform GetTransform { get; }

        public void SetContainer(IContainer container);

        public void DisableColliders();

        public void EnableColliders();
    }
}