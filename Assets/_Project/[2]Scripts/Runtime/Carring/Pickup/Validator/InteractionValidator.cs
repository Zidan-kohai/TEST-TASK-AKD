using UnityEngine;

namespace Runtime.Carring
{
    public class InteractionValidator : IInteractionValidator
    {
        private const float rayDist = 5f;
        private readonly IContainer _playerContainer;
        private readonly Camera _camera;
        private IInteractable _findInteractable;
        private IContainer _findContainer;

        public IInteractable GetInteractible => _findInteractable;
        public IContainer GetContainer => _findContainer;

        public InteractionValidator(IContainer container)
        {

            _camera = Camera.main;
            _playerContainer = container;
        }


        public bool CheckPickable()
        {
            if (!_playerContainer.HasEmptySlot())
                return false;

            Ray ray = _camera.ScreenPointToRay(new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2));


            if (Physics.Raycast(ray, out RaycastHit hitInfo, rayDist))
            {
                Debug.DrawLine(ray.origin, hitInfo.point, Color.cyan);

                if (hitInfo.collider.TryGetComponent(out _findInteractable))
                { 
                    return true;
                }
            }

            return false;
        }

        public bool CheckContainer()
        {
            if (_playerContainer.HasEmptySlot())
                return false;

            Ray ray = _camera.ScreenPointToRay(new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2));


            if (Physics.Raycast(ray, out RaycastHit hitInfo, rayDist))
            {
                Debug.DrawLine(ray.origin, hitInfo.point, Color.cyan);

                if (hitInfo.collider.TryGetComponent(out _findContainer))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
