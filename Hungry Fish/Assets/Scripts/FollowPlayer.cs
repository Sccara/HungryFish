using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public static FollowPlayer Instance { get; private set; }

    [SerializeField] private Transform player;
    private Vector3 offset;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        offset = new Vector3(0f, 0f, -1f);
    }

    private void Update()
    {
        if (player == null)
        {
            if (FindObjectOfType<Player>() != null)
            {
                player = FindObjectOfType<Player>().gameObject.transform;
            } 
        }
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }

    public void SetPlayerRef(Transform playerTransform)
    {
        player = playerTransform;
    }
}
