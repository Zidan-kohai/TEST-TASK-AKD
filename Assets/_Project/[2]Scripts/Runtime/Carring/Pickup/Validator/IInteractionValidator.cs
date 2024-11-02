using TMPro;

namespace Runtime.Carring
{
    public interface IInteractionValidator
    {
        public IInteractable GetInteractible { get; }
        public IContainer GetContainer { get; }

        public bool CheckPickable();
        public bool CheckContainer();
    }
}
