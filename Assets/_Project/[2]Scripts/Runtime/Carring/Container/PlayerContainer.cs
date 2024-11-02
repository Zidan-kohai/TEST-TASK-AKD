using Runtime.Carring;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class PlayerContainer : MonoBehaviour, IContainer
{
    [SerializeField] private List<Cell> _freePositions;

    public IInteractable GetCurrentInteractable =>
            _freePositions.FirstOrDefault(x => x.Interactable != null).Interactable;

    public bool HasEmptySlot()
    {
        int emptyCell = _freePositions.Count(x => x.Interactable == null);
        return emptyCell > 0;
    }

    public void Add(IInteractable interactable)
    {

        interactable.DisableColliders();

        var tr = interactable.GetTransform;

        var emptyCell = _freePositions.FindLast(x => x.Interactable == null);

        tr.parent = emptyCell.Transform;
        tr.localPosition = Vector3.zero;
        tr.localRotation = Quaternion.identity;

        emptyCell.Interactable = interactable;

    }

    public void Remove(IInteractable interactable)
    {
        interactable.EnableColliders();

        var tr = interactable.GetTransform;

        var cell = _freePositions.FirstOrDefault(x => x.Interactable == interactable);

        cell.Interactable = null;
    }
}
