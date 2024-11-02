using System;
using UnityEngine;

namespace Runtime.Carring
{
    public interface IContainer
    {
        public bool HasEmptySlot();
        public void Add(IInteractable interactable);
        public void Remove(IInteractable interactable);

        IInteractable GetCurrentInteractable { get; }
    }
}
