using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour, IInteractable
{
    [SerializeField] private GridController gridController;

    public Vector3 MovedDestination;
    public bool MoveON => true;
    public static event Action<Crate, Vector3, Vector3> CrateMoved;

    private void Start()
    {
        gridController.GetTile(transform.position).interactable = this;
        gridController.GetTile(transform.position).crate = this;
    }
    private void CrateMove(Vector3 destination)
    {
        transform.DOMove(destination, 0.1f);
    }
    public bool CanBeMoved(Vector3 destination)
    {
        if (gridController.IsTileBlocked(destination))
            return true;

        return false;
    }
    public void Interact()
    {
        Vector3 previousPos = transform.position;
        Vector3 destination = transform.position + MovedDestination;
        CrateMove(destination);
        CrateMoved?.Invoke(this, destination, previousPos);
    }

    

}
