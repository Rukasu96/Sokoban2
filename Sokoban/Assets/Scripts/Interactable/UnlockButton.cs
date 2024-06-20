using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockButton : MonoBehaviour, IInteractable
{
    [SerializeField] private GridController gridController;
    [SerializeField] private DoorController doorController;
    public DoorButtonType Type;
    public bool Ispushed;
    public static event Action<UnlockButton> ButtonPushed;
    public bool MoveON => false;
    
    private void Awake()
    {
        doorController.AddButton(this);
    }

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = Type.color;
    }

    private void Update()
    {
        if (Ispushed && gridController.ReturnCrate(transform.position) == null && gridController.GetTile(transform.position).entity == null)
        {
            Interact();
        }
    }

    public void Interact()
    {
        ButtonPushed?.Invoke(this);
    }

}
