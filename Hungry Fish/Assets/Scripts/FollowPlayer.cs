using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 offset;

    private void Start()
    {
        offset = new Vector3(0f, 0f, -1f);
    }

    private void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}
