using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerClone : Entity
{
    private void MoveClone(Vector3 playerInputValue)
    {
        movedDestination = -playerInputValue;
        Vector3 previousPos = transform.position;
        Vector3 destination = transform.position - playerInputValue;
        
        if (CanBeMoved(destination) || CanMoveCrate(destination, destination - playerInputValue))
            return;

        gridController.AssignEntityToTile(this, destination, previousPos);
        Move(destination);
    }

    private void OnEnable()
    {
        Player.CloneMoved += MoveClone;
    }
    private void OnDestroy()
    {
        Player.CloneMoved -= MoveClone;
    }
}
