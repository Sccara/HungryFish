using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TestSuite
{
    [UnityTest]
    public IEnumerator SpawnEnemies()
    {
        yield return null;
    }

    [UnityTest]
    public IEnumerator HandlePlayerMovement()
    {
        yield return null;
    }

    [UnityTest]
    public IEnumerator HandleEnemyMovement()
    {
        yield return null;
    }

    [UnityTest]
    public IEnumerator CheckCollisionWithEnemy()
    {
        yield return null;
    }

    [UnityTest]
    public IEnumerator CheckCollisionWithPlayer()
    {
        yield return null;
    }

    [UnityTest]
    public IEnumerator DestroyEnemyObjectAndAddScale()
    {
        yield return null;
    }

    [UnityTest]
    public IEnumerator TakeDamageAndDestroyPlayerObject()
    {
        yield return null;
    }

    [UnityTest]
    public IEnumerator ChangeMovementDirectionAndFlipSprite()
    {
        yield return null;
    }
}