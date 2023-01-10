using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject NpcToSpawn;
    private void Start()
    {
        StartCoroutine(SpawnNpc());
    }
    private IEnumerator SpawnNpc()
    {
        yield return new WaitForSeconds(0.4f);
        Instantiate(NpcToSpawn, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
