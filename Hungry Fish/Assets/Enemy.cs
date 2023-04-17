using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float size;
    [SerializeField] private int startSize;

    private float sizeReward;

    private void Awake()
    {
        startSize = Random.Range(1, 4);

        size = startSize;

        transform.localScale = new Vector3(size, size, transform.localScale.z);

        sizeReward = size / 10;
    }

    public void TakeDamage()
    {
        Destroy(gameObject);
    }

    public float GetSize()
    {
        return size;
    }

    public float GetRewardSize()
    {
        return sizeReward;
    }
}
