using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] houseGO;
    [SerializeField] int maxHouseCount;

    float houseSpawned, houseSpawned1, houseSpawned2;
    float xPosition;
    float zPosition;

    public static int totalMaxEnemy;

    private void Start()
    {
        StartCoroutine(houseSpawn());
        StartCoroutine(houseSpawn1());
        StartCoroutine(houseSpawn2());
    }

    IEnumerator houseSpawn()
    {
        while (houseSpawned <= maxHouseCount)
        {
            xPosition = Random.Range(100, 193);
            zPosition = Random.Range(-46, 48);

            Instantiate(houseGO[0], new Vector3(xPosition, -20, zPosition), Quaternion.identity);

            yield return new WaitForSeconds(.1f);

            houseSpawned += 1;
        }
    }
    IEnumerator houseSpawn1()
    {
        while (houseSpawned1 <= maxHouseCount)
        {
            xPosition = Random.Range(100, 193);
            zPosition = Random.Range(-46, 48);

            Instantiate(houseGO[1], new Vector3(xPosition, -20, zPosition), Quaternion.identity);

            yield return new WaitForSeconds(.1f);

            houseSpawned1 += 1;
        }
    }
    IEnumerator houseSpawn2()
    {
        while (houseSpawned2 <= maxHouseCount)
        {
            xPosition = Random.Range(100, 193);
            zPosition = Random.Range(-46, 48);

            Instantiate(houseGO[2], new Vector3(xPosition, -20, zPosition), Quaternion.identity);

            yield return new WaitForSeconds(.1f);

            houseSpawned2 += 1;
        }
    }
}
