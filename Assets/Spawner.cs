using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnrate = 1f;
    public float rangedspawnrate = 1f;
    public GameObject[] enemyprefabs;
    public GameObject[] rangedprefab;
    public bool canspawn = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnRangedEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnrate);
        while (canspawn)
        {
            yield return wait;
            int rand = Random.Range(0, enemyprefabs.Length);
            GameObject ENEMYtoSpawn = enemyprefabs[rand];
            Instantiate(ENEMYtoSpawn, transform.position, Quaternion.identity);
        }
    }

    private IEnumerator SpawnRangedEnemies()
    {
        WaitForSeconds wait = new WaitForSeconds(rangedspawnrate);
        while (canspawn)
        {
            yield return wait;
            int rand = Random.Range(0, rangedprefab.Length);
            GameObject RANGEDtoSpawn = rangedprefab[rand];
            Instantiate(RANGEDtoSpawn, transform.position, Quaternion.identity);
        }
    }
}
