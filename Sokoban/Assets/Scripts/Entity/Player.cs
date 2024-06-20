using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity
{
    private PlayerInput input = null;

    private int movesCount = 0;
    public int MovesCount => movesCount;
    public static event Action<Vector3> CloneMoved;

    private void Awake()
    {
        input = new PlayerInput();
    }

    private void XMakeMove(InputAction.CallbackContext value)
    {
        if (isMoving)
            return;

        Vector3 previousPos = transform.position;
        movedDestination = new Vector3(value.ReadValue<float>(), 0f, 0f);

        Vector3 destination = previousPos + movedDestination;

        if (CanBeMoved(destination) || CanMoveCrate(destination, destination + MovedDestination))
            return;

        isMoving = true;

        Move(destination);
        gridController.AssignEntityToTile(this, destination, previousPos);
        CloneMoved?.Invoke(movedDestination);
        movesCount++;
    }
    private void YMakeMove(InputAction.CallbackContext value)
    {
        if (isMoving)
            return;

        Vector3 previousPos = transform.position;
        movedDestination = new Vector3(0f, value.ReadValue<float>(), 0f);

        Vector3 destination = previousPos + movedDestination;

        if (CanBeMoved(destination) || CanMoveCrate(destination, destination + MovedDestination))
            return;

        isMoving = true;

        Move(destination);
        gridController.AssignEntityToTile(this, destination, previousPos);
        CloneMoved?.Invoke(movedDestination);
        movesCount++;
    }

    private void DissapearingAnim()
    {
        var sequence = DOTween.Sequence();

        sequence.Append(transform.DOScale(1.2f, 0.3f));
        sequence.Append(transform.DOScale(0.1f, 0.2f));

        sequence.OnComplete(() => Destroy(gameObject));
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.XMovement.performed += XMakeMove;
        input.Player.YMovement.performed += YMakeMove;
        ExitButton.StageFinished += DissapearingAnim;
    }

    private void OnDestroy()
    {
        input.Disable();
        input.Player.XMovement.performed -= XMakeMove;
        input.Player.YMovement.performed -= YMakeMove;
        ExitButton.StageFinished -= DissapearingAnim;
    }
}
