using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterSpawnerManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemyGO;
    [SerializeField] int  maxEnemyCount;
    [SerializeField] float waitBetweenSpawns = 0.1f;

    float enemySpawned, enemySpawned1;
    float xPosition;
    float zPosition;
    int randomEnemy;

    public static int totalMaxEnemy;

    private void Start()
    {
        totalMaxEnemy = maxEnemyCount;
        StartCoroutine(EnemySpawn());
        StartCoroutine(EnemySpawn1());
    }

    IEnumerator EnemySpawn()
    {
        while (enemySpawned <= maxEnemyCount)
        {
            xPosition = Random.Range(100, 193);
            zPosition = Random.Range(-46, 48);

            Instantiate(enemyGO[0], new Vector3(xPosition, -20, zPosition), Quaternion.identity);

            yield return new WaitForSeconds(waitBetweenSpawns);

            enemySpawned += 1;
        }
    }

    IEnumerator EnemySpawn1()
    {
        while (enemySpawned1 <= maxEnemyCount)
        {
            xPosition = Random.Range(100, 193);
            zPosition = Random.Range(-46, 48);

            Instantiate(enemyGO[1], new Vector3(xPosition, -20, zPosition), Quaternion.identity);

            yield return new WaitForSeconds(waitBetweenSpawns);

            enemySpawned1 += 1;
        } 
    }
}
