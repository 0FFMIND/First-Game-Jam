using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMgr : MonoBehaviour
{
    public GameObject npcSpawn;
    public GameObject[] enemies;
    public float initialTimeBetweenSpawn;
    public float minimalTimeBetweenSpawn;
    public float timeReduce;
    public float timeBeforeFristSpawn;

    private BoxCollider2D spawnArea;
    private bool enemySpawning = false;
    private float timeBetweenSpawn;
    private void Start()
    {
        spawnArea = GetComponent<BoxCollider2D>();
        timeBetweenSpawn = initialTimeBetweenSpawn;
        StartSpawning();
    }
    private void StartSpawning()
    {
        enemySpawning = true;
        StartCoroutine(ManageSpawn());
    }
    private IEnumerator ManageSpawn()
    {
        int firstNum = 2;
        int lastNum = 1;
        yield return new WaitForSeconds(timeBeforeFristSpawn);
        while (enemySpawning)
        {
            int eneniesNumber = UnityEngine.Random.Range(lastNum, firstNum);
            for (int i = 0; i < eneniesNumber; i++)
            {
                SpawnEnemyRandomly(enemies[UnityEngine.Random.Range(0, enemies.Length)]);
            }
            timeBetweenSpawn -= timeReduce;
            firstNum += 1;
            lastNum += 1;
            if(timeBetweenSpawn < minimalTimeBetweenSpawn)
            {
                timeBetweenSpawn = minimalTimeBetweenSpawn;
            }
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }
    private void SpawnEnemyRandomly(GameObject enemy)
    {
        Vector3 rndPoint3D = RandomPointInBounds(spawnArea.bounds, 1f);
        Vector2 rndPoint2D = new Vector2(rndPoint3D.x, rndPoint3D.y);
        Vector2 rndPointInside = spawnArea.ClosestPoint(new Vector2(rndPoint2D.x, rndPoint2D.y));
        if(rndPointInside.x == rndPoint2D.x && rndPointInside.y == rndPoint2D.y)
        {
            var spawn = Instantiate(npcSpawn, rndPoint3D, Quaternion.identity);
            spawn.GetComponent<EnemySpawn>().NpcToSpawn = enemy;
        }
        else
        {
            SpawnEnemyRandomly(enemy);
        }
    }
    private Vector3 RandomPointInBounds(Bounds bounds, float scale)
    {
        return new Vector3(
            UnityEngine.Random.Range(bounds.min.x*scale,bounds.max.x*scale),
            UnityEngine.Random.Range(bounds.min.y*scale,bounds.max.y*scale),
            1f
            );
    }
}
