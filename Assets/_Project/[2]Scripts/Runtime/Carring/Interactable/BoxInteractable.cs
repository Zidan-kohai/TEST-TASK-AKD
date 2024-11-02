using Runtime.Carring;
using System.Collections.Generic;
using UnityEngine;

public class BoxInteractable : MonoBehaviour, IInteractable
{
    private IContainer _container;

    [SerializeField] private List<Collider> _colliders;
    public Transform GetTransform => transform;

    public void SetContainer(IContainer container)
    {
        if (_container != null)
            _container.Remove(this);

        _container = container;
        _container.Add(this);
    }

    public void DisableColliders() => 
        _colliders.ForEach(c => c.enabled = false);

    public void EnableColliders() => 
        _colliders.ForEach(c => c.enabled = true);

}
