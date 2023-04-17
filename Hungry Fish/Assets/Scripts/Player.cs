using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float distance = 1f;
    [SerializeField] private LayerMask layerMask;

    private bool canMove;

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        canMove = true;

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    private void Update()
    {
        HandleMovement();
    }

    public void HandleMovement()
    {
        Vector2 inputVector = GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, inputVector.y, 0f);

        canMove = Physics2D.CapsuleCast(transform.position, GetPlayerSize(), CapsuleDirection2D.Horizontal, 90, moveDir, distance, layerMask);

        if (canMove)
        {
            transform.position += moveDir * speed * Time.deltaTime;
        }
    }

    public Vector2 GetMovementVectorNormalized()
    {
        return playerInputActions.Player.Move.ReadValue<Vector2>().normalized;
    }

    public Vector2 GetPlayerSize()
    {
        return new Vector2(GetComponent<CapsuleCollider2D>().size.x, GetComponent<CapsuleCollider2D>().size.y);
    }
}
