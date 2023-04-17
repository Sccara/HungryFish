using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float distance = 1f;
    [SerializeField] private LayerMask wallLayerMask;
    [SerializeField] private LayerMask enemyLayerMask;
    [SerializeField] private TextMeshProUGUI sizeText;

    private bool immortal = false;
    private float immortalityTimer = 3f;

    public float Size { get; private set; }

    public int Lives { get; private set; }

    private bool canMove;

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        canMove = true;
        Size = 1;
        Lives = 3;
        sizeText.text = Size.ToString();
        transform.localScale = new Vector3(Size, Size, transform.localScale.z);

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    private void Update()
    {
        HandleMovement();
        CheckCollisionWithEnemy();
        sizeText.text = Size.ToString();
        transform.localScale = new Vector3(Size, Size, transform.localScale.z);
    }

    public void HandleMovement()
    {
        Vector2 inputVector = GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, inputVector.y, 0f);

        canMove = !Physics2D.CapsuleCast(transform.position, GetPlayerSize(), CapsuleDirection2D.Horizontal, 90, moveDir, distance, wallLayerMask);

        if (canMove)
        {
            transform.position += moveDir * speed * Time.deltaTime;
        }
    }
    public void CheckCollisionWithEnemy()
    {
        Vector2 inputVector = GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, inputVector.y, 0f);

        RaycastHit2D hit = Physics2D.CapsuleCast(transform.position, GetPlayerSize(), CapsuleDirection2D.Horizontal, 90, moveDir, distance, enemyLayerMask);

        if (hit.collider != null)
        {
            Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();

            float enemySize = enemy.GetSize();

            if (enemySize > Size && !immortal)
            {
                TakeDamage();
            }
            else if (enemySize <= Size)
            {
                IncreaseSize(enemy.GetRewardSize());
                enemy.TakeDamage();
            }
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

    public IEnumerator GiveImmortality()
    {
        yield return new WaitForSeconds(immortalityTimer);

        immortal = false;
    }

    public void TakeDamage()
    {
        Lives--;

        if (Lives <= 0)
        {
            OnLivesEnded();
        }
        else
        {
            immortal = true;
            StartCoroutine(GiveImmortality());
            Debug.Log(Lives);
        }
    }

    public void IncreaseSize(float size)
    {
        Size += size;
    }

    public void OnLivesEnded()
    {
        Destroy(gameObject);
        Debug.Log("Lives ended!");
    }
}
