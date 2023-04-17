using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float size;
    [SerializeField] private int startSize;
    [SerializeField] private TextMeshProUGUI sizeEnemyText;

    private float sizeReward;

    private void Awake()
    {
        startSize = Random.Range(1, 4);
 
        size = startSize;
        sizeEnemyText.text = size.ToString();
        transform.localScale = new Vector3(size, size, transform.localScale.z);

        sizeReward = size / 10;
    }

    private void Update()
    {
        sizeEnemyText.text = size.ToString();
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
