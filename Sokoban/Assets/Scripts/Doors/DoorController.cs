using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Windows;

public class DoorController : MonoBehaviour
{
    private GridController gridController;
    private List<Door> doors = new List<Door>();
    private List<UnlockButton> unlockedButtons = new List<UnlockButton>();

    private void Start()
    {
        gridController = GetComponent<GridController>();
        AssignDoorsAndButtons();
    }

    public void AddDoor(Door door)
    {
        doors.Add(door);
    }
    public void AddButton(UnlockButton button)
    {
        unlockedButtons.Add(button);
    }

    public void ButtonPushed(UnlockButton button)
    {
        if (button.Ispushed)
        {
            gridController.AssignInteractableToTile(button, button.transform.position);
            foreach (Door door in doors)
            {
                if (door.Type.color == button.Type.color)
                {
                    door.Interact();
                    door.RemovePushedButton();
                }
            }
            button.Ispushed = false;
        }
        else
        {
            gridController.RemoveInteractableFromTile(button.transform.position);
            foreach (Door door in doors)
            {
                if (door.Type.color == button.Type.color)
                {
                    door.AddPushedButton();
                    door.Interact();
                }
            }
            button.Ispushed = true;
        }


    }

    private void AssignDoorsAndButtons()
    {
        foreach (Door door in doors) 
        {
            gridController.AssingDoorToTile(door);
        }

        foreach (UnlockButton button in unlockedButtons)
        {
            gridController.AssignInteractableToTile(button, button.transform.position);
        }
    }

    private void OnEnable()
    {
        UnlockButton.ButtonPushed += ButtonPushed;
    }
    private void OnDestroy()
    {
        UnlockButton.ButtonPushed -= ButtonPushed;
    }

}
