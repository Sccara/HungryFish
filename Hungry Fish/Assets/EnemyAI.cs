using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    float timer = 0.0f;
    float speed = 10.0f;
    Transform target;
    Vector2 inputVector;
    [SerializeField] private LayerMask wallLayerMask;
    [SerializeField] CapsuleCollider2D collider;
    private bool canMove;
    [SerializeField] private float distance = 1f;
    [SerializeField] private SpriteRenderer sprite;

    private void Start()
    {
        inputVector = GetMovementVector();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer > 0)
        {
            HandleMovement();
        }
        else
        {
            inputVector = GetMovementVector();
            timer = 3.0f;
        }
    }

    private void HandleMovement()
    {
        Vector3 moveDir = new Vector3(inputVector.x, inputVector.y, 0f);

        canMove = !Physics2D.CapsuleCast(transform.position, GetSize(), CapsuleDirection2D.Horizontal, 90, moveDir, distance, wallLayerMask);

        if (canMove)
        {
            FlipSprite();
            transform.position += moveDir * speed * Time.deltaTime;
        }
        else
        {
            inputVector = GetMovementVector();
            timer = 3.0f;
        }
    }

    private Vector2 GetMovementVector()
    {
        return new Vector2(Random.Range(-1, 2), 0f);
    }

    public Vector2 GetSize()
    {
        return new Vector2(collider.size.x, collider.size.y);
    }

    private void FlipSprite()
    {
        if (inputVector.x > 0)
        {
            sprite.flipX = false;
        }
        else if (inputVector.x < 0)
        {
            sprite.flipX = true;
        }
    }
}
