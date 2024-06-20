using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour, IInteractable
{
    [SerializeField] GridController gridController;
    public static event Action StageFinished;

    public bool MoveON => false;
    private void Start()
    {
        gridController.AssignInteractableToTile(this, transform.position);
    }
    public void Interact()
    {
        
        if (gridController.GetTile(transform.position).entity == null)
            return;

        StageFinished?.Invoke();
    }

}
