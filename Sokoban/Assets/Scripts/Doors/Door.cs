using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Sprites;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private DoorController doorController;
    [SerializeField] private int requiredPushedButtons;
    private int pushedButton = 0;
    public bool IsOpen = false;
    public DoorButtonType Type;
    public bool MoveON => false;

    private void Awake()
    {
        doorController.AddDoor(this);
    }

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = Type.color;
    }
    public void AddPushedButton()
    {
        pushedButton++;
    }
    public void RemovePushedButton()
    {
        pushedButton--;
    }

    public void Interact()
    {
        if (!CheckPushedButtons())
            return;

        IsOpen = !IsOpen;
        
        GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
    }

    private bool CheckPushedButtons()
    {
        return pushedButton == requiredPushedButtons;
    }

    

}
