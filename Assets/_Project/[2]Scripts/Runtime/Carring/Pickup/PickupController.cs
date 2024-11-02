using AYellowpaper;
using Infrustructure.Service.Input;
using System;
using UnityEngine;
using Zenject;

namespace Runtime.Carring
{
    public class PickupController : MonoBehaviour
    {
        [SerializeField] private InterfaceReference<IContainer, MonoBehaviour> _container;
        private Camera _camera;
        private IInteractionValidator _validator;
        private IInput _input;

        [Inject]
        private void Constructor(IInteractionValidator pickupValidator, IInput input)
        {
            _validator = pickupValidator;
            _input = input;
        }

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (_container.Value.HasEmptySlot())
            {
                CheckPickable();
            }
            else
            {
                CheckContainer();
            }
        }

        private void CheckContainer()
        {
            if(_validator.CheckContainer() && _input.IsE)
            {
                var interactable = _container.Value.GetCurrentInteractable;
                var container = _validator.GetContainer;

                if (interactable != null)
                    interactable.SetContainer(container);
            }
        }

        private void CheckPickable()
        {
            if (_validator.CheckPickable() && _input.IsE)
            {
                _validator.GetInteractible.SetContainer(_container.Value);
            }
        }
    }
}