using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GridController : MonoBehaviour
{
    private CustomGrid customGrid;

    private void Awake()
    {
        customGrid = GetComponent<CustomGrid>();
    }

    public Tile GetTile(Vector3 position)
    {
        
        int posX = Mathf.RoundToInt(position.x + customGrid.OffsetX);
        int posY = Mathf.RoundToInt(position.y + customGrid.OffsetY);

        if (customGrid.Tiles[posX][posY] == null)
        {
            return null;
        }

        return customGrid.Tiles[posX][posY];
    }

    public bool IsTileBlocked(Vector3 destination)
    {
        Tile tile = GetTile(destination);

        if (tile.door != null && !tile.door.IsOpen)
            return true;

        return false;
    }

    public void AssignEntityToTile(Entity entity, Vector3 destination, Vector3 previousPos)
    {
        GetTile(destination).entity = entity;
        GetTile(previousPos).entity = null;

        DoInteract(destination);
    }
    public void AssignInteractableToTile(IInteractable interactable, Vector3 position)
    {
        GetTile(position).interactable = interactable;

    }
    public void AssingDoorToTile(Door door)
    {
        GetTile(door.transform.position).door = door;
    }
    public void RemoveInteractableFromTile(Vector3 position)
    {
        GetTile(position).interactable = null;
    }
    public void AssingCrateToTile(Crate crate, Vector3 destination, Vector3 previousPos)
    {
        GetTile(previousPos).crate = null;
        GetTile(destination).crate = crate;

        DoInteract(destination);
        RemoveInteractableFromTile(previousPos);
        AssignInteractableToTile(crate,destination);
    }

    public Crate ReturnCrate(Vector3 position)
    {
        return GetTile(position).crate;
    }

    private void DoInteract(Vector3 position)
    {
        if (GetTile(position).crate != null && GetTile(position).entity != null)
        {
            GetTile(position).crate.MovedDestination = GetTile(position).entity.MovedDestination;
        }

        IInteractable interactable = GetTile(position).interactable;

        if (interactable != null)
            interactable.Interact();
    }

    private void OnEnable()
    {
        Crate.CrateMoved += AssingCrateToTile;
    }

    private void OnDestroy()
    {
        Crate.CrateMoved -= AssingCrateToTile;
    }

}
