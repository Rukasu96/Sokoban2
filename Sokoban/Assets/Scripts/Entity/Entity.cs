using DG.Tweening;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] protected GridController gridController;

    protected Vector3 movedDestination;
    protected bool isMoving;

    public Vector3 MovedDestination { get => movedDestination; }

    protected void Move(Vector3 destination)
    {
        transform.DOMove(destination, 0.1f).OnComplete(() => isMoving = false);
    }
    protected bool CanBeMoved(Vector3 destination)
    {
        if(gridController.IsTileBlocked(destination))
            return true;

        return false;
    }

    protected bool CanMoveCrate(Vector3 destination, Vector3 crateDestination)
    {
        Crate crate = gridController.ReturnCrate(destination);

        if (crate == null)
            return false;

        if (crate.CanBeMoved(crateDestination))
            return true;

        if (gridController.GetTile(crateDestination) == null)
            return true;

        if (gridController.GetTile(crateDestination).crate != null)
            return true;

        return false;

    }

}
