using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPool : MonoBehaviour
{
    public GameObject shadowPrefab;
    public int shadowCount = 8;
    private Queue<GameObject> playerShadow = new Queue<GameObject>();
    private void Start()
    {
        FillPlayerPool(8);
    }

    public void FillPlayerPool(int shadowCount)
    {
        for (int i = 0; i < shadowCount; i++)
        {
            var newShadow = Instantiate(shadowPrefab);
            newShadow.transform.SetParent(transform);
            ReturnPlayerPool(newShadow);
        }
    }
    public void ReturnPlayerPool(GameObject newShadow)
    {
        newShadow.gameObject.SetActive(false);
        playerShadow.Enqueue(newShadow);
    }
    public void GetFromPlayerPool()
    {
        if (playerShadow.Count == 0) FillPlayerPool(1);
        var outShadow = playerShadow.Dequeue();
        outShadow.SetActive(true);
    }
}
