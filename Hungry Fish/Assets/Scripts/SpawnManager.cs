using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform enemyPrefab;

    [SerializeField] private List<Sprite> sprites;

    private float spawnRangeX = 100f;
    private float spawnRangeY = 100f;
    private int enemiesCount = 30;

    private void Start()
    {
        NetworkManagerUI.OnStartServer += SpawnEnemies;
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < enemiesCount; i++)
        {
            SpawnEnemy();
        }
    }

    public Transform SpawnEnemy()
    {
        Vector2 spawnRange = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(-spawnRangeY, spawnRangeY));

        Transform enemy = Instantiate(enemyPrefab, spawnRange, Quaternion.identity);

        enemy.GetComponent<Enemy>().SetSprite(GetRandomEnemySprite());

        return enemy;
    }

    private Sprite GetRandomEnemySprite()
    {
        return sprites[Random.Range(0, 6)];
    }
}
